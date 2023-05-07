using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour
{
  // [SerializeField] PlayerInput playerInput;
  

  // Singleton 
  //  protected static ShipMov instance;
  //  public static ShipMov Instance {get => instance;}
  //   private void Awake(){
  //    ShipMov.instance = this;
  //  }




  [SerializeField] protected Vector3 worldPos;
  [SerializeField] protected float speed = 5.0f;
  
  [SerializeField] protected Renderer meshRender;
  public Vector2 offset;

  private bool isResetting = false;





  void Start(){
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    offset = meshRender.material.mainTextureOffset;
  }

  
  void Update(){
    Cursor.lockState = CursorLockMode.Confined;
    this.worldPos = InputManager.Instance.MousePosition;
    if(!isResetting){

      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      SetMousePositionCenter();
      StartCoroutine(EnablePlayerControlsAfterDelay(3f));
      return;
    }
    this.BackGround();
    this.worldPos.z = 0;
    this.Moving();
  }

  private void SetMousePositionCenter()
    {
       // Di chuyển chuột đến vị trí giữa màn hình - Move cursor to centre screen
        Vector3 worldPos = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        // Debug.Log(worldPos);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

  private IEnumerator EnablePlayerControlsAfterDelay(float delay)
  {
        yield return new WaitForSeconds(delay);
        isResetting = true;
        // Cho phép người chơi hoạt động - Available active
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
  }



  
  protected virtual void BackGround(){
    offset = offset + new Vector2(0, 0.1f*Time.deltaTime);
    meshRender.material.mainTextureOffset = offset;
  }
  protected virtual void Moving(){
    Vector3 newPos = Vector3.Lerp(transform.position, worldPos, this.speed);
    transform.position = newPos;
  }
}
