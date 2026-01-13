using UnityEngine;

public class AddToButtonList : MonoBehaviour
{
    public ButtonSpawner buttonSpawner;
    void Start()
    {
        buttonSpawner = GameObject.Find("ButtonManager").GetComponent<ButtonSpawner>();
        buttonSpawner.targetObjects.Add(gameObject);
    }

}
