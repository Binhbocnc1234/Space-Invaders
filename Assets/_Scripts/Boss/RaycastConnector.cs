using UnityEngine;

public class RaycastConnector : MonoBehaviour
{
    public GameObject objectA; public GameObject objectB; 
    private LineRenderer lineRenderer;

    bool check = false;

    void Start(){
        Render();
    }

    void Render(){
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null){
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); 
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        if(!objectA.activeSelf && !objectB.activeSelf){
            check = false;
            Destroy(lineRenderer);
            lineRenderer = null;
        }


        if (objectA != null && objectB != null && objectA.activeSelf && objectB.activeSelf){
            Render();

            Vector3 startPoint = objectA.transform.position;
            Vector3 endPoint = objectB.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(startPoint, (endPoint - startPoint).normalized, out hit, Vector3.Distance(startPoint, endPoint)) && !check){
                Entity entity = hit.collider.gameObject.GetComponent<Entity>();
                if (entity != null)
                {
                    if (entity.team == Team.Player && !check)
                    {
                        check = true;
                        entity.GetDamage(5);
                    }
                }

                if (hit.collider.gameObject == objectB){
                    lineRenderer.SetPosition(0, startPoint);
                    lineRenderer.SetPosition(1, endPoint);
                }
   
            }
            else{
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, endPoint);
            }
        }
    }
}