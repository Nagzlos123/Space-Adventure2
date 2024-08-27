using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "World Event/Event Data")]
public class EventData : ScriptableObject
{
    public string displayName;
    public int difficultyLevel;
    public Sprite difficultyImg;
}
