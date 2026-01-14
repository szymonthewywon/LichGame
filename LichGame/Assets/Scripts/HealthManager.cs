using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int health;

    private void Update()
    {
        text.text = "Portal health:" + health;
        if (health == 0)
        {
            SceneManager.LoadScene("Die");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
