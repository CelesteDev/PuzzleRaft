using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPieceController : MonoBehaviour
{
    private RaftManagerController _raftController;

    void Awake()
    {
        _raftController = GetComponentInParent<RaftManagerController>(); 
    }

    void Start()
    {
        int x = (int)gameObject.transform.localPosition.x;
        int y = (int)gameObject.transform.localPosition.y;

        _raftController.SetIsBuiltTile(x, y, true);

        Debug.Log("Ticking tile x: " + x + ", y: " + y);
    }

    private void OnMouseUp()
    {
        if (_raftController.AttemptTriggerBuildMode())
        {
            int x = (int)gameObject.transform.localPosition.x;
            int y = (int)gameObject.transform.localPosition.y;

            _raftController.SetIsBuiltTile(x, y, false);

            Debug.Log("Unticking tile x: " + x + ", y: " + y);

            Destroy(gameObject);
        }
    }
}
