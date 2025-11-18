using UnityEngine;

public class CandyCorn : MonoBehaviour
{
    private bool playerIsNear = false;
    public AudioClip pickupSound;       
    private AudioSource audioSource;     

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // link AudioSource
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.C))
        {
            CollectCandy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }

    void CollectCandy()
    {
        // play sound
        audioSource.PlayOneShot(pickupSound);

        // add to score
        CandyManager.Instance.AddCandy();

        // destroy candy AFTER sound finishes
        Destroy(gameObject, pickupSound.length);
    }
}
