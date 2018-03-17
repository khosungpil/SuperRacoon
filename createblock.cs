using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createblock : MonoBehaviour {
	public GameObject block;
	int frame = 0;
	float y = 1f;
	float x;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		if (frame % 40 == 0) {
			y += Random.Range (0.4f, 1.0f);
			x = Random.Range (-2.8f, 2.8f);
			Instantiate(block, new Vector3(x,y,0), Quaternion.identity);
		}
	}
}
