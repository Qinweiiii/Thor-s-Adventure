using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z += 13f;
        transform.eulerAngles = rotation;
    }
}
