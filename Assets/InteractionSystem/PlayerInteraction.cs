using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Transform interactionPivot;
    public LayerMask interactionLayer;
    public float interactionRange;

    public Transform interactionTarget;

    private IInteractable _interactable;
    private Ray _ray;
    private RaycastHit hitInfo;

    private void Start()
    {
        InputMenager.Instance.control.Input.ButtonSouth.started += OnInteractionButton;
    }

    private void OnDisable()
    {
        InputMenager.Instance.control.Input.ButtonSouth.started -= OnInteractionButton;
    }

    void FindInteraction()
    {
        _ray.origin = interactionPivot.position;
        _ray.direction = interactionTarget.position - interactionPivot.position;

        Debug.DrawRay(interactionPivot.position, _ray.direction * interactionRange, Color.blue, 0.2f);

        if(Physics.Raycast(_ray, out hitInfo, interactionRange, interactionLayer))
        {
            _interactable = hitInfo.collider.GetComponentInParent<IInteractable>();

            if(_interactable != null)
            {
                _interactable.Ready();
            }
            else
            {
                CoreGame.core.interactionMenager.InteractionNotReady();
            }
        }
        else
        {
            CoreGame.core.interactionMenager.InteractionNotReady();
            _interactable = null;
        }
    }

    private void FixedUpdate()
    {
        FindInteraction();
    }

    #region INPUT

    private void OnInteractionButton(InputAction.CallbackContext value)
    {
        if(_interactable == null) { return; }

        if (value.started)
        {
            _interactable.Interact();
        }
    }

    #endregion
}
