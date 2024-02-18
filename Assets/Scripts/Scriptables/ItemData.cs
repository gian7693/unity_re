using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable/Item", order = 0)]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea(3,3)]
    public string itemRequiredCaption;
}
