using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PC : BaseCharacter {
	public bool initialized = false;
	
	private static PC instance = null;
	public static PC Instance {
		get {
			if ( instance == null ) {
				//				Debug.Log( "***PC - Instance***" );
				GameObject go = Instantiate( Resources.Load(
					GameSetting.MALE_MODEL_PATH + GameSetting.maleModels[ GameSetting.LoadCharacterModelIndex() ] ),
				                            GameSetting.LoadPlayerPosition(),
				                            Quaternion.identity ) as GameObject;
				
				PC temp = go.GetComponent<PC>();
				
				if( temp == null )
					Debug.LogError( "Player Prefab does not contain an PC script. Please add and configure." );
				
				instance = go.GetComponent<PC>();
				
				go.name = "PC";
				go.tag = "Player";
			}
			
			return instance;
		}
	}
	
	public void Initialize() {
		//		Debug.Log( "***PC - Initialize***" );
		if( !initialized )
			LoadCharacter();
	}

	public new void Awake() {
		//		Debug.Log( "***PC - Awake***" );
		
		base.Awake();
		
		instance = this;
	}

	public void LoadCharacter() {
		initialized = true;
	}

}

