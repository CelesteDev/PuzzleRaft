using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenWarningController : MonoBehaviour
{
    [SerializeField] GameObject _krakenTentaclePrefab;

    [SerializeField] float _krakenSpawnPeriod;

    private void Start()
    {
        StartCoroutine("SpawnKrakenTentacle");
    }

    private IEnumerator SpawnKrakenTentacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(_krakenSpawnPeriod);

            Instantiate(_krakenTentaclePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
