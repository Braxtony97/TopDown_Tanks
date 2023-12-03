using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    private PoolObjectMain<BulletBehaviour> _pool;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform bulletPoolContainer;
    [SerializeField] private int _bulletCount = 20;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private BulletBehaviour _bulletPrefab;
    [SerializeField] protected float _reloadTime = 0.5f;

    protected override void Start()
    {
        base.Start();
        _pool = new PoolObjectMain<BulletBehaviour>(_bulletPrefab, _bulletCount, bulletPoolContainer, _shootPoint);
        _pool.AutoExpand = _autoExpand;
    }

    protected void Shoot()
    {
        //Instantiate(_bulletPrefab, _shootPoint.position, transform.rotation);
        _pool.GetFreeElement();
    }
}

