using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	
		public int maxHealth = 100;
		public int curHealth = 100;
		public float healthBarLength;

		// Use this for initialization
		void Start ()
		{
				healthBarLength = Screen.width / 2;
		}
	
		// Update is called once per frame
		void Update ()
		{
				adjustCurrentHealth (0);
		}

		// Visible health bar
		void OnGUI ()
		{
				GUI.Box (new Rect (10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
				
				
		}

		public void adjustCurrentHealth (int adj)
		{
				curHealth += adj;

				//dont want below health to be 0
				if (curHealth < 0)
						curHealth = 0;

				if (curHealth > maxHealth)
						curHealth = maxHealth;

				if (maxHealth < 1)
						maxHealth = 1;

				healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
		}
}