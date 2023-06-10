using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public SplineComputer typeMove;

    // List items can be dropped
    public List<ItemProfileSO> itemContain = new List<ItemProfileSO>();
    public EnemyType enemyType = EnemyType.None;

    

}

public enum EnemyType
{
   None = 0,
   Outscreen = 1,
   Static = 2,
   
}
