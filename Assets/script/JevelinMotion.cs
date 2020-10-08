using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JevelinMotion : MonoBehaviour
{
    [SerializeField]
    Transform jevelinPosition;

    void Update()
    {
        if (FindObjectOfType<JevelinRotation>().freeMotion == false)
        {
            transform.position = jevelinPosition.position;
        }
    }

}
