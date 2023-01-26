using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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



    
}
