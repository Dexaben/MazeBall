using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontrol : MonoBehaviour {
    public AudioClip[] sounds;
    AudioSource audioSource;
	public GameObject[] SetActiveFalse;
    int rotatespeed = 0;
	public void Start()
	{
        audioSource = gameObject.GetComponent<AudioSource>();
		Application.targetFrameRate = 60;
		for(int i=0;0 < SetActiveFalse.Length;i++)
		{
			SetActiveFalse[i].SetActive(false);
		}
		Time.timeScale = 1f;
		
	}
    private void LateUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2f);
    }
    public void Menu(int scenename)
    {
        if(PlayerPrefs.GetString("s_usesball") != "empty")
        {
            SceneManager.LoadScene(scenename);
        }
    }
	public void Ouit()
	{
		Application.Quit();
	}
	public void QualityChange(int volume)
	{
		QualitySettings.SetQualityLevel(volume);
	}
    public void audioplay(int audioindex)
    {
        audioSource.PlayOneShot(sounds[audioindex], 1f);
    }
}
