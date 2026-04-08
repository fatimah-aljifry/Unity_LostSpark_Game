using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{
    public float zoomOutDuration = 2f; // Duration to zoom out
    public float zoomedOutFOV = 70f; // Zoomed-out field of view
    public float normalFOV = 60f; // Normal field of view
    private Camera cameraComponent;

    void Start()
    {
        // Get the Camera component
        cameraComponent = GetComponent<Camera>();
    }

    void Update()
    {
        // Smoothly zoom out after Play is hit
        if (cameraComponent.fieldOfView < zoomedOutFOV)
        {
            cameraComponent.fieldOfView += (zoomedOutFOV - normalFOV) * (Time.deltaTime / zoomOutDuration);
        }
    }
}
