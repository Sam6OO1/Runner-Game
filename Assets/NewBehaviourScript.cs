using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    
    public float walkingDistance = 35.0f;
    public float minDistance = 10.0f;
    public GameObject Eye;


    public float smoothTime = 0.5f;
    
    private Vector3 smoothVelocity = Vector3.zero;
    void Update()
    {
        transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < walkingDistance && distance > minDistance)
        {
            Eye.GetComponent<Renderer>().material.color = new Color(1, 0f, 0f);
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
        else
        {
            Eye.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
}