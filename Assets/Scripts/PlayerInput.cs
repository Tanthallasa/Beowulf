using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))]
public class PlayerInput : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//grab input from user to either move forward, backwards or not move at all
		if (Input.GetButton ("Move Forward")) 
		{
			if(Input.GetAxis("Move Forward") > 0) 
			{
				SendMessage("MoveMeForward", AdvancedMovement.Forward.forward);
			}
			else 
			{
				SendMessage("MoveMeForward", AdvancedMovement.Forward.back);
			}
		}
		if (Input.GetButtonUp ("Move Forward")) 
		{
			SendMessage("MoveMeForward", AdvancedMovement.Forward.none);
		}

		//turn
		if (Input.GetButton ("Rotate Player")) 
		{
			if(Input.GetAxis("Rotate Player") > 0) 
			{
				SendMessage("RotateMe", AdvancedMovement.Turn.right);
			}
			else 
			{
				SendMessage("RotateMe", AdvancedMovement.Turn.left);
			}
		}
		if (Input.GetButtonUp ("Rotate Player")) 
		{
			SendMessage("RotateMe", AdvancedMovement.Turn.none);
		}

		//run is toggled so that you only need to press it once isntead of hold it.
		if (Input.GetButtonDown ("Run"))  
		{
			SendMessage("ToggleRun");
		}
	}
}