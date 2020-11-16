using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedItemSpawner : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] float minFloatingSpeed = 3;
    [SerializeField] float maxFloatingSpeed = 10;
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 1f;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, new Vector3(Random.Range(-8, 6),0,0) + transform.position, Quaternion.identity);
            AssignRandomMovement(newObject);
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void AssignRandomMovement(GameObject obj)
    {
        float speed = Random.Range(minFloatingSpeed, maxFloatingSpeed);
        Vector3 velocityOfSpawnedObject = new Vector3((0.5f - Random.value) * speed , Random.value * speed * (-1));
        Vector3 rotationOfSpawnedObject = new Vector3(0, 0, (0.5f - Random.value) * 360);
        obj.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        obj.GetComponent<Rotator>().SetRotation(rotationOfSpawnedObject);
        
    }
}
