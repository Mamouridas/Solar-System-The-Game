using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// Keys:
///	wasd / arrows	- movement
///	q/e 			- up/down
///	hold shift		- enable fast movement mode
///	u/l  	        - enable/disable free look
///	mouse			- free look / rotation
public class CameraMovement : MonoBehaviour
{
    /// Normal speed of camera movement.
    public float movementSpeed = 10f;

    /// Speed of camera movement when shift is held down,
    public float fastMovementSpeed = 100f;

    void Update()
    {
        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (Camera.main.transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-Camera.main.transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }

        if(System.Array.IndexOf(Physics.OverlapSphere(new Vector3(0, 0, 0), 650), GetComponent<Collider>()) < 0){
            transform.position = transform.GetChild(0).GetComponent<MeteroGenerate>().spawnPoint;
            transform.rotation = transform.GetChild(0).GetComponent<MeteroGenerate>().spawnRotation;
        }
    }
}