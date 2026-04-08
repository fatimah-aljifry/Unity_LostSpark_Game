using UnityEngine;

public class MoonInfoCloser : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject infoPanel;

    void Update()
    {
        if (infoPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            CloseInfoPanel();
        }
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);     // Hide info panel
        puzzlePanel.SetActive(false);   // Hide puzzle panel
        Time.timeScale = 1f;            // Resume game if it was paused

        Debug.Log("Info closed!");
    }
}
