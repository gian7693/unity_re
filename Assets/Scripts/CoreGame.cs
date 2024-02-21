using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGame : MonoBehaviour
{
    public static CoreGame core;

    public InteractionMenager interactionMenager;
    public GameMenager gameMenager;
    public DoorSystemMenager doorSystemMenager;
    public SubtitleMenager subtitleMenager;
    public InventoryMenager inventoryMenager;

    public void Awake()
    {
        if(core != null && core != this)
        {
            Destroy(this.gameObject);
            return;
        }

        core = this;
    }

}
