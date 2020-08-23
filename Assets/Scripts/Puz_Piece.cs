using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puz_Piece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public short x;
    public short y;
    public GameEvent gameManager;

    private Vector3 _origin;
    private bool _dragStart;
    private Transform _puzBoardEmp;

    void Start()
    {
        _dragStart = true;
        gameManager = FindObjectOfType<GameEvent>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_dragStart)
        {
            _origin = this.transform.position;
            _dragStart = false;
        }

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!PlacePiece(eventData))
            transform.position = _origin;
        gameManager.Win();
        _dragStart = true;
    }

    bool PlacePiece(PointerEventData eventData)
    {
        var slots = GameObject.FindObjectsOfType<Pi_Slot>();
        
        for (int i = 0; i < gameManager.puzBoard.transform.childCount; ++i)
        {
            _puzBoardEmp = gameManager.puzBoard.transform.GetChild(i);
            
            if (Mathf.Abs(_puzBoardEmp.gameObject.transform.position.x - this.transform.position.x) <= 55 &&
                Mathf.Abs(_puzBoardEmp.gameObject.transform.position.y - this.transform.position.y) <= 55 &&
                !_puzBoardEmp.GetComponent<Pi_Slot>().taken &&
                (_puzBoardEmp.GetComponent<Pi_Slot>().x == x && _puzBoardEmp.GetComponent<Pi_Slot>().y == y))
            {
                transform.position = _puzBoardEmp.gameObject.transform.position;
                transform.SetParent(_puzBoardEmp.transform);
                _puzBoardEmp.GetComponent<Pi_Slot>().taken = true;
                return true;
            }

        }

        return false;
    }
}
