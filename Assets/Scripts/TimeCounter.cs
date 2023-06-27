using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float startTime = 0f; // Sayac�n ba�lama s�resi
    public float counterSpeed = 1f; // Sayac�n h�z�

    private float currentTime = 0f;
    private TMP_Text counterText;

    private void Start()
    {
        counterText = GetComponent<TMP_Text>();
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime * counterSpeed;
        counterText.text = currentTime.ToString("F2"); // Sayac� TMP_Text'e yazd�rma
    }
}
