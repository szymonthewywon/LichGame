using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownPanel : MonoBehaviour
{

    public Button mainButton;
    public GameObject dropdownPanel;
    public Button optionButtonPrefab;
    public GameObject[] wallTrapPrefabs;
    public GameObject[] floorTrapPrefabs;
    public ResourceManager resourceManager;

    void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        dropdownPanel.SetActive(false);
        mainButton.onClick.AddListener(ToggleDropdown);
    }

    void ToggleDropdown()
    {
        if (!dropdownPanel.activeSelf)
            BuildOptions();

        dropdownPanel.SetActive(!dropdownPanel.activeSelf);
    }

    void BuildOptions()
    {
        // Clear old options
        foreach (Transform child in dropdownPanel.transform)
        {
            if (child.gameObject != optionButtonPrefab.gameObject)
                Destroy(child.gameObject);
        }

        if (gameObject.tag == "WallButton")
        {
            for (int i = 0; i < wallTrapPrefabs.Length; i++)
            {
                CreateOption("Place " + wallTrapPrefabs[i].name + " Trap", wallTrapPrefabs[i]);
            }

        }
        else if (gameObject.tag == "FloorButton")
        {
            for (int i = 0; i < floorTrapPrefabs.Length; i++)
            {
                CreateOption("Place " + floorTrapPrefabs[i].name + " Trap", floorTrapPrefabs[i]);
            }
        }
    }

    void CreateOption(string label, GameObject prefab)
    {
        Button button = Instantiate(optionButtonPrefab, dropdownPanel.transform);
        button.gameObject.SetActive(true);
        button.GetComponentInChildren<TextMeshProUGUI>().text = label;
        Debug.Log("TMP found: " + button.GetComponentInChildren<TextMeshProUGUI>());

        button.onClick.AddListener(() =>
        {
            if (prefab.GetComponent<TrapInformation>().cost <= resourceManager.essence)
            {
                Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
                resourceManager.essence -= prefab.GetComponent<TrapInformation>().cost;
                dropdownPanel.SetActive(false);
                Destroy(gameObject);
            }
        });
    }
}