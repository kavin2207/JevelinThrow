using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JevelinRotation : MonoBehaviour
{
    public float X, Y, Z,ang;
    private Quaternion originalRotation;
    private Quaternion currentRotation;
    [SerializeField]
    Transform needle;
    Vector3 force;
    public float forceJeve = 1,desInVel = 7f;

    public bool isthrow = false;
    [HideInInspector]
    public bool freeMotion = false, check = false,animCheck = false,checkCamera = false,isAngleSet = false;

    Vector3 vel = Vector3.zero;
    public bool checkG = false;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = gameObject.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotate();
        jevelinGravity();
    }

    void Rotate()
    {
        
        if ((Input.GetKey(KeyCode.R)||Input.GetMouseButton(0))&& FindObjectOfType<ThrowLine>().throwLinePosi && FindObjectOfType<YbotAnimations>().AirRotation == false)
        {
            Y = 0;
            X = X + 2;
            transform.rotation = Quaternion.Slerp(currentRotation, originalRotation, X);
            transform.Rotate(-X, Y, Z);
            currentRotation = transform.rotation;
            
            animCheck = true;
            needle.eulerAngles = new Vector3(0, 0, X);
            FindObjectOfType<VelocityAndAngle>().Angle(X);

            //FindObjectOfType<ThrowLine>().throwLinePosi = false;
        }
    }

    void jevelinGravity()
    {
        
        if (FindObjectOfType<YbotAnimations>().shootJevelin)
        {
            ThrowJevelin();
            isthrow = true;
        }
        
        if (transform.position.y > 10f && checkG == false)
        {

            vel = rb.velocity;
            //Debug.Log("velo : " + vel.y);
            checkG = true;
        }
        if (checkG && vel.y >= 0) {
            //Debug.Log("gygyyg");
            vel.y -= 0.8f;          //decrease in velocity
            rb.velocity = vel;
            check = true;
            if (vel.y < 0)
            {
                rb.useGravity = true;
                //checkG = true;
            }
        }
            //rb.useGravity = true;
        
    }

    public void ThrowJevelin()
    {
        float spearSpeed = FindObjectOfType<YbotAnimations>().veloSpeed;
        
        force = transform.forward * spearSpeed * forceJeve;
        //Debug.Log("spear spped : " + force);
        rb.AddForce(force);
        checkCamera = true;
        FindObjectOfType<YbotAnimations>().AirRotation = true;
    }
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("aaa : "+X);
        ang = X;
    }

}
