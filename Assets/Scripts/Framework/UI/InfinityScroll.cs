using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutGroup))]
/// <summary>
/// <para> The default ScrollView is laggy. Add this script to LayoutGroup and the performance problem is fixed </para>
/// <para> Mechanic : Despite many items , there are only few objects appearing in scence. When you scroll down, the object from  </para>
/// </summary>
public class InfinityScroll : MonoBehaviour
{

    public int maxChild;
    public int maxHei;
    public int maxWid;
    public RectTransform content;
    public RectTransform child;
    // public List<Rec
    // GridLayoutGroup grid;
    void Start()
    {
        maxChild = maxHei * maxWid;
        for(int i = 0; i < maxChild; ++i){
            Transform newChild = Instantiate(child, content);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (content.GetChild(maxChild-1).GetComponent<RectTransform>().rect.yMin >= content.rect.yMin){
            RectTransform firstChild = content.GetChild(0).GetComponent<RectTransform>();
            firstChild.SetSiblingIndex(maxChild-1);

        }
    }
}
