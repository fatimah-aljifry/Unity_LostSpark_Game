using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SunTrigger : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject infoPanel;
    public TMP_Text infoText;
    public GameObject continueButton;
    public AudioClip correctSound;     // 🟡 اسمه في Inspector
    private AudioSource audioSource;   // 🎵 لتشغيل الصوت


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // ✅ ربط AudioSource
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sun"))
        {
            questionPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AnswerCorrect()
    {
        questionPanel.SetActive(false);
        infoPanel.SetActive(true);
        infoText.text = "  Did you know?\n\n" +
            "The Sun is actually white in color, but " +
            "it appears yellow to us because Earth's " +
            "atmosphere scatters its light.\r\nThis scattering" +
            " effect is the same reason we see rainbows after it rains! ";
        audioSource.PlayOneShot(correctSound);

    }

    public void AnswerWrong()
    {
        infoText.text = "إجابة خاطئة! حاول مرة أخرى.";
    }

    public void ContinueGame()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1f;
        audioSource.PlayOneShot(correctSound);

    }
}