using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TreasureHuntManager : MonoBehaviour
{
    public float timeLimit = 99f;
    private float timeRemaining;

    public int totalBoxes = 5;
    private int boxesFound = 0;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI boxesLeftText;
    public Transform player;
    public Transform startPoint;

    public GameObject losePanel; // ⭐️ بانل الخسارة


    private bool gameOver = false;

    [Header("Treasure Settings")]
    public GameObject[] treasures; // ⭐️ مصفوفة الكنوز اللي راح نرجعها بعد الخسارة

    void Start()
    {
        if (FindObjectOfType<TreasureHuntManager>() != null && FindObjectOfType<TreasureHuntManager>() != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        timeRemaining = timeLimit;
        UpdateUI();
    }

    void Update()
    {
        if (gameOver) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            GameOver();
        }

        UpdateUI();
    }

    public void FoundBox()
    {
        if (gameOver) return;

        boxesFound++;
        boxesFound = Mathf.Min(boxesFound, totalBoxes); // Safety clamp

        Debug.Log($"FoundBox() called. boxesFound = {boxesFound}");

        if (boxesFound >= totalBoxes)
        {
            Debug.Log("Calling WinGame()");
            WinGame();
        }
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
        boxesLeftText.text = "Remaining: " + (totalBoxes - boxesFound).ToString();
    }

   public void GameOver()
    {
        gameOver = true;

        // Reset treasures ⭐️
        ResetTreasures();

        // Reset player position
        player.position = startPoint.position;
        player.rotation = startPoint.rotation;

        // Reset game state
        timeRemaining = timeLimit;
        boxesFound = 0;
        gameOver = false;
    }

    void WinGame()
    {
        if (gameOver) return;

        gameOver = true;
        Debug.Log($"WinGame() triggered. boxesFound = {boxesFound}, totalBoxes = {totalBoxes}");
        boxesLeftText.text = "You win!";
        StartCoroutine(LoadFinalSceneAfterDelay(3f));
    }

    IEnumerator LoadFinalSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("finalScene"); // replace if necessary
    }

    void ResetTreasures()
    {
        foreach (GameObject treasure in treasures)
        {
            if (treasure != null)
            {
                treasure.SetActive(true); // ⭐️ رجعي الكنز يبان مره ثانية
            }
        }
    }

    public void ShowLosePanel()
{
    StartCoroutine(ShowLoseAndReset());
}

private IEnumerator ShowLoseAndReset()
{
    losePanel.SetActive(true); // تظهر البانل
    yield return new WaitForSeconds(2f); // تنتظر 2 ثانية

    losePanel.SetActive(false); // تخفي البانل
    GameOver(); // تعيد اللعبة لنقطة البداية
}

}
