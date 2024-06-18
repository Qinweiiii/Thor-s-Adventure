using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_behavior : MonoBehaviour
{
    public int isBucket;
    public GameObject player;
    public int speed = 5;
    public int health = 20;
    public int damage = 5;

    private Animator anim;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //player.GetComponent<CircleCollider2D>().enabled = false;

        anim = GetComponent<Animator>();
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Bucket"))
        {
            isBucket = 1;
            //Debug.Log("There is dolphin:" + IsDolphinAlive);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //player.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (!GameObject.FindWithTag("Bucket"))
        {
            isBucket = 0;
            //Debug.Log("There is no dolphin:" + IsDolphinAlive);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            //player.GetComponent<CircleCollider2D>().enabled = true;
            Move();
        }
    }

    void Move()
    {
        anim.SetBool("run", true);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShotAreaCheck"))
        {
            Debug.Log("Shottable");
            Vector2 updatePos = new Vector2(transform.position.x, transform.position.y + 2f);
            if (transform.position.y > player.transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, player.transform.position.y);
            }
            target = transform;
            anim.SetBool("run", false);
            SoundManager.PlaySniperRifle();
            anim.SetBool("shot", true);
            //Debug.Log("Shottable");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Damage is triggered");
        }
    }

    private void Death()
    {
        anim.SetBool("dead", true);
        Invoke("Destroy", 0.7f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        target = transform;
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
