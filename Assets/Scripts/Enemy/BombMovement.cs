using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 2;
    public float time;

    private Transform target;
    private Animator anim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Enemy1_behavior>().destination;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            SoundManager.PlayGrenade();
            anim.SetBool("boom", true);
            Invoke("DestroyBomb", 0.4f);
        }
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }

    IEnumerator bombExplosion()
    {
        yield return new WaitForSeconds(time);
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
