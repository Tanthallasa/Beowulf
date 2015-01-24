
using UnityEngine;
using System.Collections;
using System;					//added to access the enum

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(SphereCollider))]
[RequireComponent (typeof(AI))]
[RequireComponent (typeof(AdvancedMovement))]

public class Enemy : BaseCharacter {

	
	new void Awake() {
		base.Awake();
	}



}
