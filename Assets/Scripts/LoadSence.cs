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
    public void Change1()
    {
      SceneManager.LoadScene("Campain");  
    }

    public void Change2(){
      SceneManager.LoadScene("Menu");
      Cursor.visible = true;
    }
    public void Change(string name){
      SceneManager.LoadScene(name);
    }


    
}
