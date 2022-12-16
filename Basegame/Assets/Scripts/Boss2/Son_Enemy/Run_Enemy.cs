﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Enemy : StateMachineBehaviour
{
	public float speed = 5f;
	public float attackRange = 10f;
	Transform player;
	Rigidbody2D rb;
	FollowPlayer Enemy;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		Enemy = animator.GetComponent<FollowPlayer>();
	}
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Enemy.LookAtPlayer();
		if (Enemy.Follow() == true)
		{
			Vector2 target = new Vector2(player.position.x, rb.position.y);
			Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition(newPos);
		}
		else
		{
			animator.SetBool("isRun", false);
		}
		if (Vector2.Distance(player.position, rb.position) < attackRange)
		{
			animator.SetTrigger("Attack");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}
}