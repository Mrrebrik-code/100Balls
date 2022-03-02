using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private Transform leftFlipper;
    [SerializeField] private Transform rightFlipper;

    public void OpenFlippers()
    {
        leftFlipper.localEulerAngles = new Vector3(leftFlipper.localEulerAngles.x, leftFlipper.localEulerAngles.y, -90.0f);
        rightFlipper.localEulerAngles = new Vector3(rightFlipper.localEulerAngles.x, rightFlipper.localEulerAngles.y, 90.0f);
    }
    public void CloseFlippers()
    {
        leftFlipper.localEulerAngles = Vector3.zero;
        rightFlipper.localEulerAngles = Vector3.zero;
    }
}
