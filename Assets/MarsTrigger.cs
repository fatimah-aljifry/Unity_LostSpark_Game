using UnityEngine;
using UnityEngine.UI;
using TMPro; // مهم عشان نستخدم TMP_Text


public class MarsTrigger : MonoBehaviour
{
    public GameObject questionPanel;       // Panel فيه السؤال
    public GameObject infoPanel;           // Panel فيه المعلومة
    public TMP_Text infoText;              // النص اللي يعرض المعلومة
    public GameObject continueButton;      // زر الاستمرار (جوه Panel المعلومة)
    public AudioClip correctSound;     // 🟡 اسمه في Inspector
    private AudioSource audioSource;   // 🎵 لتشغيل الصوت

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // ✅ ربط AudioSource
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mars"))
        {
            questionPanel.SetActive(true); // عرض سؤال عند التصادم
            Time.timeScale = 0f;           // توقف اللعبة مؤقتًا
        }
    }

    public void AnswerCorrect()
    {
        questionPanel.SetActive(false); // نخفي السؤال
        infoPanel.SetActive(true);      // نظهر المعلومة
        infoText.text = "Did you know?\n\n" +
            "Sunsets on Mars appear blue, not orange like on Earth!" +
            " \nThis happens because the dust in Mars' " +
            "atmosphere scatters sunlight in a way that makes " +
            "the sky look blue during sunset.";
      

        audioSource.PlayOneShot(correctSound);

    }

    public void AnswerWrong()
    {
        infoText.text = "إجابة خاطئة! حاول مرة ثانية.";
    }

    public void ContinueGame()
    {
        infoPanel.SetActive(false);     // نخفي المعلومة
        Time.timeScale = 1f;            // نرجّع حركة اللعبة
        audioSource.PlayOneShot(correctSound);
    }

}
