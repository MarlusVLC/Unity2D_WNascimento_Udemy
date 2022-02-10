using System;
using UnityEngine;

namespace DefaultNamespace.Seção_12___Sistemas_de_Partículas
{
    public class ParticleManipulator : MonoBehaviour
    {
        private MainMovement _mainMovement;
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _mainMovement = GetComponent<MainMovement>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.name);

            if (other.transform.parent == null) return;
            if (other.transform.parent.TryGetComponent(out _particleSystem))
            {
                _particleSystem.Play();
            }        
        }
    }
}