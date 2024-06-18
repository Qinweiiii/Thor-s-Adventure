using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour
{
    public Transform spherePoint;
    public GameObject sphere;
    public GameObject player;
    
    public int damage;
    public float time;

    private Animator anim;
    private PolygonCollider2D coll2D;

    private bool isMagicSphere;
    //private static int count = 0;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        isMagicSphere = Input.GetKeyDown(KeyCode.K);
        Attack();
    }

    void Attack()
    {
        if (isMagicSphere)
        {
            anim.SetBool("MagicSphere", isMagicSphere);
            //count++;
            StartCoroutine(sphereCreation());
        }
        else if (!isMagicSphere)
        {
            anim.SetBool("MagicSphere", isMagicSphere);
        }
    }

    IEnumerator sphereCreation()
    {
        yield return new WaitForSeconds(time);
        Vector3 sphereScale = player.transform.localScale;
        if (sphereScale.x < 0)
        {
            Instantiate(sphere, spherePoint.position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            Instantiate(sphere, spherePoint.position, spherePoint.rotation);
        }

    }

}
