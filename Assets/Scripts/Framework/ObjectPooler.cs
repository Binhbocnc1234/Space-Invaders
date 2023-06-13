using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPooler : MonoBehaviour{
	[Serializable]
	public class Pool{
		public string tag;
		public GameObject prefab;
		public int size;
	}
	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
	void Start(){
		
	}
}