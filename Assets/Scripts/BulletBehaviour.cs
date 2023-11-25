using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _bulletSpeed = 0.02f;

    void Update()
    {
        if (gameObject.activeSelf) { }
        //_transform.Translate(Vector3.up * _bulletSpeed);
    }
}
