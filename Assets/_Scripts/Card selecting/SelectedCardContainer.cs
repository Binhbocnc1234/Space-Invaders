using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCardContainer : MonoBehaviour
{
    public List<ItemProfileSO> choosenCard;
    public void SelectCard(ItemProfileSO so){
        foreach(Transform child in transform){
            SelectedCard card = child.GetComponent<SelectedCard>();
            card.SelectCard(so);
            return;
        }
    }
}
