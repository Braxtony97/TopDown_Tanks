using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    [Header("ќбщие характеристики")]
    [SerializeField] private int _maxHealth = 30;
    [Range(0f, 5f)]
    [SerializeField] protected float _movementSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f; // ƒокручиваем дуло танка на права *смотрит вниз пока)
    [SerializeField] protected float _rotationSpeed = 7f;
    [SerializeField] private int _points = 0; // ¬ инспекторе выставл€ет значение дл€ каждого танка
    protected UIStats _uiStats;
    protected int _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _uiStats = GameObject.FindGameObjectWithTag("UI").GetComponent<UIStats>();
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        print(_currentHealth);
        if (_currentHealth <= 0)
        {
            Stats.Score += _points;
            _uiStats.UpdateScoreAndLevel();
            Destroy(gameObject);
        }
    }

    protected abstract void Move(); 

    protected void SetAngle (Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angelZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0f, angelZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed); 
    }
}
