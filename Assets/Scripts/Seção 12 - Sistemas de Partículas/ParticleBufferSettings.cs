using System;
using UnityEngine;

namespace DefaultNamespace.Seção_12___Sistemas_de_Partículas
{
    public class ParticleBufferSettings : MonoBehaviour
    {
        [SerializeField] private GameObject subEmmiter;
        
        private ParticleSystem _particleSystem;
        private ParticleSystemRenderer _particleSystemRenderer;
        void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
            
            ParticleSystem.SetMaximumPreMappedBufferCounts(1,1);
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ParticleSystem.ResetPreMappedBufferMemory();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                subEmmiter.SetActive(!subEmmiter.activeSelf);
            }
        }
    }
}