using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTentacleController : MonoBehaviour
{
    [SerializeField] float _krakenTentacleDespawnTime;

    void Start()
    {
        StartCoroutine("DespawnTentacle");
    }

    private IEnumerator DespawnTentacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(_krakenTentacleDespawnTime);

            Destroy(gameObject);
        }
    }
}
