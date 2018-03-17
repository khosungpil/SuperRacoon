using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public float Enemyspeed = 0.02f;
	public bool EnemyDrc = false;

	// Use this for initialization
	void Start () {
					
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyDrc) {
			GetComponent<SpriteRenderer> ().flipX = false;
			transform.Translate (Vector3.right * Enemyspeed);
		}

		if (!EnemyDrc) {
			GetComponent<SpriteRenderer> ().flipX = true;			
			transform.Translate (Vector3.left * Enemyspeed);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "enemyBlock") {
			EnemyDrc = !EnemyDrc;
		}			
	}
}
