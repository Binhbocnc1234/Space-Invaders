using System;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif


///<summary> 
/// Class used by SearchWindow. It help SearchWindow create contents like categories, subcategories, itemNames
///</summary>
public class StringSearchTree : ScriptableObject, ISearchWindowProvider
{
    /// <summary> Contain names of all items and their paths. Example for strings: "Material\Log", "Component\Energy\Reactor" </summary>
    private List<string[]> pathList;
    private Action<string> OnSetIndex;
    char SEP = '_';
    public StringSearchTree(List<string[]> itemPaths, Action<string> callback, char separator = '\\'){
        pathList = itemPaths;
        OnSetIndex = callback;
        SEP = separator;
    }
    public StringSearchTree(Type enumType, Action<string> callback, char separator = '_'){
        pathList = new List<string[]>();
        foreach(string path in Enum.GetNames(enumType)){
            pathList.Add(path.Split('_'));
        }
        OnSetIndex = callback;
    }
    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        //SearchTreeEntry : it's leaves(itemName), you can click on it to set value for your field
        //SearchTreeGroupEntry : derive from SearchTreeEntry, it contains both nodes(subcategories) and leaves(itemName)
        var list = new List<SearchTreeEntry>(){
            new SearchTreeGroupEntry(new GUIContent("Search for ItemCode"), 0)
        };
        SortPathList();
        //Groups contain names of all paths and subpaths. Used to check duplicate pairs
        List<string> groups = new List<string>();
        foreach(string[] path in pathList){
            string pathInString = "";
            for (int i = 0; i < path.Length - 1; ++i){
                pathInString += path[i];
                if (!groups.Contains(pathInString)){
                    //Add nodes
                    list.Add(new SearchTreeGroupEntry(new GUIContent(path[i]), i + 1));
                    groups.Add(pathInString);
                }
                pathInString += SEP;
            }
            //The last entry is the actual name of item
            SearchTreeEntry entry = new SearchTreeEntry(new GUIContent(path[path.Length-1]));
            entry.level = path.Length; 
            entry.userData = pathInString + path[path.Length-1];
            list.Add(entry);
        }
        return list;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        OnSetIndex?.Invoke((string)SearchTreeEntry.userData);
        return true;
    }
    void SortPathList(){
        pathList.Sort((path_a, path_b) => {
            for (int i = 0; i < path_a.Length; ++i){
                // if (i >= split_b.Length){return 1;}
                //Compare two subcategories
                int value = path_a[i].CompareTo(path_b[i]);
                if(value != 0){
                    //Make sure that among the paths in the same category, prioritize nodes rather than leaves
                    //For example : "Component\Turret\Crossbow" and "Component\Material\Cog" precede "Component\ElectricTower"
                    if (path_a.Length != path_b.Length && (i == path_a.Length-1 || i == path_a.Length-1)){
                        return path_a.Length < path_b.Length ? 1 : -1;
                    }
                    return value;
                }
            }   
            return 0;
        });
    }

}
