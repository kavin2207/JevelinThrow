using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class moneyReward : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI moneyEarn,totalAmount;


    float money = 0;
    float currentMoney = 0, totalMoney;
    // Start is called before the first frame update
    void Start()
    {
        totalMoney = 0;
        totalAmount.text = PlayerPrefs.GetFloat("totalMoney", 1).ToString("F0");
        money = PlayerPrefs.GetFloat("totalMoney", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void GameContinue()
    {
        FindObjectOfType<ThrowLine>().throwLinePosi = true;
        SceneManager.LoadScene("startingScene");
    }

    public void addMoney(float money1)
    {
        currentMoney = PlayerPrefs.GetInt("totalMoney", 0);
        totalMoney = money1 + money1;
        PlayerPrefs.SetFloat("totalMoney", totalMoney);
        //Debug.Log(" currnet money : "+ currentMoney + " : money : " + money);
        //Debug.Log(" total money : " + totalMoney + " : money1 : " + money1);
        moneyEarn.text = totalMoney.ToString("F0");


    }

}
