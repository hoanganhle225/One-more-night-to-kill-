using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MinotaurController : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo stateInfo;

    GameObject player;
    Vector3 targetPos;
    public float LineOfSight = 30f;
    public Transform BossWeaponSp;
    public GameObject BossWeapon;

    public int Health;
    public Slider slider;
    public int BossHealth = 20;
    public int BossDamage = 1;

    private float timeRate;
    public float bossSpeed;

    private Vector3 faceAttack = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Health = BossHealth;
        anim = gameObject.GetComponent<Animator>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        SetMaxHealth(BossHealth);
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0) ;
        SetHealth(Health);

        if (Health <= 0)
        {
            anim.SetBool("Taunt", false);
            anim.SetBool("Dying", true);
            
            this.gameObject.layer = 13;
            if(stateInfo.IsName("BossDying") && stateInfo.normalizedTime >= 1.0f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (distanceFromPlayer < 5f)
            {
                anim.SetBool("Taunt", false);
                anim.SetBool("Attack", true);
                if (Time.time > timeRate)
                {
                    timeRate = Time.time + 1.7f;
                    Instantiate(BossWeapon, BossWeaponSp.position, BossWeaponSp.rotation);
                }

            }
            else{
                anim.SetBool("Attack", false);
            }

            if ((distanceFromPlayer < LineOfSight) && (distanceFromPlayer > 5f))
            {
                anim.SetBool("Taunt", true);
                FaceTarget();
                Follow();
            }
            if(stateInfo.IsName("BossTaunt") && stateInfo.normalizedTime >= 1.0f)
            {
                anim.SetBool("Taunt", false);
            }
        }
    }
    void Follow()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        targetPos = player.transform.position;
        if(stateInfo.IsName("BossWalk"))
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos + faceAttack, ref velocity, bossSpeed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSight);
    }

    void FaceTarget()
    {
        if (transform.position.x > targetPos.x)
        {
            transform.localScale = new Vector3(-4, 4, 2);
            faceAttack = new Vector3(3, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 2);
            faceAttack = new Vector3(-3, 0, 0);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet"){
            Health = Health - 2;
            Destroy(col.gameObject);
        }
    }

    void SetMaxHealth(int BossHealth)
    {
        slider.maxValue = BossHealth;
        slider.value = Health;
    }

    void SetHealth(int Health)
    {
        slider.value = Health;
    }
}
