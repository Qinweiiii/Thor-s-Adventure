using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_health : MonoBehaviour
{
    public int health;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Death()
    {
        anim.SetBool("dead", true);
        Invoke("Destroy", 0.7f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
}