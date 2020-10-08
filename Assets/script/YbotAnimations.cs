using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YbotAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject SpeedMeter, AngleMeter;
    Animator anim;
    public float velocity = 0f, boySpeed = 50f;
    float accr = 530, deAccr = 50f;
    public bool shootJevelin = false, checkPoint = false,AirRotation = false;


    public float veloSpeed = 0f;
    Rigidbody rb;


    public float needleAngle;


    // new Logic
    [HideInInspector]
    public float angle;

    float maxSpeed = 100f;
    float minSpeed = 0f;

    bool SpeedCheck = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame




    void Update()
    {
        FindObjectOfType<VelocityAndAngle>().Speed(velocity * 10);
        
        //Debug.Log("sjsjsjsjs : " + velocity);
        if (velocity < 0 || FindObjectOfType<JevelinRotation>().freeMotion)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            //Debug.Log("abhikkkk");
            float vel = (velocity * boySpeed * Time.deltaTime);
            rb.velocity = new Vector3(0f, 0f, vel);
        }





        if (FindObjectOfType<JevelinRotation>().animCheck)
        {
            anim.SetBool("isThrow", true);
            
        }

        anim.SetFloat("Velocity", velocity);


        //for meter spawn
        meters();
        throwEndLine();
    }

    void FixedUpdate()
    {
        playerSpeed();
        
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetMouseButtonDown(0)) && FindObjectOfType<ThrowLine>().throwLinePosi == false && FindObjectOfType<cameraChange>().gameStart)
        {
            
            SpeedCheck = true;
            if (angle < 160)
            {
                //Debug.Log("ajsjs");
                angle += accr*Time.deltaTime;
            }
        }
        else
        {
            SpeedCheck = false;
            if (angle > 0 && FindObjectOfType<ThrowLine>().throwLinePosi == false)
            {
                angle -= deAccr*Time.deltaTime;
            }
            //veloSpeed = velocity;
        }
        if (angle < 0)
        {
            angle = 0;
        }
        
    }

    public void ThrowJevelinFunct()
    {
        shootJevelin = true;
        FindObjectOfType<JevelinRotation>().freeMotion = true;
        checkPoint = true;
    }

    void meters()
    {
        if (FindObjectOfType<ThrowLine>().throwLinePosi)
        {
            veloSpeed = velocity;
            SpeedMeter.SetActive(false);
            AngleMeter.SetActive(true);
            if (checkPoint)
            {
                AngleMeter.SetActive(false);
            }
        }
    }

    void throwEndLine()
    {
        if (FindObjectOfType<EndThrowLine>().endLine)
        {
            //Debug.Log("abhijeet");
            rb.velocity = Vector3.zero;
            anim.SetBool("isFall", true);
        }
    }

    void playerSpeed()
    {
        if (boySpeed < maxSpeed && (angle > 0 && angle < 20) && SpeedCheck)
        {
            //Debug.Log("1");
            velocity += 0.12f;
        }
        if (boySpeed < maxSpeed && (angle > 20 && angle < 45) && SpeedCheck)
        {
            //Debug.Log("2");
            velocity += 0.17f;
        }
        if (boySpeed < maxSpeed && (angle > 45 && angle < 110) && SpeedCheck)
        {
            //Debug.Log("3");
            velocity += 0.22f;
        }
        if (boySpeed > minSpeed && (angle > 110 && angle < 135))
        {
            //Debug.Log("4");
            //velocity -= 0.02f;
            velocity += 0.12f;
        }
        if (boySpeed > minSpeed && (angle > 135 && angle < 160))
        {
            //Debug.Log("5");
            velocity -= 0.09f;
        }
        if (boySpeed > minSpeed && (angle > 160))
        {
            //Debug.Log("6");
            velocity -= 0.05f;
        }
        if (angle == minSpeed && boySpeed > minSpeed)
        {
            //Debug.Log("7");
            velocity = 0f;
        }
    }
}