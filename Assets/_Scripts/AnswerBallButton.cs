using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBallButton : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _allBallsPanel;

    [SerializeField] TigerJump _tigerJump;
    [SerializeField] LevelCompletedBeavior _levelCompletedBeavior;

    private void Start()
    {
        
    }

    public void ChooseAnswer()
    {
        string firstBall = PlayerPrefs.GetString("selectedBall_1", "ball_0");
        string secondBall = PlayerPrefs.GetString("selectedBall_2", "ball_1");
        if (firstBall == GetComponent<Image>().sprite.name || secondBall == GetComponent<Image>().sprite.name)
        {
            GameManager.ScorePointsOnLevel++;

            if (GameManager.ScorePointsOnLevel == 2)
            {
                RoadMovement.CanMovement = true;

                _tigerJump.MoveTiger();
                StonesSpawner.CanSpawnStone = true;
                _allBallsPanel.SetActive(false);
                GameManager.ScorePointsOnLevel = 0;
                LevelCounter.LevelIndex++;
                if (LevelCounter.LevelIndex % 5 == 0)
                {
                    _levelCompletedBeavior.ShowPlus200();
                }
                else
                {
                    _levelCompletedBeavior.ShowPlus100();
                }
                PlayerPrefs.SetInt("levelIndex", LevelCounter.LevelIndex);
            }
        }
        else
        {
            _losePanel.SetActive(true);
            GameManager.ScorePointsOnLevel = 0;
        }
    }
}