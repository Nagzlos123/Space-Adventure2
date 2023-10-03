using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject parent = null;
    private void Start()
    {
        
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void DestroyParentGameObject()
    {
        if (parent != null)
            Destroy(parent);
    }
}
