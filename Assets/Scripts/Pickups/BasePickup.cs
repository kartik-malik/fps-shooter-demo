using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected abstract void OnPickup(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            OnPickup(other);
            Destroy(gameObject);
        }
    }
}
