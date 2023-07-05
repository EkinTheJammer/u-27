using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider slider;

    public GameObject pauseMenuUI;
    private bool isPaused = true;

    public GameObject upgradeMenu;
    private bool isPausedis = true;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isPausedis = false;

        // Mouse imleci g�sterilsin
        Cursor.visible = true;
        // Mouse yakalamas� kapat�ls�n
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }

        // Mouse imleci kaybolmamas�n� sa�layan kod
        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (isPausedis)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    public void SliderIsFull()
    {
        if (slider.value >= slider.maxValue)
        {
            if (isPausedis)
                Resume1();
            else
                Pause1();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Resume1()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void Restart()
    {
        // Sahneyi yeniden y�kle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        CoinCollectible.coinCount = 0;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alaca��m�z zaman silece�iz. Yoksa �al��m�yor. Fakat, �imdilik test ederken g�rebilmemiz i�in durmas� gerekiyor.
        Application.Quit();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Pause1()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPausedis = true;
    }

    public void ReturnToMainMenu()
    {
        // �stenilen sahnenin ad�
        string targetSceneName = "MainScene";
        // Sahneye d�n
        SceneManager.LoadScene(targetSceneName);
    }

    public void click1()
    {
        Debug.Log("Buton 1'e t�kland�!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void click2()
    {
        Debug.Log("Buton 2'ye t�kland�!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }
    public void click3()
    {
        Debug.Log("Buton 3'e t�kland�!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }
}