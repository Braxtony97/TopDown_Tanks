using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    private PoolObjectMain<BulletBehaviour> _pool;
    [SerializeField] protected float _reloadTime = 0.5f;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _bulletPoolContainer;
    [SerializeField] private int _bulletCount = 20;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private BulletBehaviour _bulletPrefab;
    

    protected override void Start()
    {
        base.Start();
        _pool = new PoolObjectMain<BulletBehaviour>(_bulletPrefab, _bulletCount, _bulletPoolContainer, _shootPoint);
        _pool.AutoExpand = _autoExpand;
        // _shootPoint только при старте передает позицию свою, а нужно что бы постоянно
    }

    protected void Shoot()
    {
        BulletBehaviour bullet = _pool.GetFreeElement(_shootPoint);
        // Передаем в параметры _shootPoint, т.к он передает только при старте -> пули всегда из начальной точки идут
        // А тут при стрельбе позиция _shootPoint обновляется -> пуди вылетают из нужной позиции

    }
}

