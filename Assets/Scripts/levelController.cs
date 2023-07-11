using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class levelController : MonoBehaviour
{
    private Scene _sahne;
    public TMP_Text MoneyCountText;

    private void Awake()
    {
        //_sahne = GetComponent<Scene>();
        _sahne = SceneManager.GetActiveScene();
    }
    public void SonrakiSahne()
    {
        SceneManager.LoadScene(_sahne.buildIndex + 1);
        //PlayerPrefs.SetInt("ScoreCounts", score.instance.collectedPoint);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alaca��m�z zaman silece�iz. Yoksa �al��m�yor. Fakat, �imdilik test ederken g�rebilmemiz i�in durmas� gerekiyor.
        Application.Quit();
    }

    public void Start()
    {
        MoneyCountText.text = PlayerPrefs.GetInt("money").ToString();
    }

    public void LevelCheck()
    {
        //PlayerPrefs.DeleteKey("levelend");  //S�remizi s�f�rlamak i�in buray� ekledim.
        if (PlayerPrefs.GetInt("levelend") == 1)
        {
            Debug.Log("B�l�m 1 tamamland�");
        }
    }
}
