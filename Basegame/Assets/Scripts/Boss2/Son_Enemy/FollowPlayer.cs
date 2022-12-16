using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform player;
	public float lineOfSight;
	public bool isFlipped = false;
	public Animator anim;
	int currenthealth;
	int maxhealth = 20;
	
	public HealthBar_Enemy health;
	public GameObject deathAffect;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, lineOfSight);
	}
	void Start()
	{
		currenthealth = maxhealth;
		health.SetMaxHealth(maxhealth);

	}
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bullet")){
			TakeDamage(2);
        }
    }
	public bool Follow()
	{
		float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
		if (distanceFromPlayer <= lineOfSight)
		{
			anim.SetBool("isRun", true);
			return true;
		}
        else
        {
			anim.SetBool("isRun", false);
        }
		return false;
	}
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
	public void TakeDamage(int damage)
	{
		currenthealth -= damage;
		SetCurrentHealth(currenthealth);
		if (currenthealth<=0)
        {
			Die();
        }
	}
	void Die()
    {
		GameObject death = Instantiate(deathAffect, transform.position, Quaternion.identity);
		foreach (Transform child in transform)
		{
			GameObject.Destroy(child.gameObject);
			Destroy(this.gameObject);
			Destroy(death, 1f);
		}
	}

    private void SetCurrentHealth(int currentHealth)
    {
		health.SetHealth(currentHealth);
	}
}
