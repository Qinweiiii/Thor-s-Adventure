using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetKnife : MonoBehaviour
{
    public GameObject bloodyknife;
    public GameObject temp;
    public Transform endpoint;
    public CircleCollider2D circleCollider;
    //public Transform destination;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            Debug.Log("Bloody Knife is alive!");
            temp.transform.SetParent(collision.gameObject.transform, true);
            bloodyknife.SetActive(true);
            circleCollider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            Debug.Log("Bloody Knife is alive!");
            temp.transform.SetParent(collision.gameObject.transform, false);
            bloodyknife.SetActive(false);
            circleCollider.enabled = false;
        }
    }
}
