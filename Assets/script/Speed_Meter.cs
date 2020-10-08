using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Meter : MonoBehaviour
{
    private const float MaxSpeedAngle = 270;
    private const float MinSpeedAngle1 = 90;
    private const float MinSpeedAngle2 = 180;

    public Transform needdle;
    public float speed;

    private float speedMax;

    void Awake()
    {
        speed = 0f;
        speedMax = 170f;

    }

    void Update()
    {
        speed = FindObjectOfType<YbotAnimations>().angle;
        if (speed > speedMax)
        {
            speed = speedMax;
        }
        needdle.eulerAngles = new Vector3(0, 0, getSpeedRotation());
        //Debug.Log("angle : "+getSpeedRotation());
        //FindObjectOfType<YbotAnimations>().needleAngle = getSpeedRotation();
    }

    float getSpeedRotation()
    {
        float totalAngleSize = MaxSpeedAngle - MinSpeedAngle1;

        float speedNor = speed / speedMax;
        return MinSpeedAngle1 - speedNor * totalAngleSize;
    }
}
