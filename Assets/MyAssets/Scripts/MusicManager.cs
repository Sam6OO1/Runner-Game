using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

   

    private void OnCollisionEnter(Collision collision)
    {
        music.Play();
    }

}