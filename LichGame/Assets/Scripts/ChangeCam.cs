using UnityEngine;

public class ChangeCam : MonoBehaviour
{

    public GameObject CameraObject;
    void Start()
    {
        CameraObject = GameObject.Find("CameraObject");
    }

    public void toggleCameraView()
    {
        if (CameraObject.GetComponent<CameraFollow>().enabled)
        {
            CameraObject.GetComponent<CameraFollow>().enabled = false;
            CameraObject.GetComponent<DungeonCameraZoomOut>().enabled = true;
        }
        else
        {
            CameraObject.GetComponent<CameraFollow>().enabled = true;
            CameraObject.GetComponent<DungeonCameraZoomOut>().enabled = false;
            CameraObject.GetComponentInChildren<Camera>().orthographicSize = 5;
            CameraObject.GetComponentInChildren<Camera>().transform.position = GameObject.Find("Player").transform.position + new Vector3(0,0,-9);
        }
    }



}
