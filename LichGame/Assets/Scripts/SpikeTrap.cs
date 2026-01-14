using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float damageInterval = 1.5f;
    public int damage = 1;

    private float damageTimer = 0f;
    private bool timerTickedThisFrame = false;

    void LateUpdate()
    {
        timerTickedThisFrame = false;
        if (damageTimer >= damageInterval)
        {
            damageTimer = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            if (!timerTickedThisFrame)
            {
                damageTimer += Time.deltaTime;
                timerTickedThisFrame = true;
            }

            if (damageTimer >= damageInterval)
            {
                EnemyInformation enemy = collision.GetComponent<EnemyInformation>();
                if (enemy != null)
                {
                    enemy.health -= damage;
                }
            }
        }
    }
}