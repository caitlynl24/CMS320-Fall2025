using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("HomePage"); // <-- put your actual scene name
    }
}
