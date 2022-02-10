using System;
using UnityEngine;

namespace DefaultNamespace.Seção_12___Sistemas_de_Partículas
{
    public class ParticleManipulator : MonoBehaviour
    {
        [SerializeField] private Gradient lifetimeColor;
        private MainMovement _mainMovement;
        private ParticleSystem _particleSystem;

        #region ParticleSystemModules

        private ParticleSystem.ExternalForcesModule _externalForces;
        private ParticleSystem.NoiseModule _noise;

        #endregion

        private void Awake()
        {
            _mainMovement = GetComponent<MainMovement>();
        }


        private void Update()
        {
            if (_particleSystem != null)
            {
                _externalForces.multiplier = _mainMovement.Rb.velocity.x;
                // ParticleSystem.MinMaxCurve curve = new ParticleSystem.MinMaxCurve();
                // curve.constantMin = 
                _noise.strength = _mainMovement.Rb.velocity.y;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.parent == null) return;
            if (other.transform.parent.TryGetComponent(out _particleSystem))
            {
                GetParticleSystemModules();
                _particleSystem.Play();
            }        
        }

        private void GetParticleSystemModules()
        {
            if (_particleSystem != null)
            {
                _externalForces = _particleSystem.externalForces;
                _noise = _particleSystem.noise;
            }
        }
    }
}