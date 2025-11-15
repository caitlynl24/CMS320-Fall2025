using UnityEngine;
using TMPro;

public class CandyManager : MonoBehaviour
{
    public static CandyManager Instance; // Singleton for easy access
    public int candyCount = 0;
    public TextMeshProUGUI candyText;

    void Awake()
    {
        // Simple Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCandy()
    {
        candyCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        candyText.text = "Candy: " + candyCount;
    }
}