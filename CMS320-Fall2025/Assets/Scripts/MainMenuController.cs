using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnRulesButtonClicked()
    {
        SceneManager.LoadScene("RulesPage");
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked - Scene not implemented yet.");
    }
}