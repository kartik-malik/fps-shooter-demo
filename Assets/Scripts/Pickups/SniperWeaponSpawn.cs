using UnityEngine;

// INHERITANCE
public class SniperWeaponSpawn : AmmoWeaponSpawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int elementToSpawn = 0;

    // Update is called once per frame
    void Update()
    {

    }
    // OVERRIDE POLYMORPHISM
    protected override void GetAndSpawnPickup()
    {
        var objectToSpawn = SpawnItemsList[elementToSpawn];
        Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);

        elementToSpawn = (elementToSpawn + 1) % SpawnItemsList.Length;
    }
}
