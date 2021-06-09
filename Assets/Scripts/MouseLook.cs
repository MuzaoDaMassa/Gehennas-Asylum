using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float _mouseSensitivity = 100f;

    public Transform playerBody;

    private float _mouseX, _mouseY;
    private float _xRotation = 0f;

    // Update is called once per frame
    void Update()
    {
         _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
         _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
