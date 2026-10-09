using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ==============================
    // UI
    // ==============================

    // Score UI
    [SerializeField] private TextMeshProUGUI scoreText;

    // Game over UI
    [SerializeField] private TextMeshProUGUI gameOverText;

    // Health UI
    [SerializeField] private TextMeshProUGUI healthText;


    // ==============================
    // GAME BUTTONS
    // ==============================

    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;


    // ==============================
    // PLAYER
    // ==============================

    // Reference to the PlayerMovement script
    [SerializeField] private playerMovement player;


    // ==============================
    // GAME STATE
    // ==============================

    public static bool isStartButtonClicked;
    public static bool isPauseButtonClicked;
    public static bool isRestartButtonClicked;


    // ==============================
    // AWAKE
    // ==============================

    private void Awake()
    {
        // Pause game at start
        Time.timeScale = 0f;

        // Reset states
        isStartButtonClicked = false;
        isPauseButtonClicked = false;
        isRestartButtonClicked = false;


        // ==============================
        // SHOW START UI
        // ==============================

        scoreText.gameObject.SetActive(true);

        startButton.gameObject.SetActive(true);

        exitButton.gameObject.SetActive(true);


        // ==============================
        // HIDE OTHER UI
        // ==============================

        gameOverText.gameObject.SetActive(false);

        pauseButton.gameObject.SetActive(false);

        resumeButton.gameObject.SetActive(false);

        restartButton.gameObject.SetActive(false);

        leftButton.gameObject.SetActive(false);

        rightButton.gameObject.SetActive(false);


        // ==============================
        // INITIAL SCORE
        // ==============================

        UpdateScoreUI();

        UpdateHealthUI();
    }


    // ==============================
    // UPDATE
    // ==============================

    private void Update()
    {
        // Update score
        UpdateScoreUI();

        // Update health
        UpdateHealthUI();


        // ==============================
        // GAME OVER
        // ==============================

        if (collisionChecker.isGameOver)
        {
            gameOverText.gameObject.SetActive(true);

            restartButton.gameObject.SetActive(true);

            pauseButton.gameObject.SetActive(false);

            resumeButton.gameObject.SetActive(false);

            exitButton.gameObject.SetActive(true);

            // Hide movement buttons
            leftButton.gameObject.SetActive(false);

            rightButton.gameObject.SetActive(false);
        }
    }


    // ==============================
    // SCORE UI
    // ==============================

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + collisionChecker.score;
    }


    // ==============================
    // HEALTH UI
    // ==============================

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + collisionChecker.Carhealth + "%";
    }


    // ==============================
    // START GAME
    // ==============================

    public void StartGame()
    {
        isStartButtonClicked = true;

        isPauseButtonClicked = false;

        isRestartButtonClicked = false;


        // Start game
        Time.timeScale = 1f;


        // ==============================
        // UPDATE BUTTON VISIBILITY
        // ==============================

        startButton.gameObject.SetActive(false);

        pauseButton.gameObject.SetActive(true);

        restartButton.gameObject.SetActive(false);

        exitButton.gameObject.SetActive(false);


        // Show movement buttons
        leftButton.gameObject.SetActive(true);

        rightButton.gameObject.SetActive(true);
    }


    // ==============================
    // LEFT BUTTON
    // ==============================

    public void LeftButton()
    {
        // Tell PlayerMovement to move left
        player.MoveLeft();
    }


    // ==============================
    // RIGHT BUTTON
    // ==============================

    public void RightButton()
    {
        // Tell PlayerMovement to move right
        player.MoveRight();
    }


    // ==============================
    // STOP MOVEMENT
    // ==============================

    public void StopButton()
    {
        // Tell PlayerMovement to stop
        player.StopMoving();
    }


    // ==============================
    // PAUSE GAME
    // ==============================

    public void PauseGame()
    {
        isPauseButtonClicked = true;


        // Pause game
        Time.timeScale = 0f;


        // Update UI
        pauseButton.gameObject.SetActive(false);

        resumeButton.gameObject.SetActive(true);

        restartButton.gameObject.SetActive(false);

        exitButton.gameObject.SetActive(false);


        // Stop player UI movement
        player.StopMoving();
    }


    // ==============================
    // RESUME GAME
    // ==============================

    public void ResumeGame()
    {
        isPauseButtonClicked = false;


        // Resume game
        Time.timeScale = 1f;


        // Update UI
        resumeButton.gameObject.SetActive(false);

        pauseButton.gameObject.SetActive(true);

        exitButton.gameObject.SetActive(false);
    }


    // ==============================
    // RESTART GAME
    // ==============================

    public void RestartGame()
    {
        isRestartButtonClicked = true;


        // Make sure time is running before loading scene
        Time.timeScale = 1f;


        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // ==============================
    // EXIT GAME
    // ==============================

    public void ExitGame()
    {
        Application.Quit();
    }
}