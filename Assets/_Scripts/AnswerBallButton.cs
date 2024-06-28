using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBallButton : MonoBehaviour
{
    public void ChooseAnswer()
    {
        string firstBall = PlayerPrefs.GetString("selectedBall_1", "ball_0");
        string secondBall = PlayerPrefs.GetString("selectedBall_2", "ball_1");
        if (firstBall == GetComponent<Image>().sprite.name || secondBall == GetComponent<Image>().sprite.name)
        {
            Debug.Log(true);
        }
        else
        {
            Debug.Log(false);
        }
    }
}
