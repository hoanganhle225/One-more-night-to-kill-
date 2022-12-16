using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TerritoryDragon : MonoBehaviour
{
    public Dragon dragon;

    private void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Boss").GetComponent<Dragon>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        // tấn công người chơi vào lãnh thổ
        if(col.CompareTag("Player") && dragon.run == true)
        {
            dragon.run = false;
            dragon.animator.SetBool("Run", dragon.run);
            dragon.Attack = true;
            dragon.animator.SetBool("Attack", dragon.Attack);
            dragon.follow = true; // thấy người chơi vào lãnh thổ thì dí theo luôn
            dragon.target = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
            dragon.speed = 2f;
            // hướng về phía Enemy
            if (dragon.transform.position.x < col.gameObject.transform.position.x)
            {
                // chạy về hướng phải mà mặt đang là hướng trái thì phải quay mặt lại tức thay đổi Scale.x , còn đúng hướng thì chỉ việc di chuyển
                if (dragon.transform.localScale.x < 0)
                {
                    // làm mới Scale.x
                    Vector3 Scale;
                    Scale = dragon.transform.localScale;
                    Scale.x *= -1;
                    dragon.transform.localScale = Scale;
                }
            }
            else
            {
                if (dragon.transform.localScale.x > 0)
                {
                    Vector3 Scale;
                    Scale = dragon.transform.localScale;
                    Scale.x *= -1;
                    dragon.transform.localScale = Scale;
                }
            }
        }    
        // chạm đất thì tắt fly và bật idle
        if(col.CompareTag("Ground") && dragon.fly == true)
        {
            dragon.fly = false;
            dragon.animator.SetBool("Fly", dragon.fly);
            dragon.run = true;
            dragon.animator.SetBool("Run", dragon.run);
            dragon.r2.gravityScale = 0; // tắt trọng lực
            dragon.r2.bodyType = RigidbodyType2D.Static;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        // người chơi ra khỏi lãnh thổ thì dừng tấn công
        if (col.CompareTag("Player") && dragon.fly == false)
        {
            dragon.run = true;
            dragon.animator.SetBool("Run", dragon.run);
            dragon.Attack = false;
            dragon.animator.SetBool("Attack", dragon.Attack);
        }
    }
}
