using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMenager : MonoBehaviour, IInteractable
{
    InteractionIcon icon;

    private Animator[] doorsAnimator;
    private bool isUnlockedSide;

    private bool isDoorOpen;
    private bool isRightSide;

    public DoorData doorData;

    private void Start()
    {
        CoreGame.core.interactionMenager.NotReady += NotReady;
        doorsAnimator = GetComponentsInChildren<Animator>();
    }

    private void OnDisable()
    {
        CoreGame.core.interactionMenager.NotReady -= NotReady;
    }

    private void FixedUpdate()
    {
        if(isDoorOpen == true)
        {
            if(CoreGame.core.doorSystemMenager.IsCloseDoor(transform.position))
            {
                foreach (Animator anim in doorsAnimator)
                {
                    anim.SetTrigger("Close");
                    isDoorOpen = false;
                    icon.showIcon(!isDoorOpen);
                }

            }
        }
    }

    private void OpenTheDoor()
    {
        foreach (Animator anim in doorsAnimator)
        {
            switch (isRightSide)
            {
                case true:
                    anim.SetTrigger("OpenLeft");
                    break;

                case false:
                    anim.SetTrigger("OpenRight");
                    break;
            }

            isDoorOpen = true;
            icon.showIcon(!isDoorOpen);
        }
    }

    private void CheckDoorIsOpen()
    {
        if(doorData.isLocked == true) // SE A PORTA ESTIVER TRANCADA
        {
            if (doorData.isLockedOtherSide)
            {
                if (isUnlockedSide)
                {
                    doorData.isLocked = false;
                    print("A PORTA FOI DESTRANCADA");
                    return;
                }
                else
                {
                    print("PORTA ESTÁ TRANCADA PELO OUTRO LADO");
                }

                return;
            }

            if (doorData.itemRequired != null)
            {
                // VERIFICA SE TEM O ITEM
                print("A PORTA ESTÁ TRANCADA, VOCÊ PRECISA DE ALGUM TIPO DE ITEM");

                return;
            }

            print("A PORTA ESTÁ TRANCADA");
        }
        else // SE A PORTA ESTIVER ABERTA
        {
            OpenTheDoor();
        }
    }

    public void Interact()
    {
        CheckDoorIsOpen();
    }

    public void NotReady()
    {
        icon.NotReady();
    }

    public void Ready()
    {
        icon.Ready();
    }

    public void SetIconMenager(InteractionIcon icon)
    {
        this.icon = icon;
    }

    public void UpdateRightSide(bool isRightSide)
    {
        this.isRightSide = isRightSide;
    }

    public void UpdateUnlockedSide(bool isUnlockedSide)
    {
        this.isUnlockedSide = isUnlockedSide;
    }
}
