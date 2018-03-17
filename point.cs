using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour {
	public GameObject gamecontrolObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		gamecontrolObj.GetComponent<gamecontroller> ().CurrentScore += 1000;
		Destroy (gameObject);// disappear if collide coin
	}
}
