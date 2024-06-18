using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject background;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;


    void Start()
    {
        
    }

    public void play()
    {
        SoundManager.PlayClickButton();
        background.SetActive(false);
        instruction1.SetActive(true);
    }

    public void ContinueInstruction12()
    {
        SoundManager.PlayClickButton();
        instruction1.SetActive(false);
        instruction2.SetActive(true);
    }

    public void ContinueInstruction23()
    {
        SoundManager.PlayClickButton();
        instruction2.SetActive(false);
        instruction3.SetActive(true);
    }

    public void NextLevel()
    {
        SoundManager.PlayClickButton();
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
        Invoke("ExitLevel", 0.8f);
    }
}
