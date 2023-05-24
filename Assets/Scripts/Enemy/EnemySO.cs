using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public float health;
    [SerializeField] public float speed;

    // List items can be dropped
    public List<ItemProfileSO> itemContain = new List<ItemProfileSO>();
    public EnemyType enemyType = EnemyType.None;

}

public enum EnemyType
{
   None = 0,
   
   Another = 1,
   
}
