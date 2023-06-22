using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 1f; // D�nme h�z�

    void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f); // Y ekseninde d�nme   --Buras� animasyon �eklinde yap�lmaya �al���lacak--
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncuya �arp��ma kontrol�
        {
            Destroy(gameObject); // Coin nesnesini yok et
        }
    }
}