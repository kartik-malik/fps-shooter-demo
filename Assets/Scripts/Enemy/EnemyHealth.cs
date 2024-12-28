using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 100;
    int currentHealth;
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
        health -= hitPoints;
        if (health <= 0)
        {
            OnHealthOver();
        }
    }

    public void OnHealthOver()
    {
        Destroy(gameObject);
    }

}
