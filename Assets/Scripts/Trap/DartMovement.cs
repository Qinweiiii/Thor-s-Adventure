using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour
{
    public int damage = 5;
    
    [SerializeField] private GameObject[] points;
    [SerializeField] private float speed = 20f;
    private int pointNum = 1;
    private float waitTime = 0.1f;

    // Start is called before the first frame update
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed * Time.deltaTime);

        Vector3 rotation = transform.eulerAngles;
        rotation.z += 70f;
        transform.eulerAngles = rotation;

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
                waitTime = 0.1f;
            }
            else
                waitTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Thor")
        {
            collision.GetComponent<ThorMovement>().TakeDamage(damage);
            Debug.Log("Thor is hit by Dart");
        }
    }
}
