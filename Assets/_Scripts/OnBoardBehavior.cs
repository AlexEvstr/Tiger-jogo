using UnityEngine;

public class OnBoardBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _onBoard1Window;
    [SerializeField] private GameObject _onBoard2Window;
    [SerializeField] private GameObject _onBoard3Window;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("isOnBoardShown"))
        {
            Show1Board();
        }
    }

    public void Show1Board()
    {
        _menuWindow.SetActive(false);
        _onBoard1Window.SetActive(true);
    }

    public void Show2Board()
    {
        _onBoard1Window.SetActive(false);
        _onBoard2Window.SetActive(true);
    }

    public void Show3Board()
    {
        _onBoard2Window.SetActive(false);
        _onBoard3Window.SetActive(true);
    }

    public void Close3Board()
    {
        _onBoard3Window.SetActive(false);
        _menuWindow.SetActive(true);
        PlayerPrefs.SetInt("isOnBoardShown", 1);
    }
}