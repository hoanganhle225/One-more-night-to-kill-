using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Animator anim;

    public int Damage = 2;
    
    public int maxHealth = 20;
    public int Health;
    public Slider slider;

    public float enemySpeed;
    private float Face = 2.3f;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(maxHealth);
        Health = maxHealth;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0) ;
        SetHealth(Health);

        if (Health <= 0)
        {
            anim.SetBool("Dying", true);
            
            this.gameObject.layer = 13;
            if(stateInfo.IsName("Dying") && stateInfo.normalizedTime >= 1.0f)
            {
                Destroy(this.gameObject);
            }
            return;
        }
        else
        {
            transform.position = transform.position + new Vector3(0.2f, 0, 0) * Face * enemySpeed * Time.deltaTime;
            transform.localScale = new Vector3(Face, 2.3f, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Back")
            Face = Face * (-1);
        if(col.tag == "Bullet"){
            Health = Health - 2;
            Destroy(col.gameObject);
        }
    }
    void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = Health;
    }

    void SetHealth(int Health)
    {
        slider.value = Health;
    }
}
