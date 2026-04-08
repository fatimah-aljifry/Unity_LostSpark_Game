using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public GameObject puzzleUIPanel; // Assign this in Unity

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleUIPanel.SetActive(true); // Show the UI
            Time.timeScale = 0f; // Pause the game while solving
        }
    }
}