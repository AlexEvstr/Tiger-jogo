using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBallButton : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _allBallsPanel;

    [SerializeField] TigerJump _tigerJump;

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
            }
        }
        else
        {
            _losePanel.SetActive(true);
            GameManager.ScorePointsOnLevel = 0;
        }
    }

    //private void MoveTiger()
    //{
    //    _tiger.GetComponent<Animator>().enabled = true;

    //    if (_tiger.transform.position.x == 0)
    //    {
    //        _tiger.transform.position = new Vector2(_xPositions[Random.Range(0, _xPositions.Length)], _tiger.transform.position.y);
    //    }
    //    else
    //    {
    //        _tiger.transform.position = new Vector2(0, _tiger.transform.position.y);
    //    }
    //}

    
}