using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private DoorMenager doorMenager;

    public bool isRightSide;
    public bool isUnlockedSide;

    private void Start()
    {
        doorMenager = GetComponentInParent<DoorMenager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorMenager.UpdateRightSide(isRightSide);
            doorMenager.UpdateUnlockedSide(isUnlockedSide);
        }
    }
}
