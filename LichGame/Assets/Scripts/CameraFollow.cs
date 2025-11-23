using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Player;
    public float Speed;
    public float xOffset;
    public float yOffset;

    void Update()
    {
        float distance = 0.01f + Mathf.Sqrt(Mathf.Abs(Player.transform.position.x - transform.position.x) + Mathf.Abs(Player.transform.position.y - transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position + new Vector3(xOffset,yOffset,0), Speed * distance );
    }
}
