using UnityEngine;

public class SupportWindow : MonoBehaviour
{
    [SerializeField] private UniWebView webView;
    private string _url = "https://annabelshaw.durablesites.com/?pt=NjY4MmE1ZDNlNGYzMTQ3MDA2ZjkxNmQ2OjE3MTk4Mzg4MTIuMDY6cHJldmlldw==";

    void Start()
    {
        webView.OnShouldClose += OnShouldClose;
        webView.Load(_url);
    }

    private bool OnShouldClose(UniWebView webView)
    {
        return false;
    }

    private void OnDestroy()
    {
        if (webView != null)
        {
            webView.OnShouldClose -= OnShouldClose;
        }
    }
}