using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonCameraZoomOut : MonoBehaviour
{
    public Camera cam;
    public float overviewZoom;
    public float zoomSpeed;
    public float roomZoom;
    private MapManager mapManager;
    [SerializeField]private List<Transform> roomList;
    Coroutine zoomRoutine;

    private void Start()
    {
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        StartCoroutine(LateStart());
    }
    public void ZoomOutToDungeon(List<Transform> rooms)
    {
        Vector3 dungeonCenter = GetDungeonCenter(rooms);

        if (zoomRoutine != null)
        {
            StopCoroutine(zoomRoutine);
        }

        zoomRoutine = StartCoroutine(ZoomRoutine(dungeonCenter));
    }


    Vector3 GetDungeonCenter(List<Transform> rooms)
    {
        Vector3 first = rooms[0].position;
        Vector3 last = rooms[rooms.Count - 1].position;

        return (first + last) * 0.5f + new Vector3(30,0,0);
    }

    IEnumerator ZoomRoutine(Vector3 targetCenter)
    {
        Vector3 startPos = cam.transform.position;
        float startZoom = cam.orthographicSize;

        targetCenter.z = startPos.z;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * zoomSpeed;

            cam.transform.position = Vector3.Lerp(startPos, targetCenter, t);
            cam.orthographicSize = Mathf.Lerp(startZoom, overviewZoom, t);

            yield return null;
        }
    }
    IEnumerator LateStart()
    {
        yield return null;
        for(int i = 0; i < mapManager.generatedRooms.Count; i++)
        {
            roomList.Add(mapManager.generatedRooms[i].GetComponent<Transform>());
        }
        mapManager.GetComponent<DungeonCameraZoomOut>().enabled = false;
    }
    private void OnEnable()
    {
        ZoomOutToDungeon(roomList);
    }
}