using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystemMenager : MonoBehaviour
{
    public float closeDoorDistance;

    public bool IsCloseDoor(Vector3 pos)
    {
        return CoreGame.core.gameMenager.GetDistance(pos) >= closeDoorDistance;
    }
}
