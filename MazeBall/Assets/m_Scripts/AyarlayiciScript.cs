using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyarlayiciScript : MonoBehaviour 
{
	public GameObject main;
	Animator animator;
	public Dropdown langdrop;
	public Text nametext;
	void Start()
	{
        PlayerPrefs.SetInt("s_girissayisi", PlayerPrefs.GetInt("s_girissayisi")+0);
		animator = gameObject.GetComponent<Animator>();
		if(PlayerPrefs.GetInt("s_girissayisi") >= 1)
		{
			Destroy(gameObject);
			main.SetActive(true);
            PlayerPrefs.SetInt("s_girissayisi", PlayerPrefs.GetInt("s_girissayisi") + 1);
		}
		else
		{
			main.SetActive(false);
            PlayerPrefs.SetInt("s_money", 1000);
            PlayerPrefs.SetString("s_usesball", "empty");
        }
    }
	public void StepOne(int step)
	{
		switch(step)
		{
			case 0:
			animator.SetTrigger("stepone");
			break;
			case 1:
			animator.SetTrigger("steptwo");
			break;
            case 2:
                PlayerPrefs.SetInt("s_girissayisi", 1);
                break;
		}
		
	}
	public void Languagechange(int langvalue)
	{
		langvalue = langdrop.value;
		switch(langvalue)
		{
			case 0:
                PlayerPrefs.SetString("s_language", "en");
                StepOne(1);
			break;
			case 1:
                PlayerPrefs.SetString("s_language", "tr");
                StepOne(1);
                break;
            default:
                PlayerPrefs.SetString("s_language", "en");
                StepOne(1);
                break;
        }
	}
	public void NameSave()
	{
        if(nametext.text != null && (nametext.text.Length > 4 && nametext.text.Length < 13))
        {
            PlayerPrefs.SetString("s_name", nametext.text);
            StepOne(0);
        }
        else
        {
            Text warntext = nametext.transform.GetChild(0).gameObject.GetComponent<Text>();
            warntext.text = "Please enter a valid username.";
        }
	}
    public void SetControl(string controlstring)
    {
        PlayerPrefs.SetString("s_control", controlstring);
        StepOne(2);
    }
} 