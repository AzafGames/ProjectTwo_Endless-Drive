using UnityEngine;
using TMPro; // Required for using TextMeshPro UI elements
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Reference to the collisionChecker script to access the current score
    public collisionChecker collisionChecker;

    // Reference to the TextMeshPro UI element that displays the score on screen
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI GameOverText;

    public Button startButton;

    public static bool isStartButtonClicked = false;
    public static bool isPauseButtonClicked = false;
    public static bool isRestartButtonClicked = false;

    public Button pauseButton;

    public Button restartButton;

    public Button resumeButton;

    public Button exitButton;

    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;

        

        // Score UI
        scoreText.gameObject.SetActive(true);
        
        // Hide Game Over UI
        GameOverText.gameObject.SetActive(false);

        // Shows Start Button on Start 
        startButton.gameObject.SetActive(true);

        // Shows Exit Button on Start
        exitButton.gameObject.SetActive(true);

        // Hide Pause button
        pauseButton.gameObject.SetActive(false);

        // Hides Resume Button
        resumeButton.gameObject.SetActive(false);

        // Hide Restart button
        restartButton.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update the UI text to reflect the current score from collisionChecker
        scoreText.text = "Score: " + collisionChecker.score;

        if (collisionChecker.isGameOver == true)
        {
            // Show Game Over UI
            GameOverText.gameObject.SetActive(true);

            // Show Restart button
            restartButton.gameObject.SetActive(true);

            // Hide Pause button
            pauseButton.gameObject.SetActive(false);

            // Shows Exit button
            exitButton.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        isStartButtonClicked = true;
        isRestartButtonClicked = false;

        Time.timeScale = 1f;

        // Hide Play button
        startButton.gameObject.SetActive(false); 

        // Show Pause button
        pauseButton.gameObject.SetActive(true); 
        
        // Keep Restart hidden
        restartButton.gameObject.SetActive(false);

        // Hide Exit button
        exitButton.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isPauseButtonClicked = true;

        Time.timeScale = 0f;

        // Keep Pause button hidden
        pauseButton.gameObject.SetActive(false); 

        // Shows Resume Button
        resumeButton.gameObject.SetActive(true);

        // Restart Button Remains Hidden
        restartButton.gameObject.SetActive(false);

        // Shows Exit button
        exitButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        isPauseButtonClicked = false;

        Time.timeScale = 1f;

        // Hide Resume Button
        resumeButton.gameObject.SetActive(false);

        // Show Pause Button
        pauseButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        isRestartButtonClicked = true;
        // Make sure time is running before loading the scene
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
}