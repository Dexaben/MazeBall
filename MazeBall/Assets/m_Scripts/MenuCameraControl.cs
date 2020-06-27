using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuCameraControl : MonoBehaviour {
    public Transform m_camera;
	public Transform currentmount;
	public List<Transform> planetsmounts;
	public int MountSize = 0;
	public int MaxMountSize;
	public float speedfactor = 0.1f;
    public GameObject buyButton;
    public GameObject useButton;
    public Text textMoney;
    public GameObject ball;
    [SerializeField] GameObject pricewarn;
    bool allowanim;
    void Start()
	{
        Time.timeScale = 1f;
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        MaxMountSize = planetsmounts.Count-1;
        if (PlayerPrefs.GetString("s_usesball") == "empty")
        {
            currentmount = planetsmounts[0];
            ball = currentmount.transform.Find("top").gameObject;
            MountSize = 0;
        }
        else
        {
            string usedbal = PlayerPrefs.GetString("s_usesball").Substring(5);
            currentmount = planetsmounts[int.Parse(usedbal)];
            MountSize = int.Parse(usedbal);
            if (PlayerPrefs.GetString("s_usesball") == "s_top" + MountSize)
            {
                useButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                useButton.GetComponent<Image>().color = Color.white;
            }
            if (PlayerPrefs.GetInt("s_top" + MountSize) == 1)
            {
                currentmount.transform.Find("price").gameObject.SetActive(false);
                buyButton.SetActive(false);
                useButton.SetActive(true);
            }
            else
            {
                buyButton.SetActive(true);
                useButton.SetActive(false);
            }
        }
        
	}
	void Update() 
	{

        ball = currentmount.transform.Find("top").gameObject;
        ball.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        ball.transform.Rotate(Vector3.up * Time.deltaTime * 40);
        textMoney.text = ""+PlayerPrefs.GetInt("s_money");
		m_camera.transform.position = Vector3.Lerp(m_camera.transform.position , currentmount.position,speedfactor);
		m_camera.transform.rotation = Quaternion.Slerp(m_camera.transform.rotation,currentmount.rotation,speedfactor);
	}
	public void MountArtir()
	{
		Time.timeScale = 1f;
		if(MountSize != MaxMountSize)
		{
		++MountSize;
		currentmount = planetsmounts[MountSize];
            if(PlayerPrefs.GetString("s_usesball") == "s_top"+MountSize)
            {
                useButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                useButton.GetComponent<Image>().color = Color.white;
            }
            if(PlayerPrefs.GetInt("s_top"+MountSize) == 1)
            {
                currentmount.transform.Find("price").gameObject.SetActive(false);
                buyButton.SetActive(false);
                useButton.SetActive(true);
            }
            else
            {
                buyButton.SetActive(true);
                useButton.SetActive(false);
            }
		}
	}
	public void MountAzalt()
	{
		Time.timeScale = 1f;
		if(MountSize != 0)
		{
		--MountSize;
		currentmount = planetsmounts[MountSize];
            if (PlayerPrefs.GetString("s_usesball") == "s_top" + MountSize)
            {
                useButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                useButton.GetComponent<Image>().color = Color.white;
            }
            if (PlayerPrefs.GetInt("s_top" + MountSize) == 1)
            {
                currentmount.transform.Find("price").gameObject.SetActive(false);
                buyButton.SetActive(false);
                useButton.SetActive(true);
            }
            else
            {
                buyButton.SetActive(true);
                useButton.SetActive(false);
            }
        }
	}
    public void useBall()
    {
        if(PlayerPrefs.GetInt("s_top"+MountSize)== 1)
        {
            PlayerPrefs.SetString("s_usesball", "s_top" + MountSize);
            useButton.GetComponent<Image>().color = Color.green;
        }
    }
    public void buyBall()
    {
        switch (MountSize)
        {
            case 0:
                if(PlayerPrefs.GetInt("s_money") > 850)
                {
                    PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money")-850);
                    PlayerPrefs.SetInt("s_top" + MountSize,1);
                    PlayerPrefs.SetString("s_usesball", "s_top" + MountSize);
                }
                else
                {
                    if(!allowanim)
                    {
                        Destroy(Instantiate(pricewarn) as GameObject, 2f);
                        allowanim = true;
                    }
                    allowanim = false;
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("s_money") > 2200)
                {
                    PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money") - 2200);
                    PlayerPrefs.SetInt("s_top" + MountSize, 1);
                    PlayerPrefs.SetString("s_usesball", "s_top"+MountSize);
                }
                else
                {
                    if (!allowanim)
                    {
                        Destroy(Instantiate(pricewarn) as GameObject, 2f);
                        allowanim = true;
                    }
                    allowanim = false;
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("s_money") > 3600)
                {
                    PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money") - 3600);
                    PlayerPrefs.SetInt("s_top" + MountSize, 1);
                    PlayerPrefs.SetString("s_usesball", "s_top" + MountSize);
                }
                else
                {
                    Destroy(Instantiate(pricewarn) as GameObject, 2f);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("s_money") > 5800)
                {
                    PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money") - 5800);
                    PlayerPrefs.SetInt("s_top" + MountSize, 1);
                    PlayerPrefs.SetString("s_usesball", "s_top" + MountSize);
                }
                else
                {
                    Destroy(Instantiate(pricewarn) as GameObject, 2f);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("s_money") > 7200)
                {
                    PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money") - 7200);
                    PlayerPrefs.SetInt("s_top" + MountSize, 1);
                    PlayerPrefs.SetString("s_usesball", "s_top" + MountSize);
                }
                else
                {
                    Destroy(Instantiate(pricewarn) as GameObject, 2f);
                }
                break;
        }
        if (PlayerPrefs.GetInt("s_top" + MountSize) == 1)
        {
            currentmount.transform.Find("price").gameObject.SetActive(false);
            buyButton.SetActive(false);
            useButton.SetActive(true);
            useButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            buyButton.SetActive(true);
            useButton.SetActive(false);
            useButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void moneyup(int moneyvalue)
    {
        PlayerPrefs.SetInt("s_money", PlayerPrefs.GetInt("s_money") + moneyvalue);
    }
}
