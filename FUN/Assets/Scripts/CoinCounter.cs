using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;

public class CoinCounter : MonoBehaviour
{
    public static  CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins=0;

    private void Awake()
    {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins:"+ currentCoins.ToString();
        
    }
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Coins:"+ currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
