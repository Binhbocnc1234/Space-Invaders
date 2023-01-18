using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer{
    public float curTime=0;
    public float totalTime;
    public bool isEnd = true;
    public Timer(float totalTime){
        this.totalTime = totalTime;
    }
    public bool Count(bool reset = true){
        
        if (curTime > totalTime){
            if (reset){curTime = 0;}
            isEnd = true;
        }
        else{
            curTime+=Time.deltaTime;
            isEnd = false;
        }
        
        return isEnd;
    }
    public void Reset(){
        curTime =0;
        isEnd = false;
    }
}
