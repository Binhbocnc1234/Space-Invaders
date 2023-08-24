using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingMode{Straight, Lerp}
public class Destination : MonoBehaviour
{
    // Start is called before the first frame update
    public float diffCamHeight = 0, movingSpeed = 1, delayTime = 0;
    public Timer delayTimer = new Timer(0);
    public MovingMode movingMode;
    void Start()
    {
        delayTimer.totalTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<BoxCollider2D>()
    }
}
