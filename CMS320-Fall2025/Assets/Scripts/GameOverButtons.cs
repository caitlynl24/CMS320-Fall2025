using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RetryLevel()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene("HomePage"); // Replace with your home scene name
    }
}
