using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShootableTank
{
    [SerializeField] private PlayerPoolObject _pool;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    protected override void Move()
    {
        Vector2 direction = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2d.velocity = direction.normalized * _movementSpeed;
    }

    protected override void Shoot()
    {
        _pool.CreateBullet();
    }
}
