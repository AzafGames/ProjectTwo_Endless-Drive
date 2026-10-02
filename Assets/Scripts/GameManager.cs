using UnityEngine;
using TMPro; // Required for using TextMeshPro UI elements

public class GameManager : MonoBehaviour
{
    // Reference to the collisionChecker script to access the current score
    public collisionChecker collisionChecker;

    // Reference to the TextMeshPro UI element that displays the score on screen
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update the UI text to reflect the current score from collisionChecker
        scoreText.text = "Score: " + collisionChecker.score;
    }
}