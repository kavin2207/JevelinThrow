using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{
    [SerializeField]
    GameObject cameraYBot, cameraJevelin,distanceSlider,moneyPanel,tapToRunPanel;

    public bool gameStart = false;

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<JevelinRotation>().checkCamera == true)
        {
            cameraYBot.SetActive(false);
            cameraJevelin.SetActive(true);
        }
        if (FindObjectOfType<JevelinRotation>().isthrow)
        {
            distanceSlider.SetActive(true);
        }
        if (FindObjectOfType<jevelinDownWordRotation>().hasHit)
        {
            StartCoroutine(wait());
        }
        if (Input.GetMouseButtonDown(0))
        {
            tapToRunPanel.SetActive(false);
            gameStart = true;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("abhijeet : abh");
        moneyPanel.SetActive(true);

    }
}
