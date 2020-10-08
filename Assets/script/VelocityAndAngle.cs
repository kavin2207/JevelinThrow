using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VelocityAndAngle : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI speed,AngleText,distanceText;

    float initialSpeed,initialAngle,initialDistance;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = 0f;
        initialAngle = 0f;
        initialDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Speed(float vel)
    {
        initialSpeed = vel;
        speed.text = initialSpeed.ToString("F1");
    }

    public void Angle(float ang)
    {
        initialAngle = ang;
        AngleText.text = initialAngle.ToString("F0");
    }

    public void distance(float dis)
    {
        initialDistance = dis;
        distanceText.text = initialDistance.ToString("F0");
    }

}
