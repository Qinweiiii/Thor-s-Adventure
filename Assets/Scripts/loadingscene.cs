using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VFX;

public class loadingscene : MonoBehaviour
{
    private bool startGame;
    private float loadingTime;
    private float totalTime = 3f;

    public Image loadingBar;

    void Start()
    {
        loadingTime = 0;
        loadingBar.fillAmount = 0;
    }

    void Update()
    {
        loadingTime += Time.deltaTime;
        loadingBar.fillAmount = loadingTime / totalTime;
        if (loadingBar.fillAmount == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}