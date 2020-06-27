using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScriot : MonoBehaviour {
	public GameManager _instante;
	void Start () {
		this.gameObject.SetActive(true);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			_instante.EnergyDuzeyi ++;
			_instante.EnergyText();
			Destroy(this.gameObject);
		}
	}
}
