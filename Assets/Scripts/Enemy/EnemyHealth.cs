using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 100;
    int currentHealth;

    [SerializeField] EnemySO enemySO;

    [SerializeField] GameObject endVfx;

    EnemyManager enemyManager;
    void Start()
    {
        currentHealth = health;
        enemyManager = FindFirstObjectByType<EnemyManager>();
        Debug.Log(enemyManager);
        enemyManager?.ChangeEnemyCount(1, enemySO);
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
            SelfDestruct();
        }
    }



    public void SelfDestruct()
    {
        Instantiate(endVfx, transform.position, Quaternion.identity);
        enemyManager?.ChangeEnemyCount(-1, enemySO);
        Destroy(gameObject);

    }

}
