using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public enum Phase { Start, Playing, GameOver }

    public static GameState Instance { get; private set; }
    public static Phase Current { get; private set; } = Phase.Start;
    public static bool IsPlaying => Current == Phase.Playing;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject hudPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverScoreText;
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;

    void Awake()
    {
        Instance = this;
        Current = Phase.Start;
        Time.timeScale = 0f;
        ApplyPanels();

        if (startButton != null) startButton.onClick.AddListener(BeginGame);
        if (restartButton != null) restartButton.onClick.AddListener(Restart);
    }

    void Update()
    {
        if (Current == Phase.Start && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            BeginGame();
        }
        else if (Current == Phase.GameOver && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            Restart();
        }
    }

    public void BeginGame()
    {
        if (Current != Phase.Start) return;
        Current = Phase.Playing;
        MasterInfo.coinCount = 0;
        Time.timeScale = 1f;
        ApplyPanels();
    }

    public void TriggerGameOver()
    {
        if (Current != Phase.Playing) return;
        Current = Phase.GameOver;
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = $"Coins: {MasterInfo.coinCount}";
        }
        ApplyPanels();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Current = Phase.Start;
        MasterInfo.coinCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ApplyPanels()
    {
        if (startPanel != null) startPanel.SetActive(Current == Phase.Start);
        if (hudPanel != null) hudPanel.SetActive(Current == Phase.Playing);
        if (gameOverPanel != null) gameOverPanel.SetActive(Current == Phase.GameOver);
    }
}
