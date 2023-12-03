using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private string _myTag = "";
    [SerializeField] private int _damage = 5;

    void Update()
    {
        if (gameObject.activeSelf) {
            transform.Translate(Vector3.down * _bulletSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tank>() != null && collision.gameObject.tag != _myTag)
        {
            collision.gameObject.GetComponent<Tank>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

}
