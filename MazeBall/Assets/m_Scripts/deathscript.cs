using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathscript : MonoBehaviour
{
    bool alreadydone;
    public GameObject finish;
    public GameObject rollerball;
    [SerializeField] GameObject deatheffect;
    [SerializeField] GameObject hitcount;
    [SerializeField] GameObject hiteffect;
    public int damage;
    public float forcespeed;
    private void Start()
    {
        finish.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
            if(!alreadydone)
            {
                alreadydone = true;
                Rigidbody rigRollerball = rollerball.GetComponent<Rigidbody>();
                ballProperties ballProp = rollerball.GetComponent<ballProperties>();
                ballProp.hp -= damage;
                rigRollerball.AddForce(-transform.forward * forcespeed, ForceMode.Impulse);
                GameObject go = Instantiate(hitcount,rollerball.transform.position,Quaternion.FromToRotation(Vector3.forward, rollerball.transform.position));
                go.transform.GetChild(0).GetComponent<Text>().text = "" + damage;
                Destroy(go, 1.14f);
                Destroy(Instantiate(hiteffect, rollerball.transform.position, Quaternion.FromToRotation(Vector3.forward, rollerball.transform.position)) as GameObject, 1.3f);

                if (ballProp.hp <= 0)
                {
                    finish.SetActive(true);
                    rigRollerball.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                    Destroy(Instantiate(deatheffect, rollerball.transform.position, Quaternion.FromToRotation(Vector3.forward, rollerball.transform.position)) as GameObject, 1.3f);
                    ballProp.hpText.text = "0";
                    Destroy(rollerball);
                }
                else
                {
                    return;
                }
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            alreadydone = false;
        }
    }
}