using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private Transform leftFlipper;
    [SerializeField] private Transform rightFlipper;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenFlippers();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CloseFlippers();
        }
    }
    private void OpenFlippers()
    {
        leftFlipper.localEulerAngles = new Vector3(leftFlipper.localEulerAngles.x, leftFlipper.localEulerAngles.y, -90.0f);
        rightFlipper.localEulerAngles = new Vector3(rightFlipper.localEulerAngles.x, rightFlipper.localEulerAngles.y, 90.0f);
    }
    private void CloseFlippers()
    {
        leftFlipper.localEulerAngles = Vector3.zero;
        rightFlipper.localEulerAngles = Vector3.zero;
    }
}