using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShootableTank
{
    private float _timer;

    private void FixedUpdate()
    {   
        Move();
    }

    private void Update()
    {
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ShootPlayer();
        
    }

    protected override void Move()
    {
        Vector2 direction = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2d.velocity = direction.normalized * _movementSpeed;
    }

    private void ShootPlayer()
    {
        if (_timer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                _timer = _reloadTime;
            }
        }
        else
            _timer -= Time.deltaTime;
    }
}
