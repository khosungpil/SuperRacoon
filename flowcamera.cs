using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowcamera : MonoBehaviour {
	public GameObject player;
	Transform playerposition;



	// Use this for initialization
	void Start () {		
		playerposition = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tV = Vector3.Lerp (transform.position, playerposition.position, 3f * Time.deltaTime);
		tV.z = -10f;
		transform.position = tV;
			
	}

		



}
