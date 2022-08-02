using System;
using System.Collections;

using UnityEngine;
    

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public ParticleSystem muzzleFlash;
    public GameObject Eye;
   
    
    
    



    public float maximumLookDistance = 30f;
 public float maximumAttackDistance = 10f;
 public float minimumDistanceFromPlayer = 2f;
 
 public float rotationDamping = 2f;
 
 public float shotInterval = 0.5f;
 
 private float shotTime = 0f;
 
 void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);

        if (distance <= maximumLookDistance)
        {
            Eye.GetComponent<Renderer>().material.color = new Color(1, 0f, 0f);

            if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
            {
                Shoot();
            } 

        }
        else
        {
            Eye.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
       
       
    }

    void Shoot()
    {
        muzzleFlash.Play();
        shotTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab);

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            bulletSpawn.parent.GetComponent<Collider>());

            bullet.transform.position = bulletSpawn.position;

            Vector3 rotation = bullet.transform.rotation.eulerAngles;

            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        

    }

   
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}



