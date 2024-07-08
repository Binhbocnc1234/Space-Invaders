using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public float speed;

    [SerializeField] public int Dmg;

    // List items can be dropped
    public List<ItemProfileSO> itemContain = new List<ItemProfileSO>();
    public EnemyType enemyType = EnemyType.None;

}

public enum EnemyType
{
   None = 0,
   Combat = 1,
   Range = 2,
}
