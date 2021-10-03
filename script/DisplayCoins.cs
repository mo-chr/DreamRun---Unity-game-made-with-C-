using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
    public TextMeshProUGUI coins1, coins2;

    // Start is called before the first frame update
    void Start()
    {
        int Coin = PlayerPrefs.GetInt("Coins");

        coins1.SetText("Coins:"+Coin);
        coins2.SetText("Coins:" + Coin);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
