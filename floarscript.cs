using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floarscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.position.y <= transform.position.y) {
			GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		GetComponent<Rigidbody2D> ().gravityScale = 4f;
	}
}
