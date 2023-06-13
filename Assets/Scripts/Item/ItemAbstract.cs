using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class trung gian
public class ItemAbstract : MonoBehaviour, ITemp
{
    [SerializeField] protected ItemCtrl itemCtrl;
	public ItemCtrl ItemCtrl => itemCtrl;

	protected virtual void LoadComponents()
	{
		this.LoadItemCtrl();
	}
	
	protected virtual void LoadItemCtrl()
	{
		if (this.itemCtrl != null) return;
		this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
	}
}
