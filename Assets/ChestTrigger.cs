using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public GameObject treasurePanel;    // Panel for "You found the hidden treasure"
    public float displayDuration = 3f;  // Duration to display the panel after collision
    public AudioClip treasureSound;     // Sound to play when treasure is found
    private AudioSource audioSource;    // Reference to the AudioSource component

    private bool triggered = false;     // To ensure the panel only pops once

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // This function is triggered when something enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered is the player (tagged as "Player")
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true; // Mark as triggered to prevent the sequence from running multiple times
            treasurePanel.SetActive(true);  // Show the "treasure found" panel
            
            // Play the sound
            if (audioSource != null && treasureSound != null)
            {
                audioSource.PlayOneShot(treasureSound); // Play the sound effect
            }

            Invoke("HidePanel", displayDuration); // Hide the panel after the specified duration
        }
    }

    // Function to hide the panel
    void HidePanel()
    {
        treasurePanel.SetActive(false);
    }
}
