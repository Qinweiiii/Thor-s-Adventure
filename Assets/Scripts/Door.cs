using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public CollectItems CI;

    public GameObject board;
    public GameObject lockDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            if (CI.keyCount >= 1)
            {
                Debug.Log("Preparing to enter into next level");
                Invoke("lockDoorDisappeared", 0.5f);
            }

            else
            {
                board.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            Invoke("boardDisappeared", 0.5f);
        }
    }

    void lockDoorDisappeared()
    {
        lockDoor.SetActive(false);
        Invoke("EnterNextLevel", 0.8f);
    }

    void EnterNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void boardDisappeared()
    {
        board.SetActive(false);
    }
}
