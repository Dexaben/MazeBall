using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour {
	public string en;
	public string tr;
	Text textln;
	void Start()
	{
        if (PlayerPrefs.GetString("s_language") == "en")
        {
            textln = this.gameObject.GetComponent<Text>();
            textln.text = "" + en;
        }
        if (PlayerPrefs.GetString("s_language") == "tr")
        {
            textln = this.gameObject.GetComponent<Text>();
            textln.text = "" + tr;
        }
    }
	public void LateUpdate()
	{
		if(PlayerPrefs.GetString("s_language") == "en")
		{
		textln = this.gameObject.GetComponent<Text>();
		textln.text = ""+en;
		}
		if(PlayerPrefs.GetString("s_language") == "tr")
		{
		textln = this.gameObject.GetComponent<Text>();
		textln.text = ""+tr;
		}
	}
}
