using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;


public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 100;
    int damage = 20;
    public Text HPDisplay;
    [SerializeField] private Transform player;

    [SerializeField] private Transform respawnPoint;

    void Start()
    {
        print(playerHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DroneBullet")
        {
            playerHealth -= damage;
            print(playerHealth);
            HPDisplay.text = "HP:" + playerHealth.ToString();
        }
        if (other.gameObject.tag == "Explosive")
        {
            playerHealth = 0;
            
        }
    }

    void Update()
    {
if (playerHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
