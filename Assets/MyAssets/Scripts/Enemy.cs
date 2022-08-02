using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public bool isDead = false;
    public GameObject ThrusterL;
    public GameObject ThrusterR;
    public GameObject Eye;


    public Transform target;
    public float speed = 5f;

    void Awake()
    {
        this.GetComponent<Rigidbody>().useGravity = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Die();
        }
        if (other.gameObject.tag == "Explosive")
        {
            Die();
        }
    }

    void Die()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        isDead = true;
        GetComponent<EnemyController>().enabled = false;
        GetComponent<NewBehaviourScript>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        ThrusterL.SetActive(false);
        ThrusterR.SetActive(false);
        Eye.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);


    }

    private void Update()
    {

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}

