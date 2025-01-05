using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] Transform playerCameraRootObj;
    [SerializeField] Transform turretHead;

    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate = 3;

    void Start()
    {
        StartCoroutine(SpawnProjectileRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        turretHead.LookAt(playerCameraRootObj);
    }

    IEnumerator SpawnProjectileRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnTransform.position, Quaternion.identity);
            newProjectile.transform.LookAt(playerCameraRootObj);
            newProjectile.GetComponent<Projectile>().Init(20);
        }
    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }
}
