using UnityEngine;

public class EnemyInformation : MonoBehaviour
{
    public int pointValue;
    public int essenceOnKill;
    public int health;
    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }
    void Update()
    {
        if (health == 0)
        {
            resourceManager.essence += essenceOnKill;
            Destroy(gameObject);
        }
    }

}
