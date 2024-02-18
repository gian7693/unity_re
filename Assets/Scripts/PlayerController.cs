using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    private Transform _mCamera;

    private float _moveSpeed;
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _runningSpeed;
    [SerializeField]
    private float _isRunning;
    private float _currentRunningVelocity;

    [SerializeField]
    private float rotateSpeed;
    private float rotateRefSpeed;
    private float smoothRotationSpeed = 0.1f;

    private bool _isWalking;
    private bool _isAiming;

    // Start is called before the first frame update
    void Start()
    {
        _mCamera = Camera.main.transform;
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        _moveSpeed = _walkSpeed;
        InputMenager.Instance.control.Input.LeftShoulder.started += OnLeftShoulder;
        InputMenager.Instance.control.Input.LeftShoulder.canceled += OnLeftShoulder;

        CoreGame.core.gameMenager.PlayerRegister(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        HandleMoveSpeed();
    }

    private void MoveCharacter()
    {
        Vector3 moveDirection = transform.TransformDirection(InputMenager.Instance.GetAxis());

        _isWalking = InputMenager.Instance.GetAxis().magnitude != 0f;

        if (_isWalking)
        {
            // Define a rotação do personagem para que seja o mesmo da camera
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _mCamera.eulerAngles.y, ref rotateRefSpeed, smoothRotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime);
        }

        _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
        _controller.Move(Vector3.down * 2 * Time.deltaTime);

        _animator.SetFloat("moveX", InputMenager.Instance.GetAxis().x, 0.15f, Time.deltaTime);
        _animator.SetFloat("moveY", InputMenager.Instance.GetAxis().z, 0.15f, Time.deltaTime);
        _animator.SetFloat("running", _isRunning, 0.2f, Time.deltaTime);
    }

    private void HandleMoveSpeed()
    {
        if(_isRunning == 1)
        {
            _moveSpeed = Mathf.SmoothDamp(_moveSpeed, _runningSpeed, ref _currentRunningVelocity, 0.2f);
        }
        else
        {
            _moveSpeed = Mathf.SmoothDamp(_moveSpeed, _walkSpeed, ref _currentRunningVelocity, 0.2f);
        }
    }

    #region INPUT

    private void OnLeftShoulder(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            _isRunning = 1f;
        }

        if (value.canceled)
        {
            _isRunning = 0f;
        }
    }

    #endregion
}
