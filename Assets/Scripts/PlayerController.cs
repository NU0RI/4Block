using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float _fallVelocity = 0;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private Vector3 _moveVector;

    [SerializeField] private Animator animator;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jumpForce;

    [SerializeField] private float speed;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    void Update()
    {
        MovmentUpdate();
        JumpUpdate();
    }

    private void MovmentUpdate()
    {
        _moveVector = Vector3.zero;
        //var runDirection = 0;

        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0; 

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += cameraForward;
            //runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= cameraForward;
            //runDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += mainCamera.transform.right;
            //runDirection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= mainCamera.transform.right;
            //runDirection = 4;
        }

        //animator.SetInteger("Run Direction", runDirection);
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
                _fallVelocity = -jumpForce;
        }
    }
}
