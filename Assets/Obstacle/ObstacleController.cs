using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        //move the obstacle toward the left
        //added division to make it more human readable on editor
        transform.Translate(Vector3.left * speed / 100.0f);

        //once offscreen, destroy
        //TODO: un-hardcode offscreen position check
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
