using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGalaxyScene()
    {
        SceneManager.LoadScene("SampleScene"); // Use the actual scene name
    }
}