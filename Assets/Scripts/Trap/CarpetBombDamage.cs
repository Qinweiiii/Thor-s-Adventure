using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetBombDamage : MonoBehaviour
{
    public int damage = 5;
    
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Damage is triggered");
        }
    }
}