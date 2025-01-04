using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject playerGameObject;
    [SerializeField] GameObject turretHead;


    Vector3 alreadyPlayerTrackedPosition;

    bool noCoRoutineInProgress = true;

    bool playerInRange = false;

    Coroutine trackingCoRoutine;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Distance ${Vector3.Distance(alreadyPlayerTrackedPosition, playerGameObject.transform.position) > 0.0001f} ${noCoRoutineInProgress}");
        if (Vector3.Distance(alreadyPlayerTrackedPosition, playerGameObject.transform.position) > 0.0001f && playerInRange && noCoRoutineInProgress == true)
        {
            TriggerInitRotation();
        }
    }

    void TriggerInitRotation()
    {
        if (trackingCoRoutine != null)
        {
            StopCoroutine(trackingCoRoutine);


        }
        noCoRoutineInProgress = false;
        Vector3 targetDirection = playerGameObject.transform.position - turretHead.transform.position;

        Quaternion rotation = Quaternion.LookRotation(targetDirection.normalized);
        trackingCoRoutine = StartCoroutine(TurretRotateRoutine(rotation, playerGameObject.transform.position));

    }

    IEnumerator TurretRotateRoutine(Quaternion rotation, Vector3 playerPosition)
    {

        float i = 0;

        Quaternion startRotation = turretHead.transform.rotation;
        while (i <= 50)
        {
            yield return new WaitForEndOfFrame();

            turretHead.transform.rotation = Quaternion.Slerp(startRotation, rotation, i / 50);
            i++;
        }


        alreadyPlayerTrackedPosition = playerPosition;
        noCoRoutineInProgress = true;

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            TriggerInitRotation();

        }

    }

    void HandleTurretRotation()
    {

        if (noCoRoutineInProgress)
        {
            turretHead.transform.LookAt(playerGameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
