
using UnityEngine;
using UnityEngine.Rendering;


/// <summary>
/// ShipBase accounts 2x2 area. When a Alien enters your base, you lose
/// </summary>

public class ShipBase : MonoBehaviour
{
    /// <summary>
    /// Position of ShipBase relative to MotherShip
    /// </summary>
    [HideInInspector] public int i, j;
    public void Lose(){
        
    }
    public void SetPosition(int i, int j){
        transform.localPosition = new Vector3(i + 0.5f, j + 0.5f, 0);
        this.i = i; this.j = j;
        GetComponent<HarmonicOscillation>().original = transform.position;
        GetComponent<SortingGroup>().sortingOrder = MotherShip.Instance.hei - i;
    }
}