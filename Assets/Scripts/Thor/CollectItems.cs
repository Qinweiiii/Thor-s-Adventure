using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private Text medicineNo;
    [SerializeField] private Text clueNo;
    [SerializeField] private Text keyNo;
    public int medicineCount;
    public int clueCount;
    public int keyCount;
    public float time = 1f;

    public ThorMovement TM;

    // Start is called before the first frame update
    void Start()
    {
        medicineCount = 0;
        clueCount = 0;
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        medicineNo.text = "" + medicineCount;
        clueNo.text = "" + clueCount;
        keyNo.text = "" + keyCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Medicine"))
        {
            SoundManager.PlayCollectItems();
            medicineCount++;
            Debug.Log("Medicine Count: " + medicineCount);
            Debug.Log("Triggered by " + gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Clue"))
        {
            SoundManager.PlayCollectItems();
            clueCount++;
            Debug.Log("Clue Count: " + clueCount);
            Debug.Log("Triggered by " + gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            SoundManager.PlayCollectItems();
            keyCount++;
            Debug.Log("Key Count: " + keyCount);
            Debug.Log("Triggered by " + gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}
