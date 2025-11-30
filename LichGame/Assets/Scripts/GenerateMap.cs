
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private int mapLen;
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

    }
    private void generateOneToTwo()
    {
        Instantiate(rooms[2], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        totalOffset += 14;
        Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 12, 0), Quaternion.identity);
        Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset , -13, 0), Quaternion.identity);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 2;
    }
    private void generateTwoToOne()
    {
        Instantiate(rooms[3], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        totalOffset += 14;
        Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 1;
    }
    private void generateTwoToTwo()
    {
        Instantiate(rooms[4], new Vector3(totalOffset, 0, 0), Quaternion.identity);
        totalOffset += 17;
        Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, 12, 0), Quaternion.identity);
        Instantiate(rooms[Random.Range(0, 2)], new Vector3(totalOffset, -13, 0), Quaternion.identity);
        totalOffset += 18;
        lastLastGeneratedRoomWidth = lastGeneratedRoomWidth;
        lastGeneratedRoomWidth = 2;
    }
}