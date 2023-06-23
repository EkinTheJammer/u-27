using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maksimum can de�eri
    public float currentHealth; // Mevcut can de�eri

    public Slider healthSlider; // Can� g�stermek i�in Slider

    private bool isDead = false; // �l�p �lmedi�ini kontrol etmek i�in bir bayrak

    private void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta can� maksimum de�ere ayarla
        healthSlider.maxValue = maxHealth; // Slider'�n maksimum de�erini ayarla
        healthSlider.value = currentHealth; // Slider'�n mevcut de�erini ayarla
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead) // E�er d��manla temas olduysa ve �lmediyse
        {
            TakeDamage(10f); // Can� azaltan fonksiyonu �a��r, parametre olarak al�nan de�er d��man�n verdi�i zarard�r (�rne�in 10)
        }
    }

    private void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Can� azalt
        healthSlider.value = currentHealth; // Slider'�n mevcut de�erini g�ncelle

        if (currentHealth <= 0f)
        {
            Die(); // E�er can s�f�ra d��t�yse Die fonksiyonunu �a��r (oyuncu �l�r)
        }
    }

    private void Die()
    {
        isDead = true; // Oyuncu �ld���nde bayra�� true yap

        Debug.Log("Oyuncu �ld�!"); // Konsola �l�m mesaj�n� yazd�r

        // Oyuncunun �l�m�yle ilgili i�lemleri burada ger�ekle�tirin
        // �rne�in, oyunu yeniden ba�latmak veya oyunu sonland�rmak gibi
    }
}