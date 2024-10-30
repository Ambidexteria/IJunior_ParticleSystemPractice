using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private ParticleSystem _bulletPrefab;
    [SerializeField] private MouseRotator _mouseRotator;

    private ProjectileMover _projectileMover;
    private float _timeToFire = 0;

    private void Start()
    {
        _projectileMover = _bulletPrefab.GetComponent<ProjectileMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _timeToFire)
        {
            _timeToFire = Time.time + 1 / _projectileMover.FireRate;
            SpawnVFX();
        }
    }

    private void SpawnVFX()
    {
        Instantiate(_bulletPrefab, _firePoint.transform.position, _mouseRotator.GetRotation());
    }
}
