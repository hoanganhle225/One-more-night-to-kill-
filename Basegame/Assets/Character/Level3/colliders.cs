using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
    }
}
