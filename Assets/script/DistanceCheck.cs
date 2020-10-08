using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceCheck : MonoBehaviour
{

    [SerializeField]
    Transform jevelinObj, EndLineObj,distanceObj;
    float dis = 0;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<YbotAnimations>().shootJevelin)
        {
            slider.value = dis;
            dis = jevelinObj.position.magnitude / (distanceObj.position - EndLineObj.position).magnitude;
            //Debug.Log(dis);
            FindObjectOfType<VelocityAndAngle>().distance(jevelinObj.position.magnitude);
        }

    }

    public void distance()
    {
        FindObjectOfType<moneyReward>().addMoney(jevelinObj.position.magnitude);
        Debug.Log("distance : " + dis);
    }

}
