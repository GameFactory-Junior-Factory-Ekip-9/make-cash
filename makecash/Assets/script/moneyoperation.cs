using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class moneyoperation : MonoBehaviour
{
    [SerializeField] TMP_Text moneytext;
    public int silverCoinCount;
    public void Update()
    {
        silverCoinCount = CountSilverCoins();
        moneytext.text = "$ " + silverCoinCount.ToString();
    }
 
    public int CountSilverCoins()
    {
        GameObject[] silverCoins = GameObject.FindGameObjectsWithTag("silver_coin");
        return silverCoins.Length;
    }
}
