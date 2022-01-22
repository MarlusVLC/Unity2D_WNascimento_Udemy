using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour
{
    int particleCounter = 0;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }
}
