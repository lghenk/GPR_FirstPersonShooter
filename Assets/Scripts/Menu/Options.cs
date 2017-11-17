using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

	public float shadowDrawDistance;

	public int resX; 
	public int resY;

	public bool Fullscreen; 

	public Button increaseQuality;
	public Button decreaseQuality;

	public Button antiAliasing0;
	public Button antiAliasing2;
	public Button antiAliasing4;
	public Button antiAliasing8;

	public Button tripelBufferingOn;
	public Button tripelBufferingOff;

	public Button anisotropicFilteringOn;
	public Button anisotropicFilteringOff;

	public Button setResolution60hz;
	public Button setResolution120hz;
	public Button setResolution1080p;
	public Button setResolution720p;
	public Button setResolution480p;

	public Button vSyncOn; 
	public Button vSyncOff;

	void Start()
	{
		increaseQuality.onClick.AddListener(delegate() { TaskOnClick("incQual"); });
		decreaseQuality.onClick.AddListener(delegate() { TaskOnClick("decQual"); });
		antiAliasing0.onClick.AddListener(delegate() { TaskOnClick("aA0"); });
		antiAliasing2.onClick.AddListener(delegate() { TaskOnClick("aA2"); });		
		antiAliasing4.onClick.AddListener(delegate() { TaskOnClick("aA4"); });															
		antiAliasing8.onClick.AddListener(delegate() { TaskOnClick("aA8"); });															
		tripelBufferingOn.onClick.AddListener(delegate() { TaskOnClick("tBOn"); });															
		tripelBufferingOff.onClick.AddListener(delegate() { TaskOnClick("tBOff"); });															
		anisotropicFilteringOn.onClick.AddListener(delegate() { TaskOnClick("aFOn"); });															
		anisotropicFilteringOff.onClick.AddListener(delegate() { TaskOnClick("aFOff"); });															
		setResolution60hz.onClick.AddListener(delegate() { TaskOnClick("setRes60"); });															
		setResolution120hz.onClick.AddListener(delegate() { TaskOnClick("setRes120"); });		
		setResolution1080p.onClick.AddListener(delegate() { TaskOnClick("setRes1080p"); });															
		setResolution720p.onClick.AddListener(delegate() { TaskOnClick("setRes720p"); });															
		setResolution480p.onClick.AddListener(delegate() { TaskOnClick("setRes480p"); });															
		vSyncOn.onClick.AddListener(delegate() { TaskOnClick("vSyncOn"); });															
		vSyncOff.onClick.AddListener(delegate() { TaskOnClick("vSyncOff"); });															

	}

	void TaskOnClick(string option){
		if (option == "incQual") {
			QualitySettings.IncreaseLevel ();
		} 
		else if (option == "decQual") {
			QualitySettings.DecreaseLevel ();
		}
		else if (option == "aA0") {
			QualitySettings.antiAliasing = 0;
		}
		else if (option == "aA2") {
			QualitySettings.antiAliasing = 2;
		}
		else if (option == "aA4") {
			QualitySettings.antiAliasing = 4;
		}
		else if (option == "aA8") {
			QualitySettings.antiAliasing = 8;
		}
		else if (option == "tBOn") {
			QualitySettings.maxQueuedFrames = 3;
		}
		else if (option == "tBOff") {
			QualitySettings.maxQueuedFrames = 0;
		}
		else if (option == "aFOn") {
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		}
		else if (option == "aFOff") {
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
		else if (option == "setRes60") {
			Screen.SetResolution (resX, resY, Fullscreen, 60);
		}
		else if (option == "setRes120") {
			Screen.SetResolution (resX, resY, Fullscreen, 120);
		}
		else if (option == "setRes1080p") {
			Screen.SetResolution (1920, 1080, Fullscreen);
			resX = 1920;
			resY = 1080;
		}
		else if (option == "setRes720p") {
			Screen.SetResolution (1280, 720, Fullscreen);
			resX = 1280;
			resY = 720;
		}
		else if (option == "setRes480p") {
			Screen.SetResolution (640, 480, Fullscreen);
			resX = 640;
			resY = 480;
		}
		else if (option == "vSyncOn") {
			QualitySettings.vSyncCount = 1;
		}
		else if (option == "vSyncOff") {
			QualitySettings.vSyncCount = 0;
		}
	}
}