using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttack : MonoBehaviour
{
    public int damage = 5;
    public float time;

    private Animator anim;
    private PolygonCollider2D coll2D;

    private bool isCircleAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isCircleAttack = Input.GetKey(KeyCode.J);
        Attack();
    }

    void Attack()
    {
        if (isCircleAttack)
        {
            //Debug.Log("Triggered");
            anim.SetBool("CircleAttack", true);
        }
        else if (!isCircleAttack)
        {
           
            anim.SetBool("CircleAttack", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy2_behavior>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Enemy1"))
        {
            other.GetComponent<Enemy1_health>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Enemy3"))
        {
            other.GetComponent<Enemy3_behavior>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<Boss_movement>().TakeDamage(damage);
        }
    }
}
