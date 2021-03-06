﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour 
{

	// zet op Drone
	// sleep de player op playerHealthScript in inspector
	// startTimeBtwAttack rond 1 á 1.5 sec
	// attack range 1.1
	// damage 2
	// health kan jij bepalen
	// attackpos in t midden van de drone 
	// ook in de inspector erin slepen

	GameObject Player; 
	public PlayerHealth playerHealthScript;

	private float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public int health;
	public Transform attackPos;
	public LayerMask whatIsPlayer;
	public float attackRange;
	public int damage;

	void Start ()
	{
		Player = GameObject.Find("PlayerHealth");
		playerHealthScript = Player.GetComponent<PlayerHealth>();
	}
	
	
	void Update ()
	{
		if(timeBtwAttack <= 0)
		{
		
				Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
				for(int i = 0; i < playersToDamage.Length; i++) 
				{
					playersToDamage[i].GetComponent<PlayerHealth>().TakeDamage(damage);
				}
		timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= Time.deltaTime; 
		}
	}	
	public void OnDrawGizmosSelected()
	{
		{	
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(attackPos.position, attackRange);
		}	
	}

}