using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
   
    [SerializeField] private Transform player;

    [SerializeField] private Transform teleportPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            player.transform.position = teleportPoint.transform.position;
        }
    }
}


