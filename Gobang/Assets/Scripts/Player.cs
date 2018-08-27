using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public ChessType chessType = ChessType.Black;

    

    protected virtual void FixedUpdate()
    {
        if (chessType == Chessboard.Instance.turn && Chessboard.Instance.timer >= 0.2f)
            PlayChess();
    }

    public virtual void PlayChess()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Chessboard.Instance.PlayChess(new int[2] { (int)(pos.x + 7.5f), (int)(pos.y + 7.5) }))
                Chessboard.Instance.timer = 0;
        }

    }

}
