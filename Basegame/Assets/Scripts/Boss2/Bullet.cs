using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactAffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    { 
        if(col.tag == "Enemy" || col.tag == "Boss"){
            Destroy(this.gameObject);
        } else{
            Destroy(this.gameObject, 3f);
        }

        GameObject impact = Instantiate(impactAffect, transform.position, transform.rotation);
        if(impactAffect){
            Destroy(impact, 0.8f);
        }
        
    }
}
