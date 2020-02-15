using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rift : MonoBehaviour
{

    public GameObject prefabRift;
    public float interval = .5f;

    void Update()
    {
        if (prefabRift != null)
        {
            Random.Range(-10.0f, 10.0f);
        }
    }
}
