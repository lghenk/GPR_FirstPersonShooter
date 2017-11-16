using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public Button Play;
	public Button Settings;
	public Button Back;
	public Button Exit;

	private GameObject go_main;
	private GameObject go_settings;


	void Awake(){

		go_main = GameObject.Find ("Main");
		go_settings = GameObject.Find ("Settings");

		go_settings.SetActive (false); 

	}

	void Start()
	{
//		Button btn_Play.GetComponent<Button>();
		Button btn_settings = Settings.GetComponent<Button>(); 
		Button btn_back = Back.GetComponent<Button>(); 
		Button btn_exit = Exit.GetComponent<Button>();

		Play.onClick.AddListener(delegate() { TaskOnClick("Play"); });
		btn_settings.onClick.AddListener(delegate() { TaskOnClick("Settings"); });
		btn_back.onClick.AddListener(delegate() { TaskOnClick("Back"); });
		btn_exit.onClick.AddListener(delegate() { TaskOnClick("Exit"); });

	}

	void TaskOnClick(string option){
		if (option == "Play") {
			SceneManager.LoadScene ("JerryTestScene");
			Debug.Log ("Play");
		} 
		else if (option == "Settings") {
			go_main.SetActive (false);
			go_settings.SetActive (true);
		}
		else if (option == "Back") {
			go_main.SetActive (true);
			go_settings.SetActive (false);
		}
		else {
			Application.Quit();
		}
	}
}