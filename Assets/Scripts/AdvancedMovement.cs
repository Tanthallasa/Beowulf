using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class AdvancedMovement : MonoBehaviour {
	public enum State {
		Idle,
		Init,
		Setup,
		Run //action
	}

	public enum Turn {
		left = -1,
		none = 0,
		right = 1
	}

	public enum Forward {
		back = -1,
		none = 0,
		forward = 1
	}
	public float rotateSpeed = 200; //the speed our character turns at
	public float walkSpeed = 5; //the speed our character walks at
	public float runSpeed = 2; //how fast the player runs compared to
	public float gravity = 20; //setting for gravity

	public CollisionFlags collisionFlags; //collisionFlags we have from last frame
	private Transform myTransform;
	private CharacterController controller;
	private Vector3 moveDirection; // direction our character is moving

	private Turn turn;
	private Forward forward;
	private bool run;

	private State state;
	private BaseCharacter _bc;
	public AnimationClip meleeAttack1; 
	public AnimationClip idleIncombat1h;
	public string idleAnimName;


	// Called before script starts
	public void Awake ()
	{
		myTransform = transform;
		controller = GetComponent <CharacterController> ();
		state = AdvancedMovement.State.Init;
		_bc = gameObject.GetComponent<BaseCharacter> ();
	}

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			switch (state) {
			case State.Init:
				Init();
				break;
			case State.Setup:
				SetUp();
				break;
			case State.Run:
				ActionPicker();
				break;
			//default:
				}
			yield return null;
			}
	}
	
	private void Init () {
		if (!GetComponent<CharacterController>()) return;
		if (!GetComponent<Animation>()) return;

		state = AdvancedMovement.State.Setup;

	}

	private void SetUp() {
		moveDirection = Vector3.zero; // zeros out all 3 axis
	
		animation.Stop();
		animation.wrapMode = WrapMode.Loop;
		animation.Play ("IDLE");

		turn = AdvancedMovement.Turn.none;
		forward = AdvancedMovement.Forward.none;
		run = true;

		state = AdvancedMovement.State.Run;
	}

	private void ActionPicker () {
		//allows the player to turn left and right
		myTransform.Rotate (0, (int)turn * Time.deltaTime * rotateSpeed, 0);

		if (controller.isGrounded) 
		{
			//Debug.Log("On the ground");

			moveDirection = new Vector3(0, 0, (int) forward);
			moveDirection = myTransform.TransformDirection(moveDirection).normalized;
			moveDirection *= walkSpeed; 

			if(forward != Forward.none) 
			{
				if(run) 
				{
					moveDirection *= runSpeed;
					Run ();
				}
				else 
				{
					Walk ();
				}
			}
			else
			{
				Idle();
			} 
		} 
			else { //this is where it will pull main character down to ground
				//Debug.Log("Not on the ground");
				if((collisionFlags & CollisionFlags.CollidedBelow) == 0) {
					
				}
			}

		moveDirection.y -= gravity * Time.deltaTime; //smooth falling

		collisionFlags = controller.Move (moveDirection * Time.deltaTime);
	}

	public void MoveMeForward(Forward z) {
		forward = z;
	}

	public void ToggleRun() {
		run = !run;
	}

	public void RotateMe(Turn y) {
		turn = y;
	}

	public void Idle() {
		animation.CrossFade ("IDLE");
			//if(idleAnimName == "")
			//	return;
			
			//if( !_bc.InCombat )
			//	animation.CrossFade(idleAnimName);
			//else
			//	Debug.LogWarning( "Attack Idle" );
	}

	public void Walk() {
		animation.CrossFade ("SwordCautiousWalk");
	}

	public void Run() {
		animation.CrossFade ("SwordCOmbatRun");
	}

	public void PlayMeleeAttack() {
		Debug.Log ("Melee Attack Animation");
		if (meleeAttack1 == null) {
						Debug.LogWarning ("NEED ANIMATION");
						return;
				}

		//Debug.Log("Length: " + meleeAttack1.length);
		//Debug.Log("Speed: " + meleeAttack1.length);

		animation[meleeAttack1.name].speed = animation[meleeAttack1.name].length / -1f;
		animation.Play (meleeAttack1.name);
	}
}
