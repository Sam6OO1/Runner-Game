using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public AudioSource teleporterSEffect;
    public ParticleSystem teleporterEffect;
    public float teleporterDelay = 2f;

    [SerializeField] private Transform player;

    [SerializeField] private Transform teleportPoint;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(teleporterDelay);
        
        player.transform.position = teleportPoint.transform.position;
        teleporterSEffect.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            teleporterEffect.Play();
            StartCoroutine(Wait());
            return;
           

            
        }
    }
}


