using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEssence : MonoBehaviour
{ 
    private ResourceManager resourceManager;
    [SerializeField] private TextMeshProUGUI text;
    private void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = "Essence: " + resourceManager.essence;
    }
}
