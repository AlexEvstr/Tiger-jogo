using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
}