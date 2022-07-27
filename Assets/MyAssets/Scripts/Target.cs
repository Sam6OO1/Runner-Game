using UnityEngine;


public class Target : MonoBehaviour
{
    public bool isDead = false;

    

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
    }

    void Die()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        isDead = true;
    }
   

}
