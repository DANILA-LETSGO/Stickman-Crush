using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	Stickman[] stickmans;

	bool complete = false;
	int timer = 0;
	public GameObject panel; // из инспектора
	public GameObject score_level; // из инспектора
	public GameObject stars_holder; // из инспектора


	void ChangeColorStars () {
		int count_stars = score_level.GetComponent<ScoreLevel> ().count_stars;
		stars_holder.transform.GetChild (0).gameObject.GetComponent<Image> ().color = new Color (1,1,1,1);
		if (count_stars > 1) {
			stars_holder.transform.GetChild (1).gameObject.GetComponent<Image> ().color = new Color (1,1,1,1);
		}
		if (count_stars > 2) {
			stars_holder.transform.GetChild (2).gameObject.GetComponent<Image> ().color = new Color (1,1,1,1);
		}
	}
	void CheckStickman () {
		for (int i = 0; i < stickmans.Length; i++) {
			if (stickmans [i].fall == false) {
				return;
			}
		}
		complete = true;
		panel.SetActive (true);
		score_level.GetComponent<ScoreLevel> ().Stars ();
		print (score_level.GetComponent<ScoreLevel> ().count_stars);
		ChangeColorStars ();

	}

	// Use this for initialization
	void Start () {
		stickmans = FindObjectsOfType<Stickman> ();



	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer >= 60) {
			if (complete == false) {
				CheckStickman ();
				timer = 0;
			}
		}
			
	}
}
