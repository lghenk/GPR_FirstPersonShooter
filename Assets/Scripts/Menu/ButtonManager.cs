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

		Play.onClick.AddListener(delegate() { TaskOnClick("Play"); });
		Settings.onClick.AddListener(delegate() { TaskOnClick("Settings"); });
		Back.onClick.AddListener(delegate() { TaskOnClick("Back"); });
		Exit.onClick.AddListener(delegate() { TaskOnClick("Exit"); });

	}

	void TaskOnClick(string option){
		if (option == "Play") {
			SceneManager.LoadScene ("Main Scene");
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