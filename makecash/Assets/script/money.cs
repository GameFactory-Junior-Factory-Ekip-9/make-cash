using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public int cpulevel;
    public GameObject cpu1;
    public GameObject cpu2;
    public GameObject[] pipes;
    public Button azaltmaDugmesi;
    public GameObject unlockednewcpu;
    public GameObject lockednewcpu;

    public float zamanAraligi = 5f; // Materyali açmak için geçmesi gereken süre (saniye)
    public float gecenSure = 0f;
    private bool materyalAcildi = false;
    public int toplampara;
    
    [Header("Price")]

    public int priceforspeed;
    public int priceforaddingpipe;
    public int priceforincome;

    [Header("Price Level")]
    public int hızlevel = 1;
    public int incomelevel = 1;
 
    [Header("Price Text")]
    [SerializeField] TMP_Text hıztext;
    [SerializeField] TMP_Text hıztextprice;

    [SerializeField] TMP_Text pipetextprice;

    [SerializeField] TMP_Text incometext;
    [SerializeField] TMP_Text incometextprice;
    
    [SerializeField] TMP_Text moneytext;


    public GameObject[] greenmoney;
    public GameObject[] graymoney;
    public GameObject[] goldcoins; 
    public GameObject[] silverCoins;
    public int indexGlobal = 0;
    private void Start()
    {
        azaltmaDugmesi.onClick.AddListener(AzaltmaDugmesiTiklandi);
    }
   
    private void Update()
    {
        
        #region levelegöremakineayarlama
        if (cpulevel == 1) { cpu1.SetActive(true); cpu2.SetActive(false); }
        if (cpulevel == 2) { cpu1.SetActive(false); cpu2.SetActive(true); }
        #endregion
        moneytext.text = toplampara.ToString("0");
        silverCoins = GameObject.FindGameObjectsWithTag("silver_coin");
        goldcoins = GameObject.FindGameObjectsWithTag("gold_coin");
        graymoney = GameObject.FindGameObjectsWithTag("gray_money");
        greenmoney = GameObject.FindGameObjectsWithTag("green_money");
        if (silverCoins.Length+goldcoins.Length+graymoney.Length+greenmoney.Length>=25)
        {
            for (int i = 0; i < silverCoins.Length; i++)
            {
                Destroy(silverCoins[i]);
            }
            for (int i = 0; i < goldcoins.Length; i++)
            {
                Destroy(goldcoins[i]);
            }
            for (int i = 0; i < graymoney.Length; i++)
            {
                Destroy(graymoney[i]);
            }
            for (int i = 0; i < greenmoney.Length; i++)
            {
                Destroy(greenmoney[i]);
            }
        }
        incometext.text = incomelevel.ToString();
        incometextprice.text = "$ " + priceforincome.ToString();

        if (indexGlobal == 3 && incomelevel == 5 && hızlevel == 5)
        {
            unlockednewcpu.SetActive(true);
            lockednewcpu.SetActive(false);
        }
        else
        {
            unlockednewcpu.SetActive(false);
            lockednewcpu.SetActive(true);

        }

        if (indexGlobal >= 3)
        {
            pipetextprice.text = "MAX";
        }
        else
        {
            pipetextprice.text = "$ " + priceforaddingpipe.ToString();
        }
        if (cpulevel == 1)
        {
if (incomelevel != 5)
        {
            incometext.text = incomelevel.ToString();
            incometextprice.text = "$ " + priceforincome.ToString();
        }
        else
        {
            incometext.text = "MAX";
            incometextprice.text = "MAX";
        }
        if (hızlevel != 5)
        {
            hıztext.text = hızlevel.ToString();
            hıztextprice.text = "$ " + priceforspeed.ToString();
        }
        else
        {
            hıztext.text = "MAX";
            hıztextprice.text = "MAX";
        }

        }
        if(cpulevel == 2)
        {
            if (incomelevel != 10)
            {
                incometext.text = incomelevel.ToString();
                incometextprice.text = "$ " + priceforincome.ToString();
            }
            else
            {
                incometext.text = "MAX";
                incometextprice.text = "MAX";
            }
            if (hızlevel != 10)
            {
                hıztext.text = hızlevel.ToString();
                hıztextprice.text = "$ " + priceforspeed.ToString();
            }
            else
            {
                hıztext.text = "MAX";
                hıztextprice.text = "MAX";
            }
        }
        
    }

    public void AzaltmaDugmesiTiklandi()
    {
        if(cpulevel == 1) {
            if (hızlevel != 5)
        {
            if (toplampara == priceforspeed || toplampara >= priceforspeed)
            {
                zamanAraligi -= 0.2f;
                zamanAraligi = Mathf.Max(zamanAraligi, 0f);
                
                hızlevel++;
                toplampara -= priceforspeed;
                priceforspeed += 5;
            }
        } }
        if(cpulevel == 2) {  
            if (incomelevel != 10) {
                if (toplampara == priceforspeed || toplampara >= priceforspeed)
                {
                    zamanAraligi -= 0.2f;
                    zamanAraligi = Mathf.Max(zamanAraligi, 0f);

                    hızlevel++;
                    toplampara -= priceforspeed;
                    priceforspeed += 5;
                }

            } }
        
  
    }

    public void AddPipe(int index)
    {
        index = indexGlobal;
   
        if (toplampara == priceforaddingpipe || toplampara >= priceforaddingpipe)
        {

            pipes[index].SetActive(true);
            indexGlobal += 1;
            toplampara -= priceforaddingpipe;
            priceforaddingpipe *= 5;
        
        }

    }

    public void gelirarttır()
    {
        if (cpulevel == 1)
        {
            if (incomelevel !=5)
        {
            if (toplampara>=priceforincome)
            {
                incomelevel++;
                toplampara -= priceforincome;
                priceforincome*=3;
            }
        }

        }
        if (cpulevel == 2)
        {
            if (incomelevel != 10)
            {
                if (toplampara >= priceforincome)
                {
                    incomelevel++;
                    toplampara -= priceforincome;
                    priceforincome *= 3;
                }
            }


        }
        
    }
    public void levelarttır()
    {
        cpulevel++;
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].SetActive(false);
            
        }
        indexGlobal = 0;
    }

}
