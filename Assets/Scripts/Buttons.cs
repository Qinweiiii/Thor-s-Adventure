using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public CollectItems CI;
    public ThorMovement TM;
    public GameObject pauseButton;
    public GameObject continueButton;
    public GameObject menuButton;
    public GameObject menu;

    private new AudioSource audio;
    //public AudioSource click;

    public void medicineAddBlood()
    {
        if (CI.medicineCount > 0 && TM.health < TM.maxHealth)
        {
            SoundManager.PlayClickButton();
            CI.medicineCount--;
            TM.health += 5;
        }
    }

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void PauseGame()
    {
        SoundManager.PlayClickButton();
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        continueButton.SetActive(true);
        //audio.Stop();
    }

    public void ContinueGame()
    {
        SoundManager.PlayClickButton();
        Time.timeScale = 1;
        continueButton.SetActive(false);
        pauseButton.SetActive(true);
        //audio.Play();
    }

    public void OpenMenu()
    {
        SoundManager.PlayClickButton();
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        SoundManager.PlayClickButton();
        menu.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void PlayGoToHome()
    {
        SoundManager.PlayClickButton();
        //click.Play();
        Invoke("GoToHome", 0.8f);
    }


    public void RestartLevel()
    {
        SoundManager.PlayClickButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayRestartLevel()
    {
        SoundManager.PlayClickButton();
        //click.Play();
        Invoke("RestartLevel", 0.8f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitLevel()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PlayExitLevel()
    {
        SoundManager.PlayClickButton();
        //click.Play();
        Invoke("ExitLevel", 0.8f);
    }
}
