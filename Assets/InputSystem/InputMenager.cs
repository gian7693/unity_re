using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMenager : MonoBehaviour
{
    public static InputMenager Instance;

    public Controls control;

    // INPUTS
    private InputAction _axis;
    private InputAction _leftShoulder;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        control = new Controls();

        // Atribuindo os inputs de acordo com o input system (Axis, LookAt, Left Shoulder, etc)
        _axis = control.Input.Axis;
        control.Enable();
    }

    public Vector3 GetAxis()
    {
        return new Vector3(_axis.ReadValue<Vector2>().x, 0f, _axis.ReadValue<Vector2>().y);
    }

}
