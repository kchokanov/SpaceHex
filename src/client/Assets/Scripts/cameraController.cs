using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Plane limits
    [SerializeField] int xMax;
    [SerializeField] int xMin;
    [SerializeField] int zMax;
    [SerializeField] int zMin;
    //Orthographic size limits and zoom increase
    [SerializeField] float zoomSpeed;
    [SerializeField] float zoomMax;
    [SerializeField] float zoomMin;
    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    private void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

        // Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize -= zoomSpeed;
        }

        // Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize += zoomSpeed;
        }
    }
    private void LateUpdate()
    {
        //Limiting camera to the plane
        Vector3 tmpPos = transform.position;
        tmpPos.x = Mathf.Clamp(tmpPos.x, xMin + 3 * Camera.main.orthographicSize, xMax - 3 * Camera.main.orthographicSize);
        tmpPos.z = Mathf.Clamp(tmpPos.z, zMin + Camera.main.orthographicSize, zMax - Camera.main.orthographicSize);
        transform.position = tmpPos;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, zoomMin, zoomMax);
        //Debug.Log("CamX:" + transform.position.x + " CamZ:" + transform.position.z);
        Debug.Log("CamZoom:" + Camera.main.orthographicSize);
    }
}