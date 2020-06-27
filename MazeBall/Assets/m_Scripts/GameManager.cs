using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public GameObject[] toplar;
    public int count;
    public GameObject rollerball;
    private int suredenkazanilan;
    public float t;
    public int dakika;
    public int minutes;
    public float second;
    public float saniye;
    public Text TimerText;
    private float StartTime;
    public GameObject kapsulkapi;
    public Text energytext;
    public Text cointextfinish;
    public Text cointext;
    public Text SureText;
    public Text Suredenkazanilantext;
    public Text ToplamPara;
    public int EnergyDuzeyi;
    public int coinduzeyi;
    public GameObject FinishCanvas;
    public float x;
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Time.timeScale = 1;
        t = 0.0f;
        StartTime = 0.0f;
        FinishCanvas.SetActive(false);
        count = 0;
        ballProperties ballprop = rollerball.GetComponent<ballProperties>();
        foreach (Transform i in rollerball.transform)
        {
            count++;
        }
        toplar = new GameObject[count];
        count = 0;
        foreach (Transform i in rollerball.transform)
        {
            toplar[count] = i.gameObject;
            count++;
        }
        for(int i = 0;i < toplar.Length;i++)
        {
            if(toplar[i].name == PlayerPrefs.GetString("s_usesball"))
            {
                toplar[i].SetActive(true);
                switch(i)
                {
                    case 0:
                        ballprop.hp = 15;
                        break;
                    case 1:
                        ballprop.hp = 21;
                        break;
                    case 2:
                        ballprop.hp = 32;
                        break;
                    case 3:
                        ballprop.hp = 48;
                        break;
                    case 4:
                        ballprop.hp = 62;
                        break;
                }
            }
            else
            {
                toplar[i].SetActive(false);
            }
        }
    } 
	void Update()
	{
		if (second >= 0 && minutes >= 0)
		{
		t = Time.timeSinceLevelLoad - StartTime;
		minutes =(dakika - ((int)t / 60)); 
		second = (saniye - (t % 60));
		string m = minutes.ToString();
		string s = second.ToString("f0");
		TimerText.text = m + "." + s;
		}
		else if (second >=59&& minutes <0)
		{
			second =-0.1f;
			minutes = 0;
			TimerText.text = "0.0";

		}
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2f);
    }
	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			FinishCanvas.SetActive(true);
			cointextfinish.text = coinduzeyi+"";
			SureText.text = TimerText.text;
			suredenkazanilan = ((int)second / 4 )+(minutes * 10);
			Suredenkazanilantext.text = suredenkazanilan.ToString();
			ToplamPara.text = (coinduzeyi+suredenkazanilan)+"";
            PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money")+int.Parse(ToplamPara.text));
		}
	}
	public void OnTriggerExit(Collider other)
	{
		Time.timeScale= 1f;
	}
	public void EnergyText()
	{
		energytext.text = EnergyDuzeyi+"/3";
		if(EnergyDuzeyi == 3)
		 {
			 kapsulkapi.SetActive(false);
		 }
	}
	public void CoinText()
	{
		cointext.text = coinduzeyi+"";
	}
	public void TimeFreeze()
	{
		Time.timeScale = 0f;
	}
	public void TimeGo()
	{
		Time.timeScale = 1f;
	}
	public void TimeFreezeOnSecond()
	{
		StartCoroutine(Example());
	}
	IEnumerator Example()
	{
		yield return new WaitForSeconds(1.3f);
		Time.timeScale = 0f;
	}
	public void LevelChange(int scenename)
    {
        SceneManager.LoadScene(scenename);
    }
	public void LevelRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}