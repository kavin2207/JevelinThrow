using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndThrowLine : MonoBehaviour
{
    public bool endLine = false;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            endLine = true;
        }
    }
}
