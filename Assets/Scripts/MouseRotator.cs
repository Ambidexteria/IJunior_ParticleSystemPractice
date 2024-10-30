using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maximumLength;

    private Ray _rayMouse;
    private Vector3 _direction;
    private Quaternion _rotation;

    private void Update()
    {
        RaycastHit hit;
        Vector3 mousePos = Input.mousePosition;
        _rayMouse = _camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(_rayMouse.origin, _rayMouse.direction, out hit, _maximumLength))
        {
            RotateToMouseDirection(gameObject, hit.point);
        }
        else
        {
            Vector3 position = _rayMouse.GetPoint(_maximumLength);
            RotateToMouseDirection(gameObject, position);
        }
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }

    private void RotateToMouseDirection(GameObject gameobject, Vector3 destination)
    {
        _direction = destination - gameobject.transform.position;
        _rotation = Quaternion.LookRotation(_direction);
        gameobject.transform.localRotation = Quaternion.Lerp(gameobject.transform.rotation, _rotation, 1);
    }
}
