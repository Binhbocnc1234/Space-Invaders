using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OscillationDirection{
    Vertical,
    Horizontal
}
public class HarmonicOscillation : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float speed = Mathf.PI;
    public OscillationDirection direction;
    public Vector3 original;
    float angle;
    float cycle;
    float t = 0;
    void Start(){
        cycle = 2*Mathf.PI/speed;
        angle = UnityEngine.Random.Range(0, 2*Mathf.PI);
    }
    void Update(){
        t += Time.deltaTime;
        t %= cycle;
        float x = amplitude*Mathf.Cos(speed*t + angle);
        
        if (direction == OscillationDirection.Vertical){
            transform.position = new Vector3(original.x, original.y + x, original.z);
        }
        else{
            transform.position = new Vector3(original.x + x, original.y, original.z);
        }
    }
    
}
