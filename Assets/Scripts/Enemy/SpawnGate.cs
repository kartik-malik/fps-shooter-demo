using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject robotPrefab;
    [SerializeField] PlayerHealth playerHealth;
    void Start()
    {
        StartCoroutine(SpawnRoutine());

    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator SpawnRoutine()
    {
        while (playerHealth.CurrentHealth > 0)
        {
            yield return new WaitForSeconds(5);

            Instantiate(robotPrefab, transform.position, Quaternion.identity);
        }

        yield return null;
    }
}