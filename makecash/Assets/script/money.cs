using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public GameObject orijinalMateryal;
    public GameObject orijinalMateryal1;
    public GameObject orijinalMateryal2;
    public GameObject orijinalMateryal3;
    public GameObject[] pipes;
    public Button azaltmaDugmesi;

    public float zamanAraligi = 5f; // Materyali açmak için geçmesi gereken süre (saniye)
    public float gecenSure = 0f;
    private bool materyalAcildi = false;
    public int moneyText;

    [Header("Price")]

    public int priceforspeed;
    public int priceforaddingpipe;
    public int priceforincome;

    [Header("Price Level")]
    public int hıztextint = 1;
    public int incometextint = 1;

    [Header("Price Text")]
    [SerializeField] TMP_Text hıztext;
    [SerializeField] TMP_Text hıztextprice;

    [SerializeField] TMP_Text pipetextprice;

    [SerializeField] TMP_Text incometext;
    [SerializeField] TMP_Text incometextprice;
    public GameObject[] silverCoins;
    public int indexGlobal = 0;
    private void Start()
    {
        azaltmaDugmesi.onClick.AddListener(AzaltmaDugmesiTiklandi);
    }

    private void Update()
    {
        moneyText = this.GetComponent<moneyoperation>().silverCoinCount;
        silverCoins = GameObject.FindGameObjectsWithTag("silver_coin");

        incometext.text = incometextint.ToString();
        incometextprice.text = "$ " + priceforincome.ToString();

        if (!materyalAcildi)
        {

            gecenSure += Time.deltaTime;

            if (gecenSure >= zamanAraligi)
            {
                materyalAcildi = true;
                MateryalOlustur();
                orijinalMateryal.GetComponent<Animation>().enabled = false;
            }
        }

        if (indexGlobal >= 3)
        {
            pipetextprice.text = "MAX";
        }
        else
        {
            pipetextprice.text = "$ " + priceforaddingpipe.ToString();
        }

        if (hıztextint != 5)
        {
            hıztext.text = hıztextint.ToString();
            hıztextprice.text = "$ " + priceforspeed.ToString();
        }
        else
        {
            hıztext.text = "MAX";
            hıztextprice.text = "MAX";
        }
    }

    public void AzaltmaDugmesiTiklandi()
    {
        if (hıztextint != 5)
        {
            if (moneyText == priceforspeed || moneyText >= priceforspeed)
            {
                zamanAraligi -= 0.2f;
                zamanAraligi = Mathf.Max(zamanAraligi, 0f);
                priceforspeed += 1;
                hıztextint++;

                for (int i = 1; i < priceforspeed; i++)
                {
                    Destroy(silverCoins[i]);
                }

            }
        }
  
    }

    public void AddPipe(int index)
    {
        index = indexGlobal;
   
        if (moneyText == priceforaddingpipe || moneyText >= priceforaddingpipe)
        {

            pipes[index].SetActive(true);
            indexGlobal += 1;
            priceforaddingpipe += 1;

            for (int i = 1; i < priceforspeed; i++)
            {
                Destroy(silverCoins[i]);
            }


            if (pipes[0].activeSelf)
            {
                orijinalMateryal1.SetActive(true);
            }
            if (pipes[1].activeSelf)
            {
                orijinalMateryal2.SetActive(true);
            }
            if (pipes[2].activeSelf)
            {
                orijinalMateryal3.SetActive(true);
            }
        }

    }


    private void MateryalOlustur()
    {
        while (true)
        {
            gecenSure = 0f;
            materyalAcildi = false;

            GameObject yeniMateryal = Instantiate(orijinalMateryal, new Vector3(-10.48f, 11.19f, 90.22655f), transform.rotation);
            yeniMateryal.SetActive(true);
            money yeniMateryalKontrol = yeniMateryal.GetComponent<money>();
            yeniMateryalKontrol.zamanAraligi = zamanAraligi;
  
        }
    }
}
