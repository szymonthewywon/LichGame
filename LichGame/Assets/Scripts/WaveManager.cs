using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawn spawn;
    [SerializeField] private int points;
    private bool spawnStarted = false;
    void Update()
    {
        if (!spawnStarted)
        {
            spawn.startWave(points, 3, 2);
            spawnStarted = true;
        }

    }

}
