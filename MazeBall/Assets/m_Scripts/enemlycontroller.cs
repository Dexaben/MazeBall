using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemlycontroller : MonoBehaviour
{
    public Transform[] targets;
    public float speed = 1f;
    public float reachDist = 1f;
    public int currentPoint = 0;
    public Transform enemly;
    private void Start()
    {
        enemly = gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        float dist = Vector3.Distance(targets[currentPoint].position, enemly.transform.position);
        enemly.transform.position = Vector3.MoveTowards(enemly.transform.position, targets[currentPoint].position,Time.deltaTime * speed);

        if (dist <= reachDist)
        {
            currentPoint++;
        }

        if (currentPoint >= targets.Length)
        {
            currentPoint = 0;
        }

    }
}
