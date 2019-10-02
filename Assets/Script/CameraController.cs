using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    private Vector3 CameraPos;
    private Vector3 CameraInitPos;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float magnification;
    private float minY = 10f;
    private float maxY = 80f;

    private float minX = 16f;
    private float maxX = 55f;

    private float minZ = -80f;
    private float maxZ = -65f ;

    private void Start()
    {
        CameraInitPos = transform.position;
    }

    void Update () {

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        CameraPos = transform.position;
        magnification = transform.position.y / CameraInitPos.y ;
       

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (CameraPos.z >= maxZ * magnification) return;
            //Vector3.forward = new Vector3(0f, 0f,1)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)
        {
            if (CameraPos.z <= minZ ) return;
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (CameraPos.x >= maxX / magnification || CameraPos.x >= 70f) return;
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if ( CameraPos.x <= minX * magnification) return;
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);         
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * scrollSpeed * Time.deltaTime * 500f;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
