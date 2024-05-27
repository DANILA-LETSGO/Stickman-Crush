using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLevel : MonoBehaviour {

	float timer = 0;
	public int count_stars = 0;
	public int need_time_stars_1; 
	public int need_time_stars_2;

	bool showTime; //Вспомогательная переменная для вывода времени (но это не точно....)

	public void Start_Timer () {
		timer = Time.time;
	}
	public void Stars () {
		float elapsedTime = Time.time - timer; 
		if (elapsedTime < need_time_stars_1) {
			count_stars = 3;
		}
		if (elapsedTime > need_time_stars_1 && elapsedTime < need_time_stars_2) {
			count_stars = 2;
		}
		if (elapsedTime > need_time_stars_2) {
			count_stars = 1;
		}
	}

	// Use this for initializattion
	void Start () {
		//timer = Time.time;
	}

	void Update () { // вызывается каждый кадр
		if (Input.GetKeyDown (KeyCode.T)) {
			showTime = true;// при нажатии на "Т" будет показываться время
		}
	}

	void FixedUpdate(){ // вызывается каждый кадр обработки физики
		if(showTime == true){
			print (Time.time-timer);
		}
	}
}
