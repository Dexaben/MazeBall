using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toptakip : MonoBehaviour {
	public GameObject top;
	void Update () {
		transform.position = top.transform.position;
	}
}
