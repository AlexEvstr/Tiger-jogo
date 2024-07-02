using UnityEngine;

public class MenuEffects : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip purchaseSound;
    private AudioSource soundPlayer;
    public static bool isVibrationActive;

    [SerializeField] private GameObject soundOnIcon;
    [SerializeField] private GameObject soundOffIcon;
    [SerializeField] private GameObject vibrationOnIcon;
    [SerializeField] private GameObject vibrationOffIcon;

    private void Awake()
    {
        Vibration.Init();
        soundPlayer = GetComponent<AudioSource>();

        int vibrationState = PlayerPrefs.GetInt("vibrationState", 1);
        isVibrationActive = vibrationState == 1;

        int soundState = PlayerPrefs.GetInt("soundState", 1);
        if (soundState == 1)
            ActivateSound();
        else
            DeactivateSound();
    }

    public void PlayClickSound()
    {
        soundPlayer.PlayOneShot(clickSound);
        if (isVibrationActive)
            Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
    }

    public void PlayPurchaseSound()
    {
        soundPlayer.PlayOneShot(purchaseSound);
        if (isVibrationActive)
            Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
    }

    public void DeactivateSound()
    {
        soundOnIcon.SetActive(false);
        soundOffIcon.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("soundState", 0);
    }

    public void ActivateSound()
    {
        soundOffIcon.SetActive(false);
        soundOnIcon.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("soundState", 1);
    }

    public void DeactivateVibration()
    {
        vibrationOnIcon.SetActive(false);
        vibrationOffIcon.SetActive(true);
        isVibrationActive = false;
        PlayerPrefs.SetInt("vibrationState", 0);
    }

    public void ActivateVibration()
    {
        vibrationOffIcon.SetActive(false);
        vibrationOnIcon.SetActive(true);
        isVibrationActive = true;
        PlayerPrefs.SetInt("vibrationState", 1);
    }
}
