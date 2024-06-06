using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coinCount;
    public static CoinCounter Instance {get; private set;}


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        coinCount = 0;
        UpdateCoinCount();
    }

    // Update is called once per frame

    public void AddCoin(int amount)
    {
        coinCount+=amount;
        UpdateCoinCount();
    }

    private void UpdateCoinCount()
    {
        coinText.text = coinCount.ToString();
    }

}
