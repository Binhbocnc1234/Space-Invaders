using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedCard : MonoBehaviour
{
    public enum State{Empty, NotEmpty, Move}
    public State state;
    public RectTransform empty, notEmpty;
    public TextMeshProUGUI tmp_1, tmp_2;
    public Image frame, background;
    ItemProfileSO itemProfileSO;
    protected void Start(){
        RemoveCard();
    }
    protected void Update(){
        if (state == State.Move){
            
        }
    }
    public void SelectCard(ItemProfileSO so){
        itemProfileSO = so;
        empty.gameObject.SetActive(false);
        notEmpty.gameObject.SetActive(true);
        if (so.itemType == ItemType.Tower){
            TowerSO towerSO = (TowerSO)so;
            frame.sprite = FrameContainer.Instance.rarityCardFrame[(int)so.rarity].frame;
            background.sprite = FrameContainer.Instance.rarityCardFrame[(int)so.rarity].background;
            tmp_1.text = towerSO.cost.ToString(); tmp_2.text = towerSO.dps.ToString();
        }
        else{
            Debug.LogError("Invalid given ItemProfileSO");
        }
    }
    public void RemoveCard(){
        empty.gameObject.SetActive(true);
        notEmpty.gameObject.SetActive(false);
    }
}
