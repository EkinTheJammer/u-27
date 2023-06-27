using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = true;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

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
         else
         {
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
  
   public void Restart()
    {
        // Sahneyi yeniden y�kle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

         CoinCollectible.coinCount= 0;
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

    public void ReturnToMainMenu()
    {
        // �stenilen sahnenin ad�
        string targetSceneName = "MainScene";
        // Sahneye d�n
        SceneManager.LoadScene(targetSceneName);
    }
}
