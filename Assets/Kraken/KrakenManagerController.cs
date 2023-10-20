using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenManagerController : MonoBehaviour
{
    [SerializeField] GameObject _krakenWarningPrefab;

    [SerializeField] float _krakenSpawnPeriod;

    void Start()
    {
        StartCoroutine("KrakenSpawnCoroutine");
    }

    //spawn kraken somewhere random every time timer runs out
    private IEnumerable KrakenSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_krakenSpawnPeriod);

            //generate a random position with given values
            //TODO: un-hardcode range values
            Vector2 pos = Vector2.right * Random.Range(0, 5) + Vector2.up * Random.Range(0, 7);

            //spawn the kraken parented to this
            Instantiate(_krakenWarningPrefab, pos + (Vector2)transform.position, Quaternion.identity, transform);

            StartCoroutine("KrakenSpawnCoroutine");
        }
    }
}
