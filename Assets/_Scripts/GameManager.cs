using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;
    public static int ScorePointsOnLevel;

    private void Start()
    {
        Time.timeScale = 1;
        ScorePointsOnLevel = 0;
    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        _pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        _pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
}