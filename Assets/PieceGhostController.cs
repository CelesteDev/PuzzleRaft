using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PieceGhostController : MonoBehaviour
{
    [SerializeField] RaftManagerController _raftController;

    //TODO: make the piece snap to a grid
    private void Update()
    {
        //make the object follow the mouse pos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = mousePos;

        //trigger the building attempt on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            _raftController.AttemptBuild();
        }
    }
}
