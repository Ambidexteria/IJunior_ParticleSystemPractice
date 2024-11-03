using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenpointMover : MonoBehaviour
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        Vector3 position = _cam.ScreenToWorldPoint(Input.mousePosition);
        position.z += 5;
        transform.position = position;
    }
}
