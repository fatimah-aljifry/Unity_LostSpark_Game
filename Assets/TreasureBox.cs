using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public TreasureHuntManager gameManager;
    public AudioClip treasureSound;     // Sound to play when treasure is found
    private AudioSource audioSource;    // Reference to the AudioSource component

     // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.FoundBox();
            
            // Play the sound
            if (audioSource != null && treasureSound != null)
            {
                audioSource.PlayOneShot(treasureSound); // Play the sound effect
            }
           // Destroy(gameObject); // يختفي بعد اللمس
           gameObject.SetActive(false);
        }
    }
}
