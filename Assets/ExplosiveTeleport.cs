using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTeleport : MonoBehaviour
{
    public Transform ExplosiveBarrel;
    public Transform ParticleExplosive;

    public void Update()
    {

        ParticleExplosive.position = ExplosiveBarrel.position;
    }
}

