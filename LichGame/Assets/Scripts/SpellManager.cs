using System.Collections;
using TMPro;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public float cooldown;
    public TextMeshProUGUI text;
    public GameObject spell;

    private void Start()
    {
        StartCoroutine(countdown());
    }
    private void Update()
    {
        if (cooldown > 0)
        {
            text.text = "Cooldown:" + cooldown;
        }
        else
        {
            text.text = "Spell ready (E)";
            useSpell();
        }
    }

    private void useSpell()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(spell, new Vector3(mousePos.x,mousePos.y,0), Quaternion.identity);
            cooldown = 15;
        }
    }

    IEnumerator countdown()
    {
        while (true)
        {
            if (cooldown > 0)
            {
                cooldown -= 1;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
