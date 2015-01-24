using UnityEngine;
using System.Collections;
using System;

public static class GameSetting {
	
	//base values for different attacks
	public const float BASE_MELEE_ATTACK_TIMER = 2.0f;
	public const float BASE_MELEE_ATTACK_SPEED = 2.0f;
	public const float BASE_MELEE_RANGE = 3.5f;
	
	public const string MALE_MODEL_PATH = "Character";
	public static string[] maleModels = { "", "" };
	private const string PLAYER_POSITION = "Player Position";
	public static Vector3 startingPos = new Vector3( 522, 56, 1114 );
	private const string CHARACTER_MODEL_INDEX = "Model Index";

	static GameSetting() {
	}

	public static Vector3 LoadPlayerPosition() {
		Vector3 temp = new Vector3(
			PlayerPrefs.GetFloat( PLAYER_POSITION + "x", startingPos.x ),
			PlayerPrefs.GetFloat( PLAYER_POSITION + "y", startingPos.y ),
			PlayerPrefs.GetFloat( PLAYER_POSITION + "z", startingPos.z )
			);
		return temp;
	}

	public static int LoadCharacterModelIndex() {
		return PlayerPrefs.GetInt( CHARACTER_MODEL_INDEX, 1 );
	}

}