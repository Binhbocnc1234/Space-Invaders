using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class ScenceName{
  public static string Campain = "Campain";
  public static string Menu = "Menu";

}
public class LoadSence : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeToPlay()
    {
      SceneManager.LoadScene("Campain");  
    }

    public void ChangeToMenu(){
      SceneManager.LoadScene("Menu");
      Cursor.visible = true;
    }
    public void ChangeToSetting(){
      SceneManager.LoadScene("Setting");
      Cursor.visible = true;
    }
    public void Change(string name){
      SceneManager.LoadScene(name);
    }


    
}
