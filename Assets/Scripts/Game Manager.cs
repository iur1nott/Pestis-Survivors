using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime;
    public bool gameActive;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        gameActive = true;
    }
    void Update()
    {   if (gameActive)
        {
        gameTime += Time.deltaTime;
        UiController.Instance.UpdateTimer(gameTime);
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
        
    }

    public void GameOver()
    {
        gameActive = false;
        UiController.Instance.gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameOn");
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void Pause()
    {
        if (UiController.Instance.pausePanel.activeSelf == false && UiController.Instance.gameOverPanel.activeSelf == false)
        {
            UiController.Instance.pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            UiController.Instance.pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
