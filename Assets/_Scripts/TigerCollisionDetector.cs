using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TigerCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _taskPanel;
    [SerializeField] private GameObject _allBalls;

    [SerializeField] private Image _ball_1;
    [SerializeField] private Image _ball_2;
    [SerializeField] private Sprite[] _ballSprites;

    [SerializeField] private Image[] _allBallsImages;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            RoadMovement.CanMovement = false;
            GetComponent<Animator>().enabled = false;
            StartCoroutine(ShowTask());
        }
    }

    private IEnumerator ShowTask()
    {
        SetRandomTask();
        SetRandomAllBalls();
        _taskPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        _taskPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _allBalls.SetActive(true);
    }

    private void SetRandomTask()
    {
        _ball_1.sprite = _ballSprites[Random.Range(0, _ballSprites.Length)];
        _ball_2.sprite = _ballSprites[Random.Range(0, _ballSprites.Length)];
        PlayerPrefs.SetString("selectedBall_1", _ball_1.sprite.name);
        PlayerPrefs.SetString("selectedBall_2", _ball_2.sprite.name);
    }

    private void SetRandomAllBalls()
    {
        Shuffle(_ballSprites);

        for (int i = 0; i < _allBallsImages.Length; i++)
        {
            _allBallsImages[i].sprite = _ballSprites[i];
        }
    }

    private void Shuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            T temp = array[r];
            array[r] = array[i];
            array[i] = temp;
        }
    }

    private void Update()
    {
        if (_ball_1.sprite == _ball_2.sprite)
        {
            SetRandomTask();
        }
    }
}