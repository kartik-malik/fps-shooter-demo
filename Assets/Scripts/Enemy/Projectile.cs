using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float forceStrength = 20;
    Rigidbody rb;

    [SerializeField] GameObject projectileHitVfx;
    int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * forceStrength;

    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();



        Instantiate(projectileHitVfx, transform.position, Quaternion.identity);
        playerHealth?.TakeDamage(damage);
        Destroy(gameObject);
    }


}
