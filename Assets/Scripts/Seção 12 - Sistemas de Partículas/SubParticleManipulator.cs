using UnityEngine;

namespace Seção_12___Sistemas_de_Partículas
{
    public class SubParticleManipulator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private ParticleSystem.SubEmittersModule _subEmitters;
        // private ParticleSystem _blowEmitter;

        void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _subEmitters = _particleSystem.subEmitters;
           _subEmitters.SetSubEmitterEmitProbability(0, 0.1f);
        }
    }
}