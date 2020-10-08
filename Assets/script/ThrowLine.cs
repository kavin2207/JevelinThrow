using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLine : MonoBehaviour
{
    public bool throwLinePosi = false;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            throwLinePosi = true;
        }
    }
}
