using UnityEngine;
using UnityEngine.UI;

public class MercuryPanelSwitcher : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject infoPanel;
    public Button closeButton;
    public AudioSource correctSound;
    public PlayerMovement playerMovement; // 👈 Specific to your PlayerMovement script

    void Start()
    {
        infoPanel.SetActive(false);
        closeButton.onClick.AddListener(CloseInfoPanel);
    }

    public void ShowInfoPanel()
    {
        puzzlePanel.SetActive(false);
        infoPanel.SetActive(true);

        if (correctSound != null)
        {
            correctSound.Play();
        }

        Time.timeScale = 0f; // Pause the game
    }

    void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
