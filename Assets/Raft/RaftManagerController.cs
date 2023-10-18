using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftManagerController : MonoBehaviour
{
    [SerializeField] GameObject _raftPieceGhostObject;

    [SerializeField] GameObject _raftPiecePrefab;

    private bool _isBuilding = false;

    [SerializeField] int _raftWidth;
    [SerializeField] int _raftHeight;

    //boolean matrix representing wether raft is built on a specific tile
    private bool[,] _isTileBuilt;

    public void SetIsBuiltTile(int x, int y, bool state)
    {
        _isTileBuilt[x, y] = state;
    }

    public void Awake()
    {
        _raftPieceGhostObject.SetActive(false);

        _isTileBuilt = new bool[_raftWidth,_raftHeight];
    }

    public bool AttemptTriggerBuildMode()
    {
        if (!_isBuilding)
        {
            _isBuilding = true;

            _raftPieceGhostObject.SetActive(true);

            return true;
        }

        return false;
    }

    //TODO: check if build valid
    public void AttemptBuild()
    {
        if (_isBuilding)
        {
            Vector2 buildPos = _raftPieceGhostObject.transform.localPosition;

            int tilePosX = (int)buildPos.x;
            int tilePosY = (int)buildPos.y;

            Debug.Log("Attempting to build at tile x:" + tilePosX + ", y:" + tilePosY);

            if(tilePosX >= 0 && tilePosY >= 0 && tilePosX < _raftWidth && tilePosY < _raftHeight && !_isTileBuilt[tilePosX, tilePosY])
            {
                bool isValid = false;

                if(tilePosX >= 1 && _isTileBuilt[tilePosX - 1, tilePosY])
                {
                    isValid = true;
                }

                if (tilePosX < _raftWidth - 1 && _isTileBuilt[tilePosX + 1, tilePosY])
                {
                    isValid = true;
                }

                if (tilePosY >= 1 && _isTileBuilt[tilePosX, tilePosY - 1])
                {
                    isValid = true;
                }

                if (tilePosY < _raftHeight - 1 && _isTileBuilt[tilePosX, tilePosY + 1])
                {
                    isValid = true;
                }

                if (isValid)
                {
                    Instantiate(_raftPiecePrefab, _raftPieceGhostObject.transform.position, Quaternion.identity, transform);

                    _raftPieceGhostObject.SetActive(false);

                    _isBuilding = false;
                }
            }
        }   
    }
}
