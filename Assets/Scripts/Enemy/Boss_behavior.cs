using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss_behavior : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public int damage;

    public float health;
    public Image bar;
    public float maxHealth;
    [SerializeField] private Text bloodAmount;
    #endregion

    #region Private Variables
    private Animator anim;
    private Transform target;
    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
        target = transform;
    }

    void Update()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        BarFiller();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerArea"))
        {
            anim.SetBool("run", true);
            target = collision.gameObject.transform;
            //collision.GetComponent<ThorMovement>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("AttackCheck"))
        {
            anim.SetBool("run", false);
            target = gameObject.transform;
            anim.SetBool("attack", true);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Attack player");
        }
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

    private void Recover()
    {
        anim.SetBool("hurt", false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
        else
        {
            anim.SetBool("hurt", true);
            Invoke("Recover", 0.9f);
        }
    }

    private void BarFiller()
    {
        bar.fillAmount = health / maxHealth;
        bloodAmount.text = health + " / " + maxHealth;
    }
}
