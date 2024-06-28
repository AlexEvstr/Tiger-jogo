using System.Collections;
using UnityEngine;

public class TigerJump : MonoBehaviour
{
    private GameObject _tiger;
    private float[] _xPositions = { -1.7f, 1.7f };
    private float moveDuration = 0.5f;
    //private float moveDurationX = 0.5f;
    //private float moveDurationY = 0.5f;
    private Vector2 endPositionX;

    private void Start()
    {
        _tiger = GameObject.FindGameObjectWithTag("Tiger");
    }

    public void MoveTiger()
    {
        _tiger.GetComponent<Animator>().enabled = true;
        StartCoroutine(MoveTigerSmoothly());
    }

    IEnumerator MoveTigerSmoothly()
    {
        if (_tiger.transform.position.x == 0)
        {
            endPositionX = new Vector2(_xPositions[Random.Range(0, _xPositions.Length)], _tiger.transform.position.y);
        }
        else
        {
            endPositionX = new Vector2(0, _tiger.transform.position.y);
        }

        Vector2 startPosition = _tiger.transform.position;
        
        Vector2 endPositionY = new Vector2(_tiger.transform.position.x, -2.25f);
        Vector2 returnPositionY = new Vector2(_tiger.transform.position.x, startPosition.y);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            float tY = t * 2; // Ускоряем движение по оси Y

            if (tY <= 1f)
            {
                _tiger.transform.position = new Vector2(
                    Mathf.Lerp(startPosition.x, endPositionX.x, t),
                    Mathf.Lerp(startPosition.y, endPositionY.y, tY)
                );
            }
            else
            {
                _tiger.transform.position = new Vector2(
                    Mathf.Lerp(startPosition.x, endPositionX.x, t),
                    Mathf.Lerp(endPositionY.y, returnPositionY.y, tY - 1f)
                );
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _tiger.transform.position = new Vector2(endPositionX.x, returnPositionY.y);
    }
}