using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManagerController : MonoBehaviour
{
    [SerializeField] float _spawnPeriod;

    [SerializeField] GameObject _obstaclePrefab;

    void Start()
    {
        StartCoroutine("CountdownSpawn");
    }

    //spawn an obstacle everytime the coroutine is called
    private IEnumerator CountdownSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnPeriod);

            Debug.Log("Spawning enemy");

            //range on the y axis of the rock
            //TODO: un-hardcode the range
            Vector2 pos = Random.Range(0, 6) * Vector2.up;

            //spawn the obstacle relative to the manager
            Instantiate(_obstaclePrefab, pos + (Vector2) transform.position, Quaternion.identity, transform);
        }
    }

    private void spawnEnemy()
    {
        
    }
}
