using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charactermove : MonoBehaviour {
	public float characterspeed = 3.8f; 	// character's speed

	public float jumpforce = 525f;			// character's jumpforce

	public bool boosterswitch = false;		// character's booster speed
	public bool charging=false;
	int BoosterLevel;
	int ChargeLevel;

	public bool isjumping = false; 			// character can jump only one


	public int direction =0; //0 left, 1 right
	bool inputright = false;
	bool inputleft = false;
	public bool inputjump = false; //버튼으로 쓸때 활성화시킨다.
	public bool inputbooster = false;

	Vector3 prevV;
	public GameObject gamecontrolobj;

	public float hitTimer=2f;
	private Image boostfever;



	// Use this for initiali zation

	void Start () {
		prevV = Vector3.zero;
		boostfever = gamecontrolobj.GetComponent<gamecontroller> ().boosterba;
		BoosterLevel = PlayerPrefs.GetInt ("Booster lv" , 1);
		ChargeLevel = PlayerPrefs.GetInt ("Charge lv" , 1);
		//print(PlayerPrefs.GetInt ("Booster lv"));

	}	

	// Update is called once per frame
	void Update () {
		hitTimer += Time.deltaTime;
		if ((inputright || Input.GetKey (KeyCode.RightArrow))) {
			GetComponent<SpriteRenderer> ().flipX = false;
			transform.Translate (Vector3.right * characterspeed * Time.deltaTime);
			direction = 1;

		} 

		else if ((inputleft || Input.GetKey (KeyCode.LeftArrow))) {
			GetComponent<SpriteRenderer> ().flipX = true;
			transform.Translate (Vector3.left * characterspeed * Time.deltaTime);
			direction = 0;

		} 


		
		if (inputjump || Input.GetKey(KeyCode.UpArrow)){//나중에 버튼함수도 넣는다. 
			if (!isjumping) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpforce));
				isjumping = true;


			}
		}
		if (inputbooster || Input.GetKeyDown (KeyCode.Space)) {
			if(boosterswitch==false && charging==false)
				boosterswitch = true;
		}


		if (boosterswitch) {
			if (!charging) {
				
				if (BoosterLevel == 1) {
					characterspeed = 7f;
					boostfever.fillAmount -= 0.03f;
				}
				if (BoosterLevel == 2) {
					characterspeed = 8f;
					boostfever.fillAmount -= 0.025f;
				}
				if (BoosterLevel == 3) {
					characterspeed = 10f;
					boostfever.fillAmount -= 0.02f;
				}

				if (boostfever.fillAmount == 0) {
					charging = true;
				}
			} 
			else {
				characterspeed = 3.2f;

				if (ChargeLevel == 1) {
					boostfever.fillAmount += 0.004f;
				}
				if (ChargeLevel == 2) {
					boostfever.fillAmount += 0.0045f;
				}
				if (ChargeLevel == 3) {
					boostfever.fillAmount += 0.005f;
				}


				if (boostfever.fillAmount >=1) {
					boosterswitch = false;
					charging = false;
				}
			}
		}

		prevV = GetComponent<Rigidbody2D> ().velocity;
	}


	public void RightBtnOn(){
		inputright = true;
	}
	public void RightBtnOff(){
		inputright = false;
	}
	public void LeftBtnOn(){
		inputleft = true;
	}
	public void LeftBtnOff(){
		inputleft = false;
	}
	public void JumpBtnOn(){
		inputjump = true;
	}
	public void JumpBtnOff(){
		inputjump = false;
	}
	public void BoosterBtnOn(){
		inputbooster = true;
	}
	public void BoosterBtnoff(){
		inputbooster = false;
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "floar" || (col.transform.tag == "box" && prevV.y <= 0f)) {
			isjumping = false; // if jump end

		}

		if (col.transform.tag == "enemy") {
			if (hitTimer >= 1f) {
				gamecontrolobj.GetComponent<gamecontroller> ().health.fillAmount -= 0.2f;
				hitTimer = 0f;
				if (direction == 1) {
					transform.Translate (Vector3.left * 2f * Time.deltaTime);
				}
				if (direction == 0) {
					transform.Translate (Vector3.right * 2f * Time.deltaTime);
				}
			}
		}

					
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag=="box")
		if (col.transform.position.y <= transform.position.y && GetComponent<Rigidbody2D>().velocity.y <=0) {
			GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			isjumping = false;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.transform.tag=="box")
			GetComponent<Rigidbody2D> ().gravityScale = 2.5f;
		
	}
}

// int JFI = Input.Gettouch(Input.touchcount-1).finger Io
