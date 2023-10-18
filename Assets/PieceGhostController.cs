using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PieceGhostController : MonoBehaviour
{
    [SerializeField] RaftManagerController _raftController;

    private void Update()
    {
        //make the object follow the mouse pos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //TODO: un-hardcode the tiling offset (0.5 here)
        mousePos.x = Mathf.Floor(mousePos.x + 0.5f);
        mousePos.y = Mathf.Floor(mousePos.y + 0.5f);

        this.transform.position = mousePos;

        //trigger the building attempt on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            _raftController.AttemptBuild();
        }
    }
}
