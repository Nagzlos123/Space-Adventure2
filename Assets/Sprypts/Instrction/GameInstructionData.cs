using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Instraction Data")]
public class GameInstructionData : ScriptableObject
{
    public string panelName;
    public Sprite displayImage;
    [TextArea(4, 4)]
    public string discreption;
}
