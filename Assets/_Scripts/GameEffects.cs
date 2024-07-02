using UnityEngine;

public class GameEffects : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip correctSound;

    private AudioSource soundPlayer;
    public static bool vibrationActive;

    private void Awake()
    {
        Vibration.Init();
        int vibrationPreference = PlayerPrefs.GetInt("vibrationState", 1);
        vibrationActive = vibrationPreference == 1;
        soundPlayer = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        soundPlayer.PlayOneShot(clickSound);
        if (vibrationActive)
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
        }
    }

    public void PlayJumpSound()
    {
        soundPlayer.PlayOneShot(jumpSound);
        if (vibrationActive)
        {
            Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
        }
    }

    public void PlayLoseSound()
    {
        soundPlayer.PlayOneShot(loseSound);
        if (vibrationActive)
        {
            Vibration.Vibrate();
        }
    }

    public void PlayCorrectSound()
    {
        soundPlayer.PlayOneShot(correctSound);
        if (vibrationActive)
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        }
    }
}