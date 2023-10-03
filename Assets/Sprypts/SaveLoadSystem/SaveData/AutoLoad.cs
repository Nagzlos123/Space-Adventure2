using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoad : MonoBehaviour
{
    public void AutoLoadOn()
    {
        PlayerPrefs.SetInt("AutoLoadOn", 1);
    }
}
