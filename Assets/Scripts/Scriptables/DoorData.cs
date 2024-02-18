using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Scriptable/Door", order = 1)]
public class DoorData : ScriptableObject
{
    public bool isLocked;
    public ItemData itemRequired;
    public bool isLockedOtherSide;
}
