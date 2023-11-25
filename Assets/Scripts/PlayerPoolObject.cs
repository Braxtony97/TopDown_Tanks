using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoolObject : MonoBehaviour
{
    private PoolObjectMain<BulletBehaviour> _pool;
    [SerializeField] private int _bulletCount = 20;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private BulletBehaviour _bulletPrefab;

    private void Start()
    {
        _pool = new PoolObjectMain<BulletBehaviour>(_bulletPrefab, _bulletCount, this.transform);
        _pool.AutoExpand = _autoExpand;
    }

    public void CreateBullet()
    {
        var bullet = _pool.GetFreeElement();
    }
}
