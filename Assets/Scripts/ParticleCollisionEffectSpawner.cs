using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleCollisionEffectSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _explosionSpeed;

    private ParticleSystem _particleSystem;
    private List<ParticleCollisionEvent> _events = new List<ParticleCollisionEvent>();

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _particleSystem.GetCollisionEvents(other, _events);
        var firstCollision = _events[0];
        var explosionEffect = Instantiate(_explosionEffect, firstCollision.intersection, Quaternion.identity);
        explosionEffect.transform.LookAt(firstCollision.normal);
        Destroy(explosionEffect.gameObject, explosionEffect.main.startLifetime.constant);
    }
}
