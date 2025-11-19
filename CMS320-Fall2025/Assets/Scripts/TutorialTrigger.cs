using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject popup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            popup.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            popup.SetActive(false);
    }
}
