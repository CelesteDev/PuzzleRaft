using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftManagerController : MonoBehaviour
{
    [SerializeField] GameObject _raftPieceGhostObject;

    [SerializeField] GameObject _raftPiecePrefab;

    private bool _isBuilding = false;

    public void Awake()
    {
        _raftPieceGhostObject.SetActive(false);
    }

    public void TriggerBuildMode()
    {
        if (!_isBuilding)
        {
            _isBuilding = true;
        }

        _raftPieceGhostObject.SetActive(true);
    }

    //TODO: check if build valid
    //TODO: snap building to a grid
    public void AttemptBuild()
    {
        if (_isBuilding)
        {
            Vector2 buildPos = _raftPieceGhostObject.transform.position;

            Instantiate(_raftPiecePrefab, buildPos, Quaternion.identity, this.transform);
        }

        _raftPieceGhostObject.SetActive(false);
    }
}
