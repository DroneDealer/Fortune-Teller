using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{

    public GameObject WorldCanvas;
    public GameObject CameraCanvas;
    public void ShowWorldCanvas()
    {
        WorldCanvas.SetActive(true);
        CameraCanvas.SetActive(false);
    }
    public void ShowCameraCanvas()
    {
        WorldCanvas.SetActive(false);
        CameraCanvas.SetActive(true);
    }

    public void SwitchAfterZoom(bool showFirstCanvas)
    {
        if (showFirstCanvas)
        {
            ShowWorldCanvas();
        }
        else
        {
            ShowCameraCanvas();
        }
    }
}
