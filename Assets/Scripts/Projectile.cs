using UnityEngine;

class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float duration = 5;
    [SerializeField] int damage = 10;

    void Start()
    {
        Destroy(gameObject, duration);
    }
     

    void Update()
    {
        transform.position += 
            transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HealthObject healthObject = other.GetComponent<HealthObject>();
        if (healthObject != null)
        {
            healthObject.Damage(damage);
            Destroy(gameObject);
        }
    }
}
