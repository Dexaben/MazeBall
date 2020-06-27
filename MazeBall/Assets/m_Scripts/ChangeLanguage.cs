using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour {

	public void ChangeLang(string lang)
	{
        PlayerPrefs.SetString("s_language", lang);
	}
	     public void controlchange(string controlname)
     {
        PlayerPrefs.SetString("s_control", controlname);
     }

}
