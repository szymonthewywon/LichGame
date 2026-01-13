using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSpawner : MonoBehaviour
{

    public Canvas worldCanvas;
    public GameObject wallButtonPrefab;
    public GameObject floorButtonPrefab;
    public List<GameObject> targetObjects;


    void Start()
    {
        StartCoroutine(DelayedSpawn());
    }

    void SpawnButtons()
    {
        Debug.Log("spawnButtonsTriggered");
        foreach (GameObject target in targetObjects)
        {
            GameObject button = null;
            if(target.name == "WallTrap")
            {
                button = Instantiate(wallButtonPrefab, worldCanvas.transform);
            }
            else if (target.name == "FloorTrap")
            {
                button = Instantiate(floorButtonPrefab, worldCanvas.transform);
            }
            Debug.Log("Spawned button");
            // Position in world
            button.transform.position = target.transform.position;

        }
    }
    IEnumerator DelayedSpawn()
    {
        yield return null;
        SpawnButtons();
    }
}
