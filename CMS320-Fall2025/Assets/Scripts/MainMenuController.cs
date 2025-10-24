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
        SceneManager.LoadScene("Level1");
    }
}