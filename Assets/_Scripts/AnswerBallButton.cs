using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBallButton : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _allBallsPanel;

    [SerializeField] TigerJump _tigerJump;
    [SerializeField] LevelCompletedBeavior _levelCompletedBeavior;
    [SerializeField] private GameEffects _gameEffects;

    public void ChooseAnswer()
    {
        string firstBall = PlayerPrefs.GetString("selectedBall_1", "ball_0");
        string secondBall = PlayerPrefs.GetString("selectedBall_2", "ball_1");
        if (firstBall == GetComponent<Image>().sprite.name || secondBall == GetComponent<Image>().sprite.name)
        {
            GameManager.ScorePointsOnLevel++;
            _gameEffects.PlayCorrectSound();



            if (GameManager.ScorePointsOnLevel == 2)
            {
                RoadMovement.CanMovement = true;

                _tigerJump.MoveTiger();
                _gameEffects.PlayJumpSound();
                StonesSpawner.CanSpawnStone = true;
                _allBallsPanel.SetActive(false);
                GameManager.ScorePointsOnLevel = 0;
                LevelCounter.LevelIndex++;
                if (LevelCounter.LevelIndex % 5 == 0)
                {
                    _levelCompletedBeavior.ShowPlus200();
                    GameTotalScore.TotalScore += 200;   
                }
                else
                {
                    _levelCompletedBeavior.ShowPlus100();
                    GameTotalScore.TotalScore += 100;
                }

                PlayerPrefs.SetInt("TotalScore", GameTotalScore.TotalScore);
                PlayerPrefs.SetInt("levelIndex", LevelCounter.LevelIndex);
                
            }
            gameObject.SetActive(false);
        }
        else
        {
            _losePanel.SetActive(true);
            _gameEffects.PlayLoseSound();
            GameManager.ScorePointsOnLevel = 0;
        }
        
    }
}