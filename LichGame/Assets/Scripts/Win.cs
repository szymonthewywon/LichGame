using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene("Win");
    }
}
