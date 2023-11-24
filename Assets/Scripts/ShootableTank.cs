using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject _projectileBoolet;
    [SerializeField] private Transform _shootPoint;

    protected void Shoot()
    {
        Instantiate(_projectileBoolet, _shootPoint.position, transform.rotation);
    }
}
