using System.Collections;
using UnityEngine;
using TMPro;

public class LevelCompletedBeavior : MonoBehaviour
{
    [SerializeField] private GameObject _plus100;
    [SerializeField] private GameObject _plus200;

    public void ShowPlus100()
    {
        StartCoroutine(PlusBehavior(_plus100));
    }

    public void ShowPlus200()
    {
        StartCoroutine(PlusBehavior(_plus200));
    }

    private IEnumerator PlusBehavior(GameObject plusGameObject)
    {
        float alphaColor = 1.0f;
        plusGameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaColor);
        plusGameObject.SetActive(true);
        
        while(alphaColor > 0)
        {
            plusGameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaColor);
            alphaColor -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        plusGameObject.SetActive(false);
    }
}