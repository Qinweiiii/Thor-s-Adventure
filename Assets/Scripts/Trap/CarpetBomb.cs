using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetBomb : MonoBehaviour
{
    public GameObject Bomb;
    
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
            SoundManager.PlayCarpetBomb();
            Bomb.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            Bomb.SetActive(false);
        }
    }
}
