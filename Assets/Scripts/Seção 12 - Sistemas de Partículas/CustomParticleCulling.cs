using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomParticleCulling : MonoBehaviour
{
    [SerializeField] private float cullingRadius = 10;
    [SerializeField] private ParticleSystem target;
    [SerializeField] private bool stopRenderOnCull = false;

    private CullingGroup _cullingGroup;
    private Renderer[] _particleRenderers;
    private ParticleSystem.LightsModule _lights;

    void OnEnable()
    {
        if (_particleRenderers == null)
        {
            _particleRenderers  = target.GetComponentsInChildren<Renderer>();
        }

        if (_cullingGroup == null)
        {
            _cullingGroup = new CullingGroup();
            _cullingGroup.targetCamera = Camera.main;
            _cullingGroup.SetBoundingSpheres(new[] { new BoundingSphere(transform.position, cullingRadius)});
            _cullingGroup.SetBoundingSphereCount(1);
            _cullingGroup.onStateChanged += OnStateChanged;
            
            _cullingGroup.SetDistanceReferencePoint(_cullingGroup.targetCamera.transform);
            _cullingGroup.SetBoundingDistances(new float[] {10,20,30});
            
            //É preciso iniciar em estado ocultado
            Cull(_cullingGroup.IsVisible(0));
            
        }

        _cullingGroup.enabled = true;

        _lights = target.lights;
    }

    private void OnDisable()
    {
        if (_cullingGroup != null)
        {
            _cullingGroup.enabled = false;
        }
        
        target.Play(true);
        SetRenderers(true);
    }

    private void OnDestroy()
    {
        _cullingGroup?.Dispose();
        _cullingGroup = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(_cullingGroup.GetDistance(0).ToString());
        }
    }

    private void OnStateChanged(CullingGroupEvent sphere)
    {
        Debug.Log(sphere.currentDistance.ToString());

        _lights.intensityMultiplier -= sphere.currentDistance - sphere.previousDistance; 
        
        Cull(sphere.isVisible);
    }

    private void Cull(bool visible)
    {
        if (visible)
        {
            //Poderiamos simular um pouquinho pra frente aqui para esconder que o sistema não foi atualizado fora da tela
            target.Simulate(1.0f);
            target.Play(true);
            SetRenderers(true);
        }
        else
        {
            target.Pause(true);
            SetRenderers(!stopRenderOnCull);
        }
    }

    private void SetRenderers(bool enable)
    {
        //Também precisamos desabilitar o renderer para prevenir que as partículas sejam desenhadas, quando a oclusão acontece
        foreach (var particleRenderer in _particleRenderers)
        {
            particleRenderer.enabled = enable;
        }
    }

    private void OnDrawGizmos()
    {
        if (enabled)
        {
            //Desenhe o gizmos para as culling spheres
            Color col = Color.yellow;
            if (_cullingGroup != null && !_cullingGroup.IsVisible(0))
            {
                col = Color.gray;
            }

            Gizmos.color = col;
            Gizmos.DrawWireSphere(transform.position, cullingRadius);
        }
    }
}
