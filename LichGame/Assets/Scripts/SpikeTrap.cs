using UnityEngine;
using System.Collections;
public class SpikeTrap : MonoBehaviour
{

    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyInformation>().health -= 1;
        }
    }

}