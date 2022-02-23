using UnityEngine;

namespace DefaultNamespace.Seção_12___Sistemas_de_Partículas
{
    public class ParticleCustomData : MonoBehaviour
    {
        [SerializeField] private GradientColorKey[] gradientColors;
        [SerializeField] private GradientAlphaKey[] gradientTransparency;

        
        void Start()
        {
            
            
            gradientColors = new []
            {
                new GradientColorKey(Color.blue, 0.0f),
                new GradientColorKey(Color.red, 1.0f)
            };

            gradientTransparency = new[]
            {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
            };
            
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            ParticleSystem.CustomDataModule customData = particleSystem.customData;
            customData.enabled = true;

            Gradient gradient = new Gradient();
            gradient.SetKeys(gradientColors, gradientTransparency);
            
            customData.SetMode(ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Color);
            customData.SetColor(ParticleSystemCustomData.Custom1, gradient);

            ParticleSystem.MainModule mainModule = particleSystem.main;
            mainModule.startColor = customData.GetColor(ParticleSystemCustomData.Custom1);
        }
    }
}