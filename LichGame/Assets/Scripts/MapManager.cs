
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private int mapLen;
    public List<List<GameObject>> nodes = new List<List<GameObject>>();
    public List<GameObject> generatedRooms = new List<GameObject>();
    private int lastGeneratedRoomWidth = 1;
    private int lastLastGeneratedRoomWidth;
    private float totalOffset = 0;
    void Start()
    {
        for (int i = 0; i < mapLen; i++)
        {
            if (lastGeneratedRoomWidth == 1)
            {
                generateOneToTwo();

            }
            else if (lastGeneratedRoomWidth == 2)
            {
                if (lastLastGeneratedRoomWidth == 2)
                {
                    generateTwoToOne();
                }
                else if (lastLastGeneratedRoomWidth == 1)
                {
                    int nextRoomLen = Random.Range(1, 3);
                    if (nextRoomLen == 1)
                    {
                        generateTwoToOne();
                    }
                    else if (nextRoomLen == 2)
                    {
                        generateTwoToTwo();
                    }
                }
            }
        }
        if (lastGeneratedRoomWidth == 1)
        {
            Instantiate(rooms[5], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        }
        else
        {
            GameObject corridoor = Instantiate(rooms[3], new Vector3(totalOffset, 0, 0), Quaternion.identity);
            nodes.Add(getNodes(corridoor));
            totalOffset += 14;
            Instantiate(rooms[5], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            Debug.Log($"Corridor {i} has {nodes[i].Count} nodes");
        }
        Debug.Log($"Total node paths: {nodes.Count}");

        for (int i = 0; i < nodes.Count; i++)
        {
            Debug.Log($"nodes[{i}] length: {nodes[i].Count}");
        }

    }
    private void generateOneToTwo()
    {
        GameObject room;
        GameObject corridoor = Instantiate(rooms[2], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        nodes.Add(getNodes(corridoor));
        totalOffset += 14;
        room = Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 12, 0), Quaternion.identity);
        generatedRooms.Add(room);
        room = Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, -13, 0), Quaternion.identity);
        generatedRooms.Add(room);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 2;
    }
    private void generateTwoToOne()
    {
        GameObject room;
        GameObject corridoor = Instantiate(rooms[3], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        nodes.Add(getNodes(corridoor));
        totalOffset += 14;
        room = Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        generatedRooms.Add(room);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 1;
    }
    private void generateTwoToTwo()
    {
        GameObject room;
        GameObject corridoor = Instantiate(rooms[4], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        nodes.Add(getNodes(corridoor));
        totalOffset += 17;
        room = Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 12, 0), Quaternion.identity);
        generatedRooms.Add(room);
        room = Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, -13, 0), Quaternion.identity);
        generatedRooms.Add(room);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 2;
    }

    public List<GameObject> getNodes(GameObject room)
    {
        List<GameObject> nodes = new List<GameObject>();
        foreach (var t in room.GetComponentsInChildren<Transform>(true))
        {
            if (t.CompareTag("Node"))
            {
                nodes.Add(t.gameObject);
            }
        }
        return nodes;
    }

}