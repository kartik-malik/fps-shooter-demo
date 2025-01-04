using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float radius = 1.5f;
    void Start()
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(10);
            }
        }
    }
}
