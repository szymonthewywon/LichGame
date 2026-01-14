using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private int damage;
    private void Start()
    {
        StartCoroutine(spell());
    }
    IEnumerator spell()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyInformation>().health -= damage;
        }
    }

}
