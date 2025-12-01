using UnityEngine;

public class CandyCorn : MonoBehaviour
{
    private bool playerIsNear = false;

    public AudioClip pickupSound;       
    private AudioSource audioSource;  
    private SpriteRenderer spriteRenderer;   
    private Collider2D candyCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // link AudioSource
        spriteRenderer = GetComponent<SpriteRenderer>();
        candyCollider = GetComponent<Collider2D>();
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
        // Immediately hide visuals + disable collision
        spriteRenderer.enabled = false;
        candyCollider.enabled = false;
        
        // play sound
        audioSource.PlayOneShot(pickupSound);

        // add to score
        CandyManager.Instance.AddCandy();

        // destroy candy AFTER sound finishes
        Destroy(gameObject, pickupSound.length);
    }
}
