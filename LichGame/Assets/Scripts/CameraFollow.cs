using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Player;
    public float Speed;

    void Update()
    {
        float distance = 0.01f + Mathf.Sqrt(Mathf.Abs(Player.transform.position.x - transform.position.x) + Mathf.Abs(Player.transform.position.y - transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * distance );
    }
}
