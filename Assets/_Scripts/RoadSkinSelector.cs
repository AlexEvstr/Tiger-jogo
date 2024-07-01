using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoadSkinSelector : MonoBehaviour
{
    [System.Serializable]
    public class Skin
    {
        public string skinName;
        public int price;
        public Button button;
        public TMP_Text buttonText;
        public TMP_Text messageText;
    }

    public Skin[] skins;
    private int playerMoney;
    [SerializeField] private TMP_Text _totalScoreText;
    [SerializeField] private TMP_Text _totalScoreTextTigers;

    private void Start()
    {
        playerMoney = PlayerPrefs.GetInt("TotalScore", 0);
        _totalScoreText.text = playerMoney.ToString();
        _totalScoreTextTigers.text = playerMoney.ToString();
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("SelectedSkinRoad")))
        {
            PlayerPrefs.SetString("SelectedSkinRoad", "0");
            PlayerPrefs.SetInt("0", 1);
        }

        foreach (var skin in skins)
        {
            if (PlayerPrefs.GetInt(skin.skinName, 0) == 1)
            {
                skin.button.onClick.AddListener(() => SelectSkin(skin.skinName));
                if (PlayerPrefs.GetString("SelectedSkinRoad") == skin.skinName)
                {
                    skin.buttonText.text = "Selected";
                    skin.button.image.color = Color.green;
                }
                else
                {
                    skin.buttonText.text = "Select";
                }
            }
            else
            {
                skin.buttonText.text = $"Buy ({skin.price})";
                skin.button.onClick.AddListener(() => BuySkin(skin));
            }
        }
    }

    private void BuySkin(Skin skin)
    {
        playerMoney = PlayerPrefs.GetInt("TotalScore", 0);
        if (playerMoney >= skin.price)
        {
            playerMoney -= skin.price;
            PlayerPrefs.SetInt("TotalScore", playerMoney);
            _totalScoreText.text = playerMoney.ToString();
            _totalScoreTextTigers.text = playerMoney.ToString();
            PlayerPrefs.SetInt(skin.skinName, 1);
            skin.buttonText.text = "Select";
            skin.button.onClick.RemoveAllListeners();
            skin.button.onClick.AddListener(() => SelectSkin(skin.skinName));
            skin.messageText.text = "";
            SelectSkin(skin.skinName);
        }
        else
        {
            StartCoroutine(ShowNoteEnoughText(skin));
        }
    }

    private IEnumerator ShowNoteEnoughText(Skin skin)
    {
        skin.messageText.text = "Not enough money!";
        yield return new WaitForSeconds(1.0f);
        skin.messageText.text = "";

    }

    private void SelectSkin(string skinName)
    {
        foreach (var skin in skins)
        {
            if (skin.skinName == skinName)
            {
                skin.button.image.color = Color.green;
                skin.buttonText.text = "Selected";
                PlayerPrefs.SetString("SelectedSkinRoad", skinName);
            }
            else if (PlayerPrefs.GetInt(skin.skinName, 0) == 1)
            {
                skin.button.image.color = Color.white;
                skin.buttonText.text = "Select";
            }
        }
    }
}
