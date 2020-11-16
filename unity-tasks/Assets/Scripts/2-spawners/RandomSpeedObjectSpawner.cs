using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedObjectSpawner : MonoBehaviour
{

    [SerializeField] Mover[] prefabsToSpawn;
    [SerializeField] float minSpeed = 3;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 1f;
    [SerializeField] Vector2 direction = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var prefabToSpawn = prefabsToSpawn[(int)(Random.Range(0, prefabsToSpawn.Length))];
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            AssignRandomMovement(newObject);
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void AssignRandomMovement(GameObject obj)
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        Vector2 velocityOfSpawnedObject = new Vector2(speed, 0)*direction;
        obj.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        if (direction.x > 0)
            obj.GetComponent<SpriteRenderer>().flipX = true;
    }
}
