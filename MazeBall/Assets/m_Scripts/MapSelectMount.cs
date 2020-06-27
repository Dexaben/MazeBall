using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectMount : MonoBehaviour
{
    public Transform m_camera;
    public Transform currentmount;
    public List<Transform> planetsmounts;
    public int MountSize = 0;
    public int MaxMountSize;
    public float speedfactor = 0.1f;
    Animator m_animator;
    void Start()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        Time.timeScale = 1f;
        currentmount = planetsmounts[0];
        MaxMountSize = planetsmounts.Count - 1;
        currentmount = planetsmounts[MountSize];
        m_animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        m_camera.transform.position = Vector3.Lerp(m_camera.transform.position, currentmount.position, speedfactor);
        m_camera.transform.rotation = Quaternion.Slerp(m_camera.transform.rotation, currentmount.rotation, speedfactor);
        switch (MountSize)
        {
            case 0:
                m_animator.SetTrigger("earth");
                break;
            case 1:
                m_animator.SetTrigger("saturn");
                break;
            case 2:
                m_animator.SetTrigger("mars");
                break;
            case 3:
                m_animator.SetTrigger("iceworld");
                break;
        }
    }
    public void MountArtir()
    {
        Time.timeScale = 1f;
        if (MountSize != MaxMountSize)
        {
            ++MountSize;
            currentmount = planetsmounts[MountSize];
        }

    }
    public void MountAzalt()
    {
        Time.timeScale = 1f;
        if (MountSize != 0)
        {
            --MountSize;
            currentmount = planetsmounts[MountSize];
        }
    }
}
