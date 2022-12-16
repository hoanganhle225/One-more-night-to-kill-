using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionFly : MonoBehaviour
{
    public Dragon dragon;

    private void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Boss").GetComponent<Dragon>();
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        // nếu người chơi thoát ra khỏi tầm nhìn thì đậu xuống - tăng trọng lực
        if (col.CompareTag("Player") && dragon.fly == true)
        {
            dragon.Attack = false;
            dragon.animator.SetBool("Attack", dragon.Attack);
            dragon.r2.bodyType = RigidbodyType2D.Dynamic;
            dragon.r2.gravityScale = 0.2f;
        }
    }
}
