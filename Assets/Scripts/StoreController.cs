using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreController : MonoBehaviour
{
    public TMP_Text MoneyCount;
    public TMP_Text MoneyCount2;
    private int money;

    public AudioClip buySound;
    public AudioClip notbuySound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sat�nAlim1()
    {
        if (money >= 100)
        {
            money = PlayerPrefs.GetInt("money");
            money = money - 100;
            PlayerPrefs.SetInt("money", money);
            MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
            MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
            BuyingSound();
        }
        else
        {
            NotBuyingSound();
        }

        
    }

    public void Sat�nAlim2()
    {
        if (money >= 100)
        {
            money = PlayerPrefs.GetInt("money");
            money = money - 200;
            PlayerPrefs.SetInt("money", money);
            MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
            MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
            BuyingSound();
        }
        else
        {
            NotBuyingSound();
        }
    }

    public void Sat�nAlim3()
    {
        if (money >= 100)
        {
            money = PlayerPrefs.GetInt("money");
            money = money - 300;
            PlayerPrefs.SetInt("money", money);
            MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
            MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
            BuyingSound();
        }
        else
        {
            NotBuyingSound();
        }
    }

    public void Sat�nAlim4()
    {
        if (money >= 100)
        {
            money = PlayerPrefs.GetInt("money");
            money = money - 400;
            PlayerPrefs.SetInt("money", money);
            MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
            MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
            BuyingSound();
        }
        else
        {
            NotBuyingSound();
        }
    }

    public void Sat�nAlim5()
    {
        if (money >= 100)
        {
            money = PlayerPrefs.GetInt("money");
            money = money - 500;
            PlayerPrefs.SetInt("money", money);
            MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
            MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
            BuyingSound();
        }
        else
        {
            NotBuyingSound();
        }
    }

    public void BuyingSound()
    {
        audioSource.clip = buySound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }
    public void NotBuyingSound()
    {
        audioSource.clip = notbuySound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }
}
