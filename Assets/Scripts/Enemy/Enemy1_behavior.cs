using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_behavior : MonoBehaviour
{
    public Transform bombPoint;
    public GameObject bomb;
    public GameObject Enemy1;
    public Transform destination;

    public int damage;
    public int health = 50;

    //private static Transform temp;
    private Animator anim;
    private BoxCollider2D coll2D;

    private bool isThrowBomb = false;
    //private static int count = 0;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Animator>();
        coll2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (isThrowBomb)
        {
            anim.SetBool("ThrowBomb", true);
            //Debug.Log("ThrowBomb Triggerred");
            Invoke("bombCreation", 0.7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            //Debug.Log("Player enters into the attackable area");
            isThrowBomb = true;
            //Debug.Log("The value of isThrow Bomb is: " + isThrowBomb);
            Vector2 temp = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            destination.position = temp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            //Debug.Log("Player walks out the attackable area");
        }
    }

    void bombCreation()
    {
        Instantiate(bomb, bombPoint.position, bombPoint.rotation);
        isThrowBomb = false;
        anim.SetBool("ThrowBomb", false);
    }

}
