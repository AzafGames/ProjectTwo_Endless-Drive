using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Score UI
    [SerializeField] private TextMeshProUGUI scoreText;

    // Game over UI
    [SerializeField] private TextMeshProUGUI gameOverText;

    // Game buttons
    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    // Game state
    public static bool isStartButtonClicked;
    public static bool isPauseButtonClicked;
    public static bool isRestartButtonClicked;

    private void Awake()
    {
        // Pause game at start
        Time.timeScale = 0f;

        // Reset states
        isStartButtonClicked = false;
        isPauseButtonClicked = false;
        isRestartButtonClicked = false;

        // Show start UI
        scoreText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        // Hide other UI
        gameOverText.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Show initial score
        UpdateScoreUI();
    }

    private void Update()
    {
        // Update score
        UpdateScoreUI();

        // Check game over
        if (collisionChecker.isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(true);
        }
    }

    // Update score text
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + collisionChecker.score;
    }

    // Start game
    public void StartGame()
    {
        isStartButtonClicked = true;
        isPauseButtonClicked = false;
        isRestartButtonClicked = false;

        Time.timeScale = 1f;

        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Pause game
    public void PauseGame()
    {
        isPauseButtonClicked = true;

        Time.timeScale = 0f;

        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Resume game
    public void ResumeGame()
    {
        isPauseButtonClicked = false;

        Time.timeScale = 1f;

        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(false);
    }

    // Restart game
    public void RestartGame()
    {
        isRestartButtonClicked = true;

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Exit game
    public void ExitGame()
    {
        Application.Quit();
    }
}