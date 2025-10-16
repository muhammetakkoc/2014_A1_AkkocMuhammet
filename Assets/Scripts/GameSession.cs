using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static GameSession instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI timerText;  

    [Header("Game Rules")]
    public float roundDuration = 30f;   
    

    private int killCount = 0;
    private float timeLeft;

    void Awake()
    {
        instance = this;        
    }

    void Start()
    {
        timeLeft = roundDuration;
        UpdateScoreUI();
        UpdateTimerUI();
    }

    void Update()
    {
        
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0f) timeLeft = 0f;
        UpdateTimerUI();

        if (timeLeft <= 0f && killCount <5)
        {
            
            SceneManager.LoadScene(2);
        }
        if(timeLeft <= 0f && killCount >= 5)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void AddEnemyKill()
    {
        killCount++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText) scoreText.text = "Enemies Destroyed: " + killCount;
    }

    void UpdateTimerUI()
    {
        if (!timerText) return;
        int sec = Mathf.CeilToInt(timeLeft);
        
        timerText.text = $"00:{sec:00}";
    }
}
