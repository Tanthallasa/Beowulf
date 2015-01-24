using UnityEngine;
using System.Collections;

//NOTE: uncomment/edit to have camera behind main player

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	//public Camera mainCamera;
	//public float zOffset;
	//public float yOffset;
	//public float xRotationOffset;
	//private GameObject _pc;

	// Use this for initialization
	void Start () {
		Instantiate (playerCharacter, Vector3.zero, Quaternion.identity); // setting character behind, set _pc = "this(being text<--)" as GameObject

		//zOffset = -2.5f;
		//yOffset = 2.5f;
		//xRotationOffset = 22.5f;

		//mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
		//mainCamera.transform.Rotate (xRotationOffset, 0, 0);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
