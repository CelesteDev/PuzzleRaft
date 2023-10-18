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

    private void OnMouseUp()
    {
        _raftController.TriggerBuildMode();

        Destroy(gameObject);
    }
}
