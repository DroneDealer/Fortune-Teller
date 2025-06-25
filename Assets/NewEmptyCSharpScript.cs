using UnityEngine;

public class SimpleZoom : MonoBehaviour
{
    public Camera mainCamera;       // Assign your main camera in Inspector
    public Transform zoomTarget;    // Assign the object to zoom into
    public float targetSize = 3f;   // How much to zoom in (smaller = closer)
    public float zoomSpeed = 2f;    // Speed of zooming

    private float originalSize;
    private bool zooming = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalSize = mainCamera.orthographicSize;
    }

    void Update()
    {
        if (zooming)
        {
            // Smoothly zoom the camera size
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);

            // Smoothly move camera toward the target's position (keep z same)
            Vector3 newPos = new Vector3(zoomTarget.position.x, zoomTarget.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPos, Time.deltaTime * zoomSpeed);
        }
    }

    // Call this to start zooming
    public void StartZoom()
    {
        zooming = true;
    }

    // Call this to reset zoom
    public void ResetZoom()
    {
        zooming = false;
        mainCamera.orthographicSize = originalSize;
    }
}
