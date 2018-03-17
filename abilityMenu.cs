using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class abilityMenu : MonoBehaviour {
	public Text HealthLvtext;
	public Text BoosterLvtext;
	public Text ChargeLvtext;
	public Text Pointtext;
	public int HealthLv; 
	public int BoosterLv;
	public int ChargeLv;
	int Nowpointnumber;
	int AddPoint;


	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		HealthLv = PlayerPrefs.GetInt("Health lv" , 1);
		BoosterLv = PlayerPrefs.GetInt ("Booster lv", 1);
		ChargeLv = PlayerPrefs.GetInt ("Charge lv", 1);

		Nowpointnumber = PlayerPrefs.GetInt ("Point" , 0);
		AddPoint = PlayerPrefs.GetInt ("AddPoint");

		Nowpointnumber += AddPoint;
		PlayerPrefs.SetInt ("AddPoint", 0);
		PlayerPrefs.SetInt ("Point",Nowpointnumber);
		Pointtext.text = "Point : " + (Nowpointnumber).ToString ();

				



	

	}
	
	// Update is called once per frame

	void Update () {
		
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene (1);
		}

		if (HealthLv == 1) {
			HealthLvtext.text = "Health Level : " + (HealthLv).ToString () + " (50p 필요)"; 		// gamecontroller에 있음

		}

		if (HealthLv == 2) {
			HealthLvtext.text = "Health Level : " + (HealthLv).ToString () + " (200p 필요)";

		}

		if (HealthLv == 3) {
			HealthLvtext.text = "Health Level : " + (HealthLv).ToString () + " (500p 필요)";
		}

		if (BoosterLv == 1) {
			BoosterLvtext.text = "Booster Level : " + (BoosterLv).ToString () + " (50p 필요)";		// charactermove에 있음

		}

		if (BoosterLv == 2) {
			BoosterLvtext.text = "Booster Level : " + (BoosterLv).ToString () + " (200p 필요)";		

		}

		if (BoosterLv == 3) {
			BoosterLvtext.text = "Booster Level : " + (BoosterLv).ToString () + " (500p 필요)";
		}

		if (ChargeLv == 1) {
			ChargeLvtext.text = "Charge Level : " + (ChargeLv).ToString ()+ " (50p 필요)";			// charactermove에 있음
		}

		if (ChargeLv == 2) {
			ChargeLvtext.text = "Charge Level : " + (ChargeLv).ToString () + " (200p 필요)";
		}

		if (ChargeLv == 3) {
			ChargeLvtext.text = "Charge Level : " + (ChargeLv).ToString () + " (500p 필요)";
		}
	}

	public void HealthUpBtn(){
		if (Nowpointnumber >= 50 && HealthLv == 1) {
			HealthLv = 2;
			Nowpointnumber -= 50;
			PlayerPrefs.SetInt ("Health lv", HealthLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			HealthLvtext.text = "Health Level : " + (HealthLv).ToString () + " (200p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}

		else if (Nowpointnumber >= 200 && HealthLv == 2) {
			HealthLv = 3;
			Nowpointnumber -= 200;
			PlayerPrefs.SetInt ("Health lv", HealthLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			HealthLvtext.text = "Health Level : " + (HealthLv).ToString () + " (500p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}

	}

	public void BoosterUpBtn(){
		if (Nowpointnumber >= 50 && BoosterLv == 1) {
			BoosterLv = 2;
			Nowpointnumber -= 50;
			PlayerPrefs.SetInt ("Booster lv", BoosterLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			BoosterLvtext.text = "Booster Level : " + (BoosterLv).ToString () + " (200p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}

		else if (Nowpointnumber >= 200 && BoosterLv == 2) {
			BoosterLv = 3;
			Nowpointnumber -= 200;
			PlayerPrefs.SetInt ("Booster lv", BoosterLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			BoosterLvtext.text = "Booster Level : " + (BoosterLv).ToString () + " (500p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}

	}

	public void ChargeUpBtn(){
		if (Nowpointnumber >= 50 && ChargeLv == 1) {
			ChargeLv = 2;
			Nowpointnumber -= 50;
			PlayerPrefs.SetInt ("Charge lv", ChargeLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			ChargeLvtext.text = "Charge Level : " + (ChargeLv).ToString () + " (200p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}

		else if (Nowpointnumber >= 200 && ChargeLv == 2) {
			ChargeLv = 3;
			Nowpointnumber -= 200;
			PlayerPrefs.SetInt ("Charge lv", ChargeLv);
			PlayerPrefs.SetInt ("Point", Nowpointnumber);
			ChargeLvtext.text = "Charge Level : " + (ChargeLv).ToString () + " (500p 필요)";
			Pointtext.text = "Point : " + (Nowpointnumber).ToString ();
		}
	}
}
