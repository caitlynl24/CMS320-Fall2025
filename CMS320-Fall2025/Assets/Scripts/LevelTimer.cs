using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public bool isCounting = true;

    public TextMeshProUGUI timerText; 
    public GameObject gameOverPanel;

    public float lowTimeThreshold = 10f;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    private bool isFlashing = false;

    void Update()
    {
        if (!isCounting) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= lowTimeThreshold && !isFlashing)
                StartCoroutine(FlashText());
        }
        else
        {
            timeRemaining = 0;
            isCounting = false;
            UpdateTimerUI();
            HandleTimesUp();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void HandleTimesUp()
    {
        Debug.Log("TIME’S UP!");

        // Show the game over UI
        gameOverPanel.SetActive(true);

        // Freeze gameplay
        Time.timeScale = 0f;
    }


    System.Collections.IEnumerator FlashText()
    {
        isFlashing = true;

        while (timeRemaining > 0 && timeRemaining <= lowTimeThreshold)
        {
            timerText.color = warningColor;
            yield return new WaitForSeconds(0.2f);

            timerText.color = normalColor;
            yield return new WaitForSeconds(0.2f);
        }

        timerText.color = normalColor;
        isFlashing = false;
    }
}
