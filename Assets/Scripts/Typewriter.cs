using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typewriter : MonoBehaviour, IInteractable
{
    InteractionIcon icon;

    public void Interact()
    {
        print("Abrir o Menu de Save");
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
