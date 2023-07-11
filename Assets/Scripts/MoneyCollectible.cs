using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCollectible : MonoBehaviour
{
    public static int MoneyCount = 0; // Toplanan coin say�s�, t�m CoinCollectible objeleri aras�nda payla��l�r
    public TMP_Text MoneyCountText; // Coin say�s� Text referans�

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("money"); //Param�z� s�f�rlamak i�in buray� ekledim.
        MoneyCountText = GameObject.Find("MoneyCountText").GetComponent<TMP_Text>(); // Coin say�s� Text referans�n� bul
        if (PlayerPrefs.HasKey("money"))
        {
            MoneyCount = PlayerPrefs.GetInt("money");
        }
        UpdateMoneyCountText(); // Coin say�s� Text'i g�ncelle
    }
    public void UpdateMoneyCountText()
    {
        PlayerPrefs.SetInt("money", MoneyCount);
        MoneyCountText.text = "Money: " + MoneyCount.ToString(); // Coin say�s� Text'i g�ncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player karakteriyle �arp��ma kontrol�
        {
            MoneyCount += 750; // Coin say�s�n� bir art�r
            UpdateMoneyCountText(); // Coin say�s� Text'i g�ncelle

            Destroy(gameObject); // MOney nesnesini yok et
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
