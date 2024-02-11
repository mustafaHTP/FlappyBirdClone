using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private AudioSource _gameOverSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        FindFirstObjectByType<UIManager>()?.InitializeUIElements();
        InitializeScene();
    }

    private void InitializeScene()
    {
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.DeactivateAllUIElements();
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.ActivateUIElement(UIType.MainMenu);
    }

    public void StartGame()
    {
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.DeactivateAllUIElements();
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.ActivateUIElement(UIType.Score);
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        SaveScore();
        Time.timeScale = 0f;

        if (!_gameOverSFX.isPlaying)
        {
            _gameOverSFX.Play();
        }
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.DeactivateAllUIElements();
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.ActivateUIElement(UIType.GameOverMenu);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        StartGame();
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.DeactivateAllUIElements();
        FindFirstObjectByType<UIManager>(FindObjectsInactive.Include)?.ActivateUIElement(UIType.MainMenu);
        SceneManager.LoadScene("MainMenuScene");
    }

    private void SaveScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        int currentScore = PlayerController.Instance.GetComponent<Scorer>().Score;

        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
