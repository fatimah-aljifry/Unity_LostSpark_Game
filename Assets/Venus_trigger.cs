using UnityEngine;
using UnityEngine.SceneManagement;

public class VenusCollisionTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with Venus has the tag "Star"
        if (other.CompareTag("Player"))
        {
            // Load the Venus_Terrain scene
            SceneManager.LoadScene("Venus_Terain");
        }
    }
}

