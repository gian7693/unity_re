using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMenager : MonoBehaviour
{
    private GameObject icon;
    IInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        icon = CoreGame.core.interactionMenager.NewInteractionIcon();

        interactable = GetComponentInParent<IInteractable>();
        if(interactable != null)
        {
            interactable.SetIconMenager(icon.GetComponent<InteractionIcon>());
        }      
    }

    private void LateUpdate()
    {
        icon.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        icon.SetActive(CoreGame.core.interactionMenager.ShowIcon(transform.position));
    }
}
