using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public GameObject boxPrefab; // �d�l sand��� prefab�
    public int boxCount; // Spawn edilecek sand�k say�s�
    public float mapWidth; // Haritan�n geni�li�i
    public float mapLength; // Haritan�n uzunlu�u

    private void Start()
    {
        SpawnBoxes();
    }
    public void SpawnBoxes()
    {
        // Belirtilen say�da sand�k spawn et
        for (int i = 0; i < boxCount; i++)
        {
            // Rastgele bir konum se�
            float spawnX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
            float spawnZ = Random.Range(-mapLength / 2f, mapLength / 2f);
            Vector3 spawnPos = new Vector3(spawnX, 0f, spawnZ);

            // Sand��� spawn et
            Instantiate(boxPrefab, spawnPos, Quaternion.identity);
        }
    }
}
