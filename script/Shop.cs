using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI coinsText,coinsText1,coinsText2;
    infiniteRunner player;
    int coinsNumber;
    public GameObject maskBuy,vrBuy,frogBuy,maskSelect,vrSelect,frogSelect,mayuhSelect,mayuhBuy;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.GetInt("Coins");
        PlayerPrefs.GetString("MaskIsBought");
        PlayerPrefs.GetString("VrIsBought");
        PlayerPrefs.GetString("FrogIsBought");
        

    }
    void Start()
    {
        //PlayerPrefs.SetInt("Coins", 200);
        coinsNumber = PlayerPrefs.GetInt("Coins");
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.SetText("Coins : " + coinsNumber);
        coinsText1.SetText("Coins : " + coinsNumber);
        coinsText2.SetText("Coins : " + coinsNumber);

        if (PlayerPrefs.GetString("MaskIsBought") == "true")
        {
            maskBuy.SetActive(false);
            maskSelect.SetActive(true);

        }

        if (PlayerPrefs.GetString("FrogIsBought") == "true")
        {

            frogBuy.SetActive(false);
            frogSelect.SetActive(true);
            
        }

        if (PlayerPrefs.GetString("VrIsBought") == "true")
        {
            vrBuy.SetActive(false);
            vrSelect.SetActive(true);

        }


        if (PlayerPrefs.GetString("MayuhIsBought") == "true")
        {
            mayuhBuy.SetActive(false);
            mayuhSelect.SetActive(true);

        }



    }
    public void BuyFrog()
    {
        
        if (coinsNumber >= 200)
        {
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsNumber -= 200;
            
            PlayerPrefs.SetInt("Coins", coinsNumber);
            PlayerPrefs.Save();
            PlayerPrefs.SetString("FrogIsBought", "true");
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsText.SetText("Coins : " + coinsNumber);
            coinsText1.SetText("Coins : " + coinsNumber);

        }

    }
    public void BuyMask()
    {
        
        if (coinsNumber >= 200)
        {
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsNumber -= 200;
            
            PlayerPrefs.SetInt("Coins", coinsNumber);
            PlayerPrefs.Save();
            PlayerPrefs.SetString("MaskIsBought", "true");
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsText.SetText("Coins : " + coinsNumber);
            coinsText1.SetText("Coins : " + coinsNumber);

        }

    }
    public void BuyVR()
    {
        
        if (coinsNumber >= 200)
        {
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsNumber -= 200;
           
            PlayerPrefs.SetInt("Coins", coinsNumber);
            PlayerPrefs.Save();
            PlayerPrefs.SetString("VrIsBought", "true");
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsText.SetText("Coins : " + coinsNumber);
            coinsText1.SetText("Coins : " + coinsNumber);

        }

    }

    public void BuyMayuh()
    {

        if (coinsNumber >= 300)
        {
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsNumber -= 300;

            PlayerPrefs.SetInt("Coins", coinsNumber);
            PlayerPrefs.Save();
            PlayerPrefs.SetString("MayuhIsBought", "true");
            coinsNumber = PlayerPrefs.GetInt("Coins");
            coinsText.SetText("Coins : " + coinsNumber);
            coinsText1.SetText("Coins : " + coinsNumber);

        }

    }
}
