using UnityEngine;

public class CandyCorn : MonoBehaviour
{
    private bool playerIsNear = false;

    void Update()
    {
        //Player must be nearby AND press C
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
        //Add to score
        CandyManager.Instance.AddCandy();

        //Remove candy from scene
        Destroy(gameObject);
    }
}