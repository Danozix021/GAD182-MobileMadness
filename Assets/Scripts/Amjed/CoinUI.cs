using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText; 
    void Start()
    {
        UpdateCoinUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            UpdateCoinUI();
            Destroy(other.gameObject);
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
