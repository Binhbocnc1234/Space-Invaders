using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//        |
//        |
//        |
// mũi tên chỉ xuống

// Use only to load component và load linked
public class EnemyCtrl : MonoBehaviour, ITemp
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    protected virtual void LoadComponents(){
     this.LoadEnemySpawner(); 
   }

   protected virtual void LoadEnemySpawner(){
    if(this.enemySpawner != null){return;}
    this.enemySpawner = GetComponent<EnemySpawner>();
   }


  

}
