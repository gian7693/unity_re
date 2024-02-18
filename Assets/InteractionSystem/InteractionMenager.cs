using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenager : MonoBehaviour
{
    public RectTransform interactionIconsPanel;
    public GameObject interactionIconPrefab;

    public float interactionShowDistance;

    public delegate void CheckInteraction();
    public event CheckInteraction NotReady;

    public Sprite interactionIcon;
    public Sprite interactionButton;

    public bool ShowIcon(Vector3 pos)
    {
        return CoreGame.core.gameMenager.GetDistance(pos) <= interactionShowDistance;
    }

    public GameObject NewInteractionIcon()
    {
        return Instantiate(interactionIconPrefab, interactionIconsPanel);
    }

    public void InteractionNotReady()
    {
        if(NotReady != null)
        {
            NotReady();
        }
    }
}
