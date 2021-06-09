using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _x, _z;
    private bool _isGrounded;

    private Vector3 _velocity;

    public float _speed;
    public float _gravity;
    public float _groundDistance;

    public LayerMask groundMask;
    public CharacterController controller;
    public Transform groundCheck;


    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);

        _velocity.y += _gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
            Movement();
        }
        
    }

    private void Movement()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _x + transform.forward * _z;

        controller.Move(_move * _speed * Time.deltaTime);

    }
}
