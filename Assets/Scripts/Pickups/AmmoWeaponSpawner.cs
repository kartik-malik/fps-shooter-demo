using UnityEngine;

public class AmmoWeaponSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] protected GameObject[] SpawnItemsList;
    protected bool _itemAlreadySpawned;
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnItem()
    {
        _itemAlreadySpawned = true;


        Invoke("GetAndSpawnPickup", 5f);

    }

    virtual protected void GetAndSpawnPickup()
    {
        var objectToSpawn = SpawnItemsList[Random.Range(0, SpawnItemsList.Length)];
        Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
    }



    public void MarkSpawnPossible()
    {
        _itemAlreadySpawned = false;

        SpawnItem();

    }
}
