using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float dmg = 10f, speed = 5f;
    public Transform tranfPlayer;
    public PlayerHealth player;
    Vector3 target;
    void Start()
    {
        Destroy(this.gameObject, 5); // tự hủy sau 5s nếu không chạm Player
        // lấy tọa độ người chơi
        tranfPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // định hướng viên đạn bay thẳng theo hướng người chơi
        float x1, y1, x2, y2;
        x1 = transform.position.x;
        y1 = transform.position.y;
        x2 = tranfPlayer.position.x;
        y2 = tranfPlayer.position.y;
        // nếu vị trí của điểm A nằm bên trái điểm B
        if (transform.position.x < tranfPlayer.position.x)
            // kéo dài điểm dừng về phí phải của trục tọa độ
            target = new Vector2(10, ((y2 - y1) * x1 + (x1 - x2) * y1 - 10 * (y2 - y1)) / (x1 - x2));
        else
            target = new Vector2(-10, ((y2 - y1) * x1 + (x1 - x2) * y1 - (-10) * (y2 - y1)) / (x1 - x2));
    }

    // Update is called once per frame
    void Update()
    {
        // cầu lửa bay tới người chơi
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            // chạm player thì gây dame ..
            player.TakeDamage(1);
            // và tự hủy
            Destroy(this.gameObject);
        }
    }
}
