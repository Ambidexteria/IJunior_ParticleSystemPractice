using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;
    [SerializeField] private ParticleSystem _hitPrefab;

    public float FireRate => _fireRate;

    private void Update()
    {
        transform.Translate(transform.forward * (_speed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _speed = 0;

        ContactPoint contactPoint = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
        Vector3 position = contactPoint.point;

        var hitVFX = Instantiate(_hitPrefab, position, rotation);
        Destroy(hitVFX.gameObject, hitVFX.main.duration);

        Destroy(gameObject);
    }
}
