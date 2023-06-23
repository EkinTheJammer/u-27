using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public GameObject spherePrefab;    // Sphere objesi prefab
    public float spawnInterval = 3f;   // Karadelik olu�turma aral���
    public float yOffset = 0.51f;      // Y pozisyon ofseti
    public float attractionRadius = 5f; // �ekim alan� yar��ap�
    public AudioClip spawnSound;       // Karadelik olu�tu�unda �alacak ses
    public AudioClip attractionSound;  // D��manlar i�ine �ekildi�inde �alacak ses

    private GameObject activeSphere;   // Aktif karadelik objesi
    private List<GameObject> attractedEnemies = new List<GameObject>();  // ��ine �ekilen d��manlar�n listesi
    private AudioSource audioSource;   // AudioSource bile�eni

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnHoles());
    }

    private IEnumerator SpawnHoles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (activeSphere == null)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (enemies.Length > 0)
                {
                    int randomIndex = Random.Range(0, enemies.Length);
                    GameObject enemy = enemies[randomIndex];

                    Vector3 enemyPosition = enemy.transform.position;
                    enemyPosition.y = yOffset;

                    activeSphere = Instantiate(spherePrefab, enemyPosition, Quaternion.identity);

                    audioSource.PlayOneShot(spawnSound);

                    AttractAndDestroyEnemies(activeSphere);
                }
            }
        }
    }

    private void AttractAndDestroyEnemies(GameObject sphere)
    {
        attractedEnemies.Clear();

        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, attractionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                GameObject enemy = collider.gameObject;
                Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                if (enemyRigidbody == null)
                {
                    Debug.LogWarning("Hedef d��manda Rigidbody bile�eni bulunamad�.");
                    continue;
                }

                enemyRigidbody.useGravity = false;
                attractedEnemies.Add(enemy);
                StartCoroutine(FallAndDestroyEnemy(enemy, sphere));
            }
        }
    }

    private IEnumerator FallAndDestroyEnemy(GameObject enemy, GameObject sphere)
    {
        Vector3 attractPosition = sphere.transform.position;
        Vector3 startPosition = enemy.transform.position;
        Vector3 targetPosition = attractPosition;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            float distance = Mathf.Lerp(0f, Vector3.Distance(startPosition, targetPosition), elapsedTime);
            enemy.transform.position = Vector3.Lerp(startPosition, targetPosition, distance / Vector3.Distance(startPosition, targetPosition));
            elapsedTime += Time.deltaTime * 5f;   // H�z ivmesi

            yield return null;
        }

        attractedEnemies.Remove(enemy);
        Destroy(enemy);

        if (attractedEnemies.Count == 0)
        {
            Destroy(sphere, 2f);
            activeSphere = null;
        }

        audioSource.PlayOneShot(attractionSound);
    }
}