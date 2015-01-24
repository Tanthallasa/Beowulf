﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coolDown; // attack cool down's, so no spamming.
	public Animator anim;


	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f; 
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;

		if (attackTimer < 0)
			attackTimer = 0;


		if(Input.GetKeyUp(KeyCode.F)) {
			if (attackTimer == 0) {
				Attack();
				attackTimer = coolDown; //evertime we attack, cooldown gets set.
			}
		}
	}

	private void Attack() {
		float distance = Vector3.Distance (target.transform.position, transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot (dir, transform.forward);

		Debug.Log (direction); //statement checks

		if (distance < 2.5f) {
			if(direction > 0) {
				EnemyHealth eh = (EnemyHealth)target.GetComponent ("EnemyHealth");
				eh.adjustCurrentHealth (-10);
			}
		}
	}
}
