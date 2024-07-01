using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _tigersShop;
    [SerializeField] private GameObject _roadsShop;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenSettings()
    {
        _menuPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }

    public void OpenShop()
    {
        _menuPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        _shopPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }

    public void OpenTigersShop()
    {
        _shopPanel.SetActive(false);
        _tigersShop.SetActive(true);
    }

    public void CloseTigersShop()
    {
        _tigersShop.SetActive(false);
        _shopPanel.SetActive(true);
    }

    public void OpenRoadsShop()
    {
        _shopPanel.SetActive(false);
        _roadsShop.SetActive(true);
    }

    public void CloseRoadsShop()
    {
        _roadsShop.SetActive(false);
        _shopPanel.SetActive(true);
    }

}
