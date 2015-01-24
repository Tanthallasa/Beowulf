using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//public first to watch in inspector, change to private later.
	public Transform target;
	public int moveSpeed; //tell target how fast it can move
	public int rotationSpeed;
	public int maxDistance; // max distance away form you, before moving towards you

	private Transform myTransform;

	void Awake() {
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");

		target = go.transform;

		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);

		// look at target
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	

		// move towards target
		if (Vector3.Distance (target.position, myTransform.position) > maxDistance) {
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
