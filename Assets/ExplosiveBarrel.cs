using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public ParticleSystem Explosion;

    void awake()
    {
        GetComponent<Collider>().enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Explosion.Play();
            Destroy(gameObject, 0.01f);
            GetComponent<Collider>().enabled = true;

        }
    }
    

}
