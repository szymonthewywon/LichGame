using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private AIDestinationSetter AIDestinationSetter;
    private GameObject player;
    [SerializeField] private MapManager mapManager;
    private List<List<GameObject>> nodes;
    private int currentNode;
    private float nodeTriggerCooldown = 1f;
    private float lastNodeTriggerTime = -Mathf.Infinity;
    void Start()
    {
        player = GameObject.Find("Player");
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        nodes = mapManager.nodes;
        currentNode = nodes.Count - 1;
        AIDestinationSetter.target = nodes[currentNode][Random.Range(0, nodes[currentNode].Count)].transform;
        if (nodes.Count == 0)
        {
            Debug.LogError("No nodes generated!");
            return;
        }
    }

    private void setDestination()
    {
        GameObject targetNode;
        targetNode = nodes[currentNode][Random.Range(0, nodes[currentNode].Count)];
        AIDestinationSetter.target = targetNode.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Node"))
            return;

        if (Time.time - lastNodeTriggerTime < nodeTriggerCooldown)
            return;

        lastNodeTriggerTime = Time.time;

        currentNode -= 1;

        if (currentNode < 0)
            return;

        setDestination();
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

