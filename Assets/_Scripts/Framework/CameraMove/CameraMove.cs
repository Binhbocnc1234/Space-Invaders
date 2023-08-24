using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    List<Destination> dests = new List<Destination>();
    int ind = 1; //index of next position
    void Start()
    {
        foreach (Transform child in transform){
            dests.Add(child.GetComponent<Destination>());
            child.gameObject.SetActive(false);

        }
        Vector3 temp = Camera.main.transform.position;
    
        temp = dests[0].transform.position;
        temp.z = -20;

        Camera.main.transform.position = temp;
    }

    // // Update is called once per frame
    void Update()
    {
        // Vector3 camPos =Camera.main.transform.position; 
        if (ind >= dests.Count){return;}
        if (dests[ind].movingMode == MovingMode.Straight){
            Camera.main.transform.Translate((dests[ind].transform.position - dests[ind-1].transform.position).
            normalized*dests[ind].movingSpeed*Time.deltaTime);
        }
        else if (dests[ind].movingMode == MovingMode.Lerp){
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, dests[ind].transform.position, dests[ind].movingSpeed * Time.deltaTime);
        }
        if (Vector2.Distance(Camera.main.transform.position, dests[ind].transform.position) <= 0.05f && dests[ind].delayTimer.Count()){
            ++ind;
        }
    }
    
}
