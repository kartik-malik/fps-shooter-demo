using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject target;

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {

    }
}
