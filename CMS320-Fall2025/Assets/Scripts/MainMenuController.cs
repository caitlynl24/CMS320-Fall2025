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
        SceneManager.LoadScene("Tutorial"); //should we add seperate tutorial and level 1 buttons?
    }
}