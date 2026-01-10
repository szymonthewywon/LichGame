using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private AIDestinationSetter AIDestinationSetter;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(updatePlayerLocation());
    }


    IEnumerator updatePlayerLocation()
    {
        while (true)
        {
            AIDestinationSetter.target = player.transform;
            yield return new WaitForSeconds(1f);
        }
    }
}

