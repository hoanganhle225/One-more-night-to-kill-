using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantis : MonoBehaviour
{
    public Animator animator;
    public GameObject boss;
    public Transform transfromBoss;
    public Transform player;
    public float damage;
    public GameObject healthSlider;
    public float speed = 1f, maxHealth, currentHealth;
    public Vector3 target; // tạo một vector3 để random điểm ngẫu nhiên, tí nữa sẽ đặt taget là vị trí player
    public bool Attack = false;
    public bool follow = false;
    float oldRandX;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        oldRandX = transform.position.x;
        Move();
        // lấy vị trí của người chơi
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthSlider.SetActive(true);      
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0){
            this.gameObject.layer = 13;
            Destroy(this.gameObject, 1f);
        }

        if (transform.position != target)
        {
            // di chuyển đến vị trí target
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        // đuổi theo tới vị trị của đối tượng thì tấn công
         animator.SetBool("MantisAttack", Attack);
        // trong trạng thái tự di chuyển, khi đến vị trí này thì gọi Move để randX tự di chuyển tiếp
        if (transform.position == target && follow != true)
        {
            Move();
        }
        if (follow == true)
        {
            FollowPlayer();
            follow = false;
        }
    }
        private void OnTriggerEnter2D(Collider2D col)
    {
        // kiếm chạm dragon thì truyền 50 dame vào hàm DameDragon
        if (col.CompareTag("Bullet")){
            DameMantis(damage);
        }
    }
    void FollowPlayer()
    {
        float randX = player.transform.position.x;
        if (randX > oldRandX)
        {
            // chạy về hướng phải mà mặt đang là hướng trái thì phải quay mặt lại tức thay đổi Scale.x , còn đúng hướng thì chỉ việc di chuyển
            if (transform.localScale.x < 0)
            {
                // làm mới Scale.x
                Vector3 Scale;
                Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                Vector3 Scale;
                Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
        }
        // lấy vị trí đối tượng
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    // tự di chuyển
    void Move()
    {
        float randX = Random.Range(195f, 215f);
        if (randX > oldRandX)
        {
            // chạy về hướng phải mà mặt đang là hướng trái thì phải quay mặt lại tức thay đổi Scale.x , còn đúng hướng thì chỉ việc di chuyển
            if (transform.localScale.x < 0)
            {
                // làm mới Scale.x
                Vector3 Scale;
                Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                Vector3 Scale;
                Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
        }
        oldRandX = randX;
        target = new Vector2(randX, transform.position.y); // làm mới điểm X, Y để di chuyển tới vị trị này
    }

    public void DameMantis(float dmg)
    {
        currentHealth -= dmg;
    }
}
