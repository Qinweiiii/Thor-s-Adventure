using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThorMovement : MonoBehaviour
{

    public float speed = 3f;
    public float jumpSpeed = 3f;
    public float runSpeed = 5f;
    public GameObject dart;
    public GameObject magicCircle;

    public float health;
    public Image bar;
    public int maxHealth;
    [SerializeField] private Text bloodAmount;

    private bool facingRight = true;
    private Rigidbody2D rbody;
    private Animator anim;

    private float moveX;
    private float moveY;
    private bool moveJump;
    private bool moveRun;

    public AudioSource footstep;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // Control Horizontal Movement
        moveY = Input.GetAxisRaw("Vertical"); // Control Vertical Movement
        moveJump = Input.GetButton("Jump");
        moveRun = Input.GetKey(KeyCode.LeftShift);
        Move();
        Jump();
        BarFiller();
        magicCircleFinish();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ThorWalk"))
        {
            //SoundManager.PlayFootsteps();
        }
    }

    private void Move()
    {
        Vector2 moveVector = new Vector2(moveX, moveY);
        if (facingRight == false && moveX > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveX < 0)
        {
            Flip();
        }
        if (!moveRun)
        {
            anim.SetBool("run", moveRun);
            anim.SetFloat("speed", moveVector.magnitude);
            speed = 3f;
            if(moveVector.magnitude>0f)
            {
                footstep.enabled = true;
            }
            else
            {
                footstep.enabled = false;
            }
        }
        else
        {
            anim.SetBool("run", moveRun);
            speed = 5f;
        }
        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;
    }

    private void Jump()
    {
        if (moveJump)
        {
            anim.SetBool("jump", moveJump);
            rbody.velocity = Vector2.up * jumpSpeed;
        }
        else if (!moveJump)
        {
            anim.SetBool("jump", moveJump);
            jumpSpeed = 0;
            rbody.velocity = Vector2.up * jumpSpeed;
        }

        if (facingRight == false && moveX > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveX < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void Death()
    {
        anim.SetBool("died", true);
        Invoke("reloadScene", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DartTrigger")
        {
            dart.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Current health: " + health);
        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }

    private void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void finishScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void BarFiller()
    {
        bar.fillAmount = health / maxHealth;
        bloodAmount.text = health + " / " + maxHealth;
    }

    private void magicCircleFinish()
    {
        if (!GameObject.FindWithTag("Boss"))
        {
            magicCircle.SetActive(true);
            Invoke("finishScene", 0.7f);
        }
    }
}
