using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_movement : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    private int pointNum = 1;
    private float waitTime = 0.5f;

    #region Public Variables
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public bool xCheck;
    public bool yCheck;
    public float radius;
    public int time;
    public int damage;

    public float health;
    public Image bar;
    public int maxHealth;
    [SerializeField] private Text bloodAmount;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Animator anim;
    private Transform target;
    private float distance;
    private bool attackMode;
    private bool inRange;
    //private bool cooling;
    private bool isAlive;
    private float intTimer;
    private Transform playerTransform;
    #endregion


    void Awake()
    {
        isAlive = true;
        target = points[pointNum].transform;
        intTimer = timer;
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!attackMode && isAlive)
        {
            Move();
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, rayCastMask);
            RaycastDebugger();
        }

        // When Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("attack", false);
            StopAttack();
        }

        BarFiller();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player arrives");
            inRange = true;
            target = collision.transform;
            Flip();
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Damage is triggered");
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance)
        {
            Attack();
            target = transform;
        }
    }

    void Move()
    {
        anim.SetBool("run", true);

        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                inRange = true;
                target = playerTransform;
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position,
                    moveSpeed * Time.deltaTime);
                Flip();
            }
            else { inRange = false; }
        }

        if (!inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Boss_attack"))
        {
            SelectTarget();
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        //timer = intTimer; // Reset timer when player enter attack range
        attackMode = true; // To check if enemy can still attack or not

        anim.SetBool("run", false);
        anim.SetBool("attack", true);
    }

    void StopAttack()
    {
        //cooling = false;
        attackMode = false;
        anim.SetBool("attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    private bool InsideofLimits()
    {
        if (points[0].transform.position.x < transform.position.x && transform.position.x < points[1].transform.position.x)
        {
            xCheck = true;
        }
        else if (points[0].transform.position.y < transform.position.y && transform.position.y < points[1].transform.position.y)
        {
            yCheck = true;
        }
        return xCheck && yCheck;
    }

    private void SelectTarget()
    {
        target = points[pointNum].transform;
        if (Vector2.Distance(transform.position, points[pointNum].transform.position) < 0.1f)
        {
            if (waitTime < 0)
            {
                if (pointNum == 0)
                {
                    pointNum = 1;
                }
                else
                {
                    pointNum = 0;
                }
                waitTime = 0.5f;
            }
            else
                waitTime -= Time.deltaTime;
        }

        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            //Debug.Log("Reverse Trigger");
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    private void Death()
    {
        anim.SetBool("dead", true);
        isAlive = false;
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
            health = 0;
            Death();
        }
    }

    private void BarFiller()
    {
        bar.fillAmount = health / maxHealth;
        bloodAmount.text = health + " / " + maxHealth;
    }
}
