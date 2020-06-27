using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballProperties : MonoBehaviour
{
    public int hp;
    public Text hpText;
    public GameObject rollerball;

    private void LateUpdate()
    {
        hpText.text = "" + hp;
    }
}
