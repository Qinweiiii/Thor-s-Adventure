using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesGeneration : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float xRandomPosition = 0f;
    [SerializeField] private float yRandomPosition = 0f;
    //[SerializeField][Range(0, 100)] private float chanceToDrop = 50f;

    [Header("Rewards")]
    [SerializeField] private GameObject[] rewards;

    public float time = 0.5f;
    private Vector3 rewardRandomPosition;
    private GameObject reward;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CircleAttack"))
        {
            Destroy(gameObject);
            //Invoke("GiveReward", 0.5f);
            GiveReward();
        }
    }

    void GiveReward()
    {
        //yield return new WaitForSeconds(time);
        rewardRandomPosition.x = Random.Range(-xRandomPosition, xRandomPosition);
        rewardRandomPosition.y = Random.Range(-yRandomPosition, yRandomPosition);
        int rndNo = Random.Range(0, rewards.Length);
        Debug.Log("Now Generated Reward: " + rndNo);
        Instantiate(rewards[rndNo], transform.position + rewardRandomPosition, Quaternion.identity);
    }
}
