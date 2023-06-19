using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraoluşturma : MonoBehaviour
{
    private bool materyalAcildi = false;
    public float zamanAraligi = 5f; // Materyali açmak için geçmesi gereken süre (saniye)
    public float gecenSure = 0f;
    public GameObject silvercoinmodel;
    public GameObject goldcoinmodel;
    public GameObject graymoneymodel;
    public GameObject greenmoneymodel;
    public GameObject moneysystem;
    private void FixedUpdate()
    {
        zamanAraligi =moneysystem.GetComponent<money>().zamanAraligi;
        if (!materyalAcildi)
        {

            gecenSure += Time.fixedDeltaTime;

            if (gecenSure >= zamanAraligi)
            {
                materyalAcildi = true;
                MateryalOlustur();
                silvercoinmodel.GetComponent<Animation>().enabled = true;
            }
        }

    }
    private void MateryalOlustur()
    {
        while (true)
        {
            gecenSure = 0f;
            materyalAcildi = false;
            float olasılık = Random.Range(1, 6);
            GameObject yeniMateryal;
            if (moneysystem.GetComponent<money>().cpulevel == 1)
            {
            if (olasılık == 5)
            {
                yeniMateryal = Instantiate(goldcoinmodel, goldcoinmodel.transform.position, transform.rotation);
                moneysystem.GetComponent<money>().toplampara += 3 * moneysystem.GetComponent<money>().incomelevel;
            }
            else
            {
                yeniMateryal = Instantiate(silvercoinmodel, silvercoinmodel.transform.position, transform.rotation);
                moneysystem.GetComponent<money>().toplampara += moneysystem.GetComponent<money>().incomelevel;
            }
            }
            else
            {
                if (olasılık == 5)
                {
                    yeniMateryal = Instantiate(greenmoneymodel, greenmoneymodel.transform.position, transform.rotation);
                    moneysystem.GetComponent<money>().toplampara += 25 * moneysystem.GetComponent<money>().incomelevel;
                }
                else
                {
                    yeniMateryal = Instantiate(graymoneymodel, graymoneymodel.transform.position, transform.rotation);
                    moneysystem.GetComponent<money>().toplampara += 5*moneysystem.GetComponent<money>().incomelevel;
                }
            }

            yeniMateryal.SetActive(true);
            money yeniMateryalKontrol = yeniMateryal.GetComponent<money>();
           yeniMateryalKontrol.zamanAraligi = zamanAraligi;

        }
    }
}
