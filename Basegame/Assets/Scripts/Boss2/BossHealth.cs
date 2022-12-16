using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health;
	public bool isInvulnerable = false;
	
	public GameObject deathEffect;

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bullet")){
			TakeDamage(2);
        }
    }
	
	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 10)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
		Destroy(death, 1f);

	}

}
