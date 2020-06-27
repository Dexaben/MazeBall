using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllSettingsApplyScript : MonoBehaviour {

	[SerializeField]GameObject gyroscope;
	[SerializeField]GameObject joystick;
	void Start () {
		    if(PlayerPrefs.GetString("s_control") == "Gyroscope")
		    {
			    gyroscope.SetActive(true);
			    joystick.SetActive(false);
		    }
		    else if(PlayerPrefs.GetString("s_control") == "Joystick")
		    {
			    gyroscope.SetActive(false);
			    joystick.SetActive(true);
		    }
	}
}
