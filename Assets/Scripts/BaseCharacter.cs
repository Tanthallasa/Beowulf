using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	public float meleeAttackTimer = GameSetting.BASE_MELEE_ATTACK_TIMER;
	public float meleeAttackSpeed = GameSetting.BASE_MELEE_ATTACK_SPEED;
	public float meleeResetTimer = 0f;

	private bool inCombat;

	public virtual void Awake() {

		inCombat = false;
	}

	public bool InCombat {
		get{ return inCombat; }
		set{ inCombat = value; }
	}
}

