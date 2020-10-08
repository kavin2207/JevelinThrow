using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jevelinDownWordRotation : MonoBehaviour
{
    Rigidbody rb;
    public bool hasHit = false;
    //float an;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<JevelinRotation>().check && hasHit == false)
        {
            
            angle = Mathf.Atan2(rb.velocity.z, rb.velocity.y) * Mathf.Rad2Deg;

            //Debug.Log("angle : " + Quaternion.AngleAxis(angle , Vector3.right));
            transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.right);
            //Debug.Log("y,x : "+ (-Mathf.Atan2(rb.velocity.z, rb.velocity.y) * Mathf.Rad2Deg) + " : vjhdb : " + transform.rotation);
            
        }
        //Debug.Log("change in :" + angle/10 +"traform  : " + transform.rotation);
    }

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log("change in angle :"+angle);
        //Debug.Log("rot : "+transform.rotation.x);
        rb.useGravity = false;
        hasHit = true;
        rb.velocity = Vector3.zero;
        Debug.Log("avfdd");
        rb.isKinematic = true;
        //transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
        transform.Rotate(FindObjectOfType<JevelinRotation>().ang, 0, 0);
        FindObjectOfType<DistanceCheck>().distance();
        FindObjectOfType<ThrowLine>().throwLinePosi = false;

    }
}
