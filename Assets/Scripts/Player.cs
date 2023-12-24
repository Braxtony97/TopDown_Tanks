using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    [SerializeField] private Rigidbody2D _rigidbody2d;
    private float _timer;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {   
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Update()
    {
        ShootPlayer();     
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _uiStats.UpdateHp(_currentHealth);

        if (_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }

    protected override void Move()
    {
        //this.transform.Translate(Vector2.down * Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime);
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
