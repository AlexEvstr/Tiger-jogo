using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text level_text;
    public static int LevelIndex;

    private void Start()
    {
        LevelIndex = PlayerPrefs.GetInt("levelIndex", 1);
    }

    private void Update()
    {
        level_text.text = $"Level: {LevelIndex}";
    }
}