using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public Mantis mantis;
    // Start is called before the first frame update
    void Start()
    {
        // lấy component EnemiesController(script) của đối tượng có tag Mantis
        // mantis = GameObject.GetComponent<Mantis>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        // nếu va chạm với đối tượng có tag là Player thì bật theo dõi
        if (col.CompareTag("Player"))
        {
            mantis.Attack = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        // nếu va chạm với đối tượng có tag là Player thì bật theo dõi
        if (col.CompareTag("Player"))
        {
            mantis.Attack = false;
        }
    }
}
