using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionIcon : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    public void Ready()
    {
        icon.sprite = CoreGame.core.interactionMenager.interactionButton;
    }

    public void NotReady()
    {
        icon.sprite = CoreGame.core.interactionMenager.interactionIcon;
    }

    public void showIcon(bool value)
    {
        icon.enabled = value;
    }
}
