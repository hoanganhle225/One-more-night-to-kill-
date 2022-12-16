using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public Transform player;
	public float lineOfSite;
	public bool isFlipped = false;
	public Animator anim;
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, lineOfSite);
	}
	public bool FollowPlayer()
	{
		float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
		if (distanceFromPlayer < lineOfSite)
		{
			anim.SetBool("isRun", true);
			return true;
		}
		//anim.SetBool("isRun", false);
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

}
