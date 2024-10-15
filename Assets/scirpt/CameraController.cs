using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;
    public float panspeed = 30f;
    public float panBorderThinkness = 10f;

    public float scrollSpeed = 9f;
    public float MinY = 10f;
    public float MaxY = 80f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThinkness)
        {
            
            transform.Translate(Vector3.forward * panspeed * Time.deltaTime,Space.World);        
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThinkness)
        {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThinkness)
        {

            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThinkness)
        {

            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y,MinY,MaxY);

        transform.position = pos;
    }

}
