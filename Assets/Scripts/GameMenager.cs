using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [HideInInspector]
    public Transform playerTransform;

    public void PlayerRegister(Transform t)
    {
        playerTransform = t;
    }

    public float GetDistance(Vector3 pos)
    {
        return Vector3.Distance(playerTransform.position, pos);
    }
}
