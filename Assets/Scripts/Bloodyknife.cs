using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodyknife : MonoBehaviour
{
    public float speed = 50f;
    public Transform target;
    public int damage = 10;
    private static bool isHurt;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CarpetKnife").GetComponent<CarpetKnife>().temp.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = transform;
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Damage is triggered");
        }
    }
}
