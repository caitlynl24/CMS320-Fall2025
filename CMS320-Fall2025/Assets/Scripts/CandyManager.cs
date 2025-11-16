using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CandyManager : MonoBehaviour
{
    public static CandyManager Instance; // Singleton for easy access
    public int candyCount = 0;
    public int totalCandy = 0;
    public TextMeshProUGUI candyText;
    public DoorController door; // Reference to door

    void Awake()
    {
        // Simple Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        totalCandy = FindObjectsByType<CandyCorn>(FindObjectsSortMode.None).Length;
        UpdateUI();
    }

    public void AddCandy()
    {
        candyCount++;
        UpdateUI();

        // If all candy collected, tell the door to open
        if (candyCount >= totalCandy)
        {
            door.OpenDoor();
        }
    }

    void UpdateUI()
    {
        candyText.text = "Candy: " + candyCount + " / " + totalCandy;
    }
}