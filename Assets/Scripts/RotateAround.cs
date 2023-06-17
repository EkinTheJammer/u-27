using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f; // Dronun hareket h�z�
    public float turnSpeed = 10f; // Dronun d�n�� h�z�
    public float maxDistance = 5f; // Dronun takip edece�i maksimum mesafe
    public float reactionDistance = 10f; // Dronun tepki verece�i maksimum mesafe
    public float maxAltitude = 10f; // Dronun maksimum y�ksekli�i
    public float randomMoveInterval = 5f; // Rastgele hareketlerin ger�ekle�ece�i aral�k s�resi

    private Vector3 initialPosition; // Dronun ba�lang�� pozisyonu
    private Vector3 targetPosition; // Rastgele hareketler i�in hedef pozisyon
    private float lastRandomMoveTime; // Son rastgele hareket zaman�
    private bool isMovingRandomly = false; // Rastgele hareket halinde olup olmad���n� kontrol etmek i�in

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        if (IsTargetInRange())
        {
            MoveTowardsTarget(target.position);
        }
        else
        {
            if (Time.time - lastRandomMoveTime >= randomMoveInterval)
            {
                MoveRandomly();
            }
        }

        ClampAltitude();
    }

    private bool IsTargetInRange()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance <= reactionDistance;
    }

    private void MoveTowardsTarget(Vector3 target)
    {
        Vector3 moveDirection = (target - transform.position).normalized;
        Vector3 nextPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Oyuncuya �arp��may� kontrol et
        if (!CheckCollision(nextPosition))
        {
            transform.position = nextPosition;
        }

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    private bool CheckCollision(Vector3 nextPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(nextPosition, 1f); // �arp��may� kontrol etmek i�in bir k�re olu�tur

        foreach (Collider collider in colliders)
        {
            if (collider != target.GetComponent<Collider>() && collider != GetComponent<Collider>())
            {
                return true; // �arp��ma var
            }
        }

        return false; // �arp��ma yok
    }

    private void MoveRandomly()
    {
        targetPosition = GetRandomPosition();
        lastRandomMoveTime = Time.time;
        isMovingRandomly = true;
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(initialPosition.x - maxDistance, initialPosition.x + maxDistance);
        float randomY = Random.Range(initialPosition.y - maxAltitude, initialPosition.y + maxAltitude);
        float randomZ = Random.Range(initialPosition.z - maxDistance, initialPosition.z + maxDistance);

        return new Vector3(randomX, randomY, randomZ);
    }

    private void ClampAltitude()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, initialPosition.y, initialPosition.y + maxAltitude), transform.position.z);
    }
}
