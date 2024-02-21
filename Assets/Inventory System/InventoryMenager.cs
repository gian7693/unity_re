using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InventoryMenager : MonoBehaviour
{
    public GameObject inventoryPanel;

    [SerializeField]
    private int idTab;

    public Image[] iconTab;
    public string[] nameTab;
    public GameObject[] inventoryTab;
    public TMP_Text labelTab;

    public void Start()
    {
        InputMenager.Instance.control.Input.ButtonNorth.started += OnInventoryButton;
        InputMenager.Instance.control.Inventory.LeftShoulder.started += OnLeftShoulder;
        InputMenager.Instance.control.Inventory.RightShoulder.started += OnRightShoulder;
    }

    public void OnDisable()
    {
        InputMenager.Instance.control.Input.ButtonNorth.started -= OnInventoryButton;
        InputMenager.Instance.control.Inventory.LeftShoulder.started -= OnLeftShoulder;
        InputMenager.Instance.control.Inventory.RightShoulder.started -= OnRightShoulder;
    }

    public void OpenInventoryWindow(bool isShowWindow, int idTab = 0)
    {
        this.idTab = idTab;
        CoreGame.core.inventoryMenager.inventoryPanel.SetActive(isShowWindow);
        ShowTab();
    }

    private void TabNavegation(int value)
    {
        idTab += value;
        idTab = Mathf.Clamp(idTab, 0, inventoryTab.Length - 1);
        ShowTab();
    }

    private void ShowTab()
    {
        foreach(Image icon in iconTab)
        {
            icon.color = Color.white;
        }

        iconTab[idTab].color = Color.yellow;
        labelTab.text = nameTab[idTab];

        foreach(GameObject tab in inventoryTab)
        {
            tab.SetActive(false);
        }

        inventoryTab[idTab].SetActive(true);
    }

    #region Input
    public void OnInventoryButton(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            switch(CoreGame.core.gameMenager.GetGameState())
            {
                case GameState.GamePlay:
                    OpenInventoryWindow(true);
                    CoreGame.core.gameMenager.ChangeGameState(GameState.Inventory);
                    break;

                case GameState.Inventory:
                    OpenInventoryWindow(false);
                    CoreGame.core.gameMenager.ChangeGameState(GameState.GamePlay);
                    break;
            }
        }
    }

    public void OnLeftShoulder(InputAction.CallbackContext value)
    {
        if(CoreGame.core.gameMenager.GetGameState() != GameState.Inventory)
        {
            return;
        }

        if (value.started)
        {
            TabNavegation(-1);
        }
    }

    public void OnRightShoulder(InputAction.CallbackContext value)
    {
        if (CoreGame.core.gameMenager.GetGameState() != GameState.Inventory)
        {
            return;
        }

        if (value.started)
        {
            TabNavegation(1);
        }
    }
    #endregion
}
