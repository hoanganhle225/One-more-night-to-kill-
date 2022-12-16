using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public Mantis mantis;

    void Start()
    {
        // lấy component EnemiesController(script) của đối tượng có tag Mantis
        // mantis = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mantis>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        // nếu va chạm với đối tượng có tag là Player thì bật theo dõi
        if(col.CompareTag("Player"))
        {
            mantis.follow = true;
        }
    }
}
