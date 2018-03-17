using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour {
	public GameObject playerObj;		//player object
	public Text CurrentScoreText;		//represent current score
	public int CurrentScore;
	public int NewPoint;
	public bool playing = true;			//play or stop
	public Image health;
	public Image boosterba;
	int HealthLevel;

	public GameObject Endpanel;
	public Text ScoreText;
	public Text PointText;

	public GameObject []block;	 		// Make new block
	public GameObject HeroZone;			// Hero presently stand stage
	public GameObject NextZone;			// nextzone
	public float checkstage = 1f;
	// Use this for initialization
	void Start () {
		CurrentScore = 0;
		HealthLevel = PlayerPrefs.GetInt ("Health lv", 1);
		AudioManager.Instance.BackgroundSoundPlaynStop (false);
		 
	}
	// Update is called once per frame
	void Update () {
		
		Move ();
		if (playerObj.activeInHierarchy) {
			CurrentScore++;
			CurrentScoreText.text = "Score : " + (CurrentScore / 2).ToString ();
		}
		if (playing) {
			if (HealthLevel == 1) {
				health.fillAmount -= 0.0010f;	
			}
			if (HealthLevel == 2) {
				health.fillAmount -= 0.0009f;
			}
			if (HealthLevel == 3) {
				health.fillAmount -= 0.0008f;
			}
				
			if (health.fillAmount == 0) {
				NewPoint = (CurrentScore / 9 ) ; // How many get Point
				PlayerPrefs.SetInt ("AddPoint", NewPoint);
				playerObj.SetActive (false);
				Endpanel.SetActive (true);
				playing = false;

			}
		}

		if (!playing) {
			ScoreText.text = (CurrentScore / 2).ToString ();
			PointText.text = (CurrentScore / 9).ToString ();

		}

	
	}

	void Move(){
		if (playerObj.transform.position.x >= 35f * checkstage) {
			checkstage++;
			HeroZone = NextZone;
			Make ();
		}
	}

	void Make(){
		int RandomBlock = Random.Range (0, block.Length);
		NextZone = Instantiate(block[RandomBlock], new Vector3(35f * checkstage,-2.5f,-3f), transform.rotation);
	}


}
