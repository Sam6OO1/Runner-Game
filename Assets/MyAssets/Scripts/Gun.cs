
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;

public class Gun : MonoBehaviour
{
    public AudioSource gunSound;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Text ammoDisplay;

    public int maxAmmo = 7;
    public int currentAmmo;
    public float reloadTime = 1f;
    

    private bool isReloading = false;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;


    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start ()
    {
        currentAmmo = maxAmmo;
    }
   
    void Update()
    {
       

        if (isReloading)
           return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
       

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
            ammoDisplay.text = currentAmmo.ToString();
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
         
           
        }
        
    }

    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading");
        ammoDisplay.text = 0.ToString();

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
     }
    


    void Shoot()
    {
        gunSound.Play();
        muzzleFlash.Play();
        currentAmmo--;
        
        

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
