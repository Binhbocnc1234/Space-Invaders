using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState{
    Begin,
    Combat,
    Lose,
    Win
}
public class GameContr : MonoBehaviour
{
    // Start is called before the first frame update
    protected static GameContr _instance;
    [HideInInspector] public static GameContr instance{get => _instance;}
    [HideInInspector] public float camHeight;
    public GameState gameState;
    
    
    void Awake()
    {
        _instance = this;
        camHeight = Camera.main.orthographicSize * Camera.main.aspect; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchState(GameState state){
        switch(gameState){
            case GameState.Begin:
                break;
            case GameState.Combat:
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
                break;
        }
        gameState = state;
    }

}
