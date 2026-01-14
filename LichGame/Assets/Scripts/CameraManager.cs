using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private DungeonCameraZoomOut dungeonCamera;
    [SerializeField] private CameraFollow playerCamera;
    public bool dungeonViewActive = false; 
    private void Start()
    {
        dungeonViewActive = dungeonCamera.enabled;
    }
}
