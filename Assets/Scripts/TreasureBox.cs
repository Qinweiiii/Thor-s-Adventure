using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public CollectItems CI;
    public GameObject key;
    public GameObject board;

    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            if (CI.clueCount >= 10)
            {
                Debug.Log("Key can be generated");
                anim.SetBool("open", true);
                Invoke("KeyGeneration", 0.9f);
            }

            else
            {
                board.SetActive(true);
                Debug.Log("Board can be generated");
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

    void KeyGeneration()
    {
        key.SetActive(true);
    }

    void boardDisappeared()
    {
        board.SetActive(false);
    }
}
