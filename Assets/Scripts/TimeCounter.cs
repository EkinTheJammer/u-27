using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float startTime = 0f; // Sayac�n ba�lama s�resi
    public float counterSpeed = 1f; // Sayac�n h�z�

    private float currentTime = 0f;
    private TMP_Text counterText;
    public BoxSpawn boxSpawnScript; // BoxSpawn script referans�
    private bool everyMinute = true;

    private void Start()
    {
        counterText = GetComponent<TMP_Text>();
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime * counterSpeed;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        counterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes > 0 && minutes % 2 == 0 && seconds==0 && everyMinute)
        {
            boxSpawnScript.SpawnBoxes();// Her dakika ba��nda yap�lacak i�lemler             
            everyMinute = false; // De�i�keni e�itle
            Invoke("ResetEveryMinute", 2f); // 2 saniye sonra SetVariable metodu �a�r�lacak
        }
    }
    
    private void ResetEveryMinute()
    {
        everyMinute = true; // De�i�keni e�itle
    }
}
