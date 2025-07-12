
using UnityEngine;

public class FinalZoom : MonoBehaviour
{
    public Camera mainCamera; // MainCamera gameObject. Using another camera is also an option but there is no point in this case
    public Transform zoomTarget;    // Assign the object to zoom into
    public float targetSize = 3f;   // How much to zoom in (smaller = closer)
    public float zoomSpeed = 2f;    // Speed of zooming

    private float originalSize;
    private bool zooming = false;
    public float threshold = 0.01f;
    public AudioSource audioSource;
    public AudioClip zoomSound;

    public GameObject WorldCanvas;
    public GameObject CameraCanvas;
    public bool showWorldCanvasAfterZoom = true;
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalSize = mainCamera.orthographicSize;

        WorldCanvas.SetActive(true);
        CameraCanvas.SetActive(false);
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

            bool sizeClose = Mathf.Abs(mainCamera.orthographicSize - targetSize) < threshold;
            bool posClose = Vector3.Distance(mainCamera.transform.position, newPos) < threshold;

            if (sizeClose && posClose)
            {
                zooming = false;
                SwitchAfterZoom(false);
            }
        }
    }

    // Call this to start zooming + sound effect
    public void StartZoom()
    {
        if (audioSource != null && zoomSound != null)
        {
            audioSource.PlayOneShot(zoomSound);
        }
        else
        {
            Debug.Log("Audio source or zoom sound are unassigned!");
        }
        //zooming is like a curse bro i swear to god
        zooming = true;
    }

    // Call this to reset zoom
    public void ResetZoom()
    {
        zooming = false;
        mainCamera.orthographicSize = originalSize;
    }

    void SwitchAfterZoom(bool showFirstCanvas)
    {
        if (showFirstCanvas)
        {
            showWorldCanvas();
        }
        else
        {
            showCameraCanvas();
        }
    }
    void showWorldCanvas()
    {
        WorldCanvas.SetActive(true);
        CameraCanvas.SetActive(false);
    }

    void showCameraCanvas()
    {
        WorldCanvas.SetActive(false);
        CameraCanvas.SetActive(true);
    }
}