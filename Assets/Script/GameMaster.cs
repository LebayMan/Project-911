using UnityEngine;
using TMPro; // If you're using TextMeshPro

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instances;

    public int score = 0;
    public TextMeshProUGUI scoreText; // Assign in Inspector

    void Awake()
    {
        // Singleton pattern to allow global access
        if (Instances == null)
        {
            Instances = this;
            DontDestroyOnLoad(gameObject); // Optional: persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
