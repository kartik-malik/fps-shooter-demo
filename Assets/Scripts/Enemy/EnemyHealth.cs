using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 100;
    int currentHealth;

    [SerializeField] GameObject endVfx;
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnHit(int hitPoints)
    {
        currentHealth -= hitPoints;

        Debug.Log($"Hit enemy ${gameObject.name}");
        if (currentHealth <= 0)
        {

            Instantiate(endVfx, transform.position, Quaternion.identity);
            OnHealthOver();
        }
    }

    public void OnHealthOver()
    {
        Destroy(gameObject);
    }

    public void SelfDestruct()
    {
        Instantiate(endVfx, transform.position, Quaternion.identity);
        OnHealthOver();
        Destroy(gameObject);

    }

}
