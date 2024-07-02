using UnityEngine;

public class GameSkinGetter : MonoBehaviour
{
    [SerializeField] private GameObject[] _tigers;

    [SerializeField] private SpriteRenderer[] _roads;
    [SerializeField] private Sprite[] _roadsSprites;

    private void Awake()
    {
        int tigerIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        _tigers[tigerIndex].SetActive(true);

        int roadIndex = PlayerPrefs.GetInt("SelectedSkinRoad", 0);
        foreach (var item in _roads)
        {
            item.sprite = _roadsSprites[roadIndex];
        }
    }
}