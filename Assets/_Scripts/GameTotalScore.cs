using UnityEngine;

public class GameTotalScore : MonoBehaviour
{
    public static int TotalScore;

    private void Start()
    {
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);    
    }
}
