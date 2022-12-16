using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public Rigidbody2D r2;
    public float damage;
    public GameObject fireball;
    public Transform shoot1;
    public Transform shoot2;
    public float speed = 2f,speedFly = 1f, maxhealth = 1000f, currentHealth;
    
    public Vector3 target, randomFly; // tạo một vector3 để random điểm ngẫu nhiên, tí nữa sẽ đặt taget là vị trí player
    public bool Attack = false, fly = false, run = false, follow = false;
    public float randX;

    void Start()
    {
        // lấy vị trí của người chơi
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxhealth;
        run = true;
        r2.bodyType = RigidbodyType2D.Static;
        animator.SetBool("Run", run);
        MoveDragon();
    }

    // tự di chuyển
    void MoveDragon()
    {
        randX = Random.Range(220f, 285f); // vị trí rồng có thể di chuyển
        target = new Vector2(randX, transform.position.y); // làm mới điểm X, Y để di chuyển tới vị trị này
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
        }
        if (transform.position != target && run == true)
        {
            // di chuyển đến vị trí ngẫu nhiên
            if (follow)
                target = new Vector2(player.position.x,player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x < target.x)
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
            if (transform.position == target && run == true && follow != true)
            {
                MoveDragon();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // kiếm chạm dragon thì truyền 50 dame vào hàm DameDragon
        if (col.CompareTag("Bullet")){
            DameDragon(damage);
        }
    }
    // chết thị hủy Objecr Rồng
    public void DeadBoss()
    {
        Destroy(gameObject);
    }

    public void Fireball()
    {
        Instantiate(fireball, shoot1.position, transform.rotation);
        Instantiate(fireball, shoot2.position, transform.rotation);
    }
    void DameDragon(float dame)
    {
        // bị mất máu và bật fly
        currentHealth -= dame;
        fly = true;
        run = false;
        animator.SetBool("Run", run);
        animator.SetBool("Fly", fly);
        FlyDragon();
        Fly();

    }
    void FlyDragon()
    {
        // chọn ngẫu nhiên 2 điểm X Y để di chuyển tới
        float randX = Random.Range(220f, 285f);
        float randY = Random.Range(0f, 10f);
        if (transform.position.x < randX)
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

        randomFly = new Vector2(randX, randY);
    }
    void Fly()
    {
        if (transform.position != randomFly && fly == true)
        {
            // di chuyển đến vị trí ngẫu nhiên
            transform.position = Vector2.MoveTowards(transform.position, randomFly, speedFly * Time.deltaTime);
            Invoke("Fly", 0.02f);
        }
        // đuổi theo tới vị trị của đối tượng thì tấn công
        // trong trạng thái tự di chuyển, khi đến vị trí này thì gọi Move để randX tự di chuyển tiếp
        if (transform.position == randomFly && fly == true)
        {
            FlyDragon();
        }
    }
    public void FlyShoot()
    {
        Instantiate(fireball, shoot1.position, transform.rotation);
        Instantiate(fireball, shoot2.position, transform.rotation);
    }
    public void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
