using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    private BoxCollider2D blockingCollider; //Solid collider
    private BoxCollider2D triggerCollider; //Trigger collider

    private AudioSource audioSource; //Audio for door

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        //Get both colliders
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        foreach (var collider in colliders)
        {
            if (collider.isTrigger) triggerCollider = collider;
            else blockingCollider = collider;
        }

        spriteRenderer.sprite = closedSprite; //Start closed
    }

    public void OpenDoor()
{
    isOpen = true;
    spriteRenderer.sprite = openSprite;

    //Play door opening sound
    if (audioSource != null)
        audioSource.Play();

    //Disable solid collider so player can walk into it
    if (blockingCollider != null)
        blockingCollider.enabled = false;
}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            //Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}