using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraflow : MonoBehaviour {
	public float xMargin = 4f; //distance in the x axis the player can move before the camera follows.
	public float yMargin = 4f; //distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f; // how smoothly the camera catches up with it's target movement in the x
	public float ySmooth = 8f; // how smoothly the camera catches up with it's target movement in the y
	public Vector2 maxXAndY; // the maximum x and y coordinates the camera can have.
	public Vector2 minXAndY; // the minimum x and y coordinates the camera can have.

	private Transform player; // reference to the player's transform.
	// Use this for initialization

	void Awake (){
		// setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	bool CheckXMargin(){
		//returns true if the distance between the camera and the player in the X axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin(){
		//returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate (){
		TrackPlayer ();
	}

	void TrackPlayer ()
	{
		//By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		//If the player has moved beyound the x margin.
		if (CheckXMargin())
			targetX = Mathf.Lerp (transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		//If the player has moved beyound the y margin.
		if (CheckYMargin())
			targetY = Mathf.Lerp (transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}

}
