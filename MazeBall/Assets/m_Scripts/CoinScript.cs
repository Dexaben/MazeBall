using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	public GameManager _instante;
	void Start () {
		this.gameObject.SetActive(true);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			_instante.coinduzeyi +=10;
			_instante.CoinText();
			Destroy(this.gameObject);
		}
	}
}
