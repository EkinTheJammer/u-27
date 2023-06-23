using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinCollectible : MonoBehaviour
{
    public float sliderIncrement = 5f; // Slider'�n ilerleyece�i de�er
    private static int coinCount = 0; // Toplanan coin say�s�, t�m CoinCollectible objeleri aras�nda payla��l�r
    private Slider slider; // Slider referans�
    private TMP_Text levelText; // Level Text referans�
    private TMP_Text coinCountText; // Coin say�s� Text referans�


    private void Start()
    {
        slider = FindObjectOfType<Slider>(); // Slider referans�n� bul
        levelText = slider.GetComponentInChildren<TMP_Text>(); // Level Text referans�n� bul
        coinCountText = GameObject.Find("CoinCountText").GetComponent<TMP_Text>(); // Coin say�s� Text referans�n� bul
        UpdateCoinCountText(); // Coin say�s� Text'i g�ncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player karakteriyle �arp��ma kontrol�
        {
            slider.value += sliderIncrement; // Slider'� belirtilen de�er kadar ilerlet

            if (slider.value >= slider.maxValue) // Slider tamamen dolmu�sa
            {
                slider.value = 0; // Slider'� s�f�rla
                UpdateLevelText(); // Level Text'i g�ncelle
            }

            coinCount++; // Coin say�s�n� bir art�r
            UpdateCoinCountText(); // Coin say�s� Text'i g�ncelle

            Destroy(gameObject); // Coin nesnesini yok et
        }
    }

    private void UpdateLevelText()
    {
        int currentLevel = int.Parse(levelText.text); // Mevcut level de�erini al
        currentLevel++; // Level de�erini bir artt�r
        levelText.text = currentLevel.ToString(); // Level Text'i g�ncelle
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "Coin: " + coinCount.ToString(); // Coin say�s� Text'i g�ncelle
    }
}
