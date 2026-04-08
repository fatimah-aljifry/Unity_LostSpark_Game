using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int totalPieces = 4;
    private int correctMatches = 0;

    public GameObject moonInfoPanel;     // Info panel shown after solving
    public GameObject puzzlePanel;       // Puzzle UI that should be hidden when solved

    public void RegisterCorrectMatch()
    {
        correctMatches++;
        Debug.Log("Correct match registered: " + correctMatches);

        if (correctMatches >= totalPieces)
        {
            Debug.Log("Puzzle Solved! ✅");

            if (moonInfoPanel != null)
            {
                moonInfoPanel.SetActive(true);  // show info panel
            }

            if (puzzlePanel != null)
            {
                puzzlePanel.SetActive(false);   // hide puzzle panel
            }
        }
    }

    // Optional: reset method if you want to replay later
    public void ResetPuzzle()
    {
        correctMatches = 0;
        moonInfoPanel.SetActive(false);
        puzzlePanel.SetActive(true);
    }
}
