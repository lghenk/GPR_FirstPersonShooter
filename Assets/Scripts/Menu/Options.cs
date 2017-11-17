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
	public Button treipelBufferingOff;

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
		Button _incQual = increaseQuality.GetComponent<Button>();
		Button _decQual = decreaseQuality.GetComponent<Button>();;
		Button _aA0 = antiAliasing0.GetComponent<Button>();;
		Button _aA2 = antiAliasing2.GetComponent<Button>();;
		Button _aA4 = antiAliasing4.GetComponent<Button>();;
		Button _aA8 = antiAliasing8.GetComponent<Button>();;
		Button _tBuffON = tripelBufferingOn.GetComponent<Button>();;
		Button _tBuffOFF = treipelBufferingOff.GetComponent<Button>();;
		Button _aFilterOn = anisotropicFilteringOn.GetComponent<Button>();;
		Button _aFilterOff = anisotropicFilteringOff.GetComponent<Button>();;
		Button _sRes60 = setResolution60hz.GetComponent<Button>();;
		Button _sRes120 = setResolution120hz.GetComponent<Button>();;
		Button _sRes1080 = setResolution1080p.GetComponent<Button>();;
		Button _sRes720 = setResolution720p.GetComponent<Button>();;
		Button _sRes480 = setResolution480p.GetComponent<Button>();;
		Button _vSyncOn = vSyncOn.GetComponent<Button>();;
		Button _vSyncOff = vSyncOff.GetComponent<Button>();;
			
																		
																	
	}
}
