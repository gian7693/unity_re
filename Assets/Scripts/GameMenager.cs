using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GamePlay, Inventory
}

public class GameMenager : MonoBehaviour
{
    [HideInInspector]
    public Transform playerTransform;

    private GameState currentGameState;

    public void PlayerRegister(Transform t)
    {
        playerTransform = t;
    }

    public float GetDistance(Vector3 pos)
    {
        return Vector3.Distance(playerTransform.position, pos);
    }

    public GameState GetGameState()
    {
        return currentGameState;
    }

    public void ChangeGameState(GameState newState)
    {
        currentGameState = newState;

        switch (currentGameState)
        {
            case GameState.GamePlay:
                Time.timeScale = 1;
                break;

            case GameState.Inventory:
                Time.timeScale = 0f;
                break;
        }
    }
}
