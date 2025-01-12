using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject target;

    [SerializeField] Animator animator;

    EnemyHealth enemyHealth;

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;

        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Death", true);
            Invoke("DestructRobot", 2f);
        }
    }

    void DestructRobot()
    {
        enemyHealth.SelfDestruct();

    }
}
