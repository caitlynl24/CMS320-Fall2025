using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesPageController : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("HomePage");
    }
}