using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public collisionChecker collisionChecker;
    public TextMeshProUGUI scoreText;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + collisionChecker.score;
    }
}
