using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoation : MonoBehaviour
{
    /// Sensitivity for free look.
    public float freeLookSensitivity = 3f;

    private bool looking = true;

    // Update is called once per frame
    void Update()
    {
        if (looking)
        {
            float newRotationX = transform.parent.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, 0f, 0f);
            transform.parent.localEulerAngles = new Vector3(0f,newRotationX, 0f);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    /// Enable free looking.
    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// Disable free looking.
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
