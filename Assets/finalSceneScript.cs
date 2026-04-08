using UnityEngine;
using UnityEngine.SceneManagement;

public class finalSceneScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with chest has the tag "Star"
        if (other.CompareTag("Player"))
        {
            // Load  scene
            SceneManager.LoadScene("finalScene");
        }
    }
}


