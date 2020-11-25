using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private BoardSpaceData[] boardSpaces = new BoardSpaceData[16];
    [SerializeField]
    private GameObject TurnIndicatorWhite;
    [SerializeField]
    private GameObject TurnIndicatorBlack;
    public int turn = 0; // 1 for black, 0 for white

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endTurn()
    {
        Debug.Log("Turn Ended");
        if (CheckWin(boardSpaces) == 1)
        {
            Debug.Log("Black Win");
        }
        else if (CheckWin(boardSpaces) == 0)
        {
            Debug.Log("White Win");
        }
        else if (CheckWin(boardSpaces) == 2)
        {
            if (turn == 0)
            {
                TurnIndicatorBlack.SetActive(true);
                TurnIndicatorWhite.SetActive(false);
                turn = 1;
            }
            else
            {
                TurnIndicatorBlack.SetActive(false);
                TurnIndicatorWhite.SetActive(true);
                turn = 0;
            }
        }
    }

    public int CheckWin(BoardSpaceData[] boardSpaces)
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("Win Check");
            // Right/Left
            if (boardSpaces[i * 4].TopPiece != null && boardSpaces[i * 4 + 1].TopPiece != null && boardSpaces[i * 4 + 2].TopPiece != null && boardSpaces[i * 4 + 3].TopPiece != null)
            //if (boardSpaces[0].TopPiece != null && boardSpaces[1].TopPiece != null && boardSpaces[2].TopPiece != null && boardSpaces[3].TopPiece != null)
            {
                if (boardSpaces[i * 4].TopPiece.color == boardSpaces[i * 4 + 1].TopPiece.color && boardSpaces[i * 4 + 2].TopPiece.color == boardSpaces[i * 4 + 3].TopPiece.color && boardSpaces[i * 4].TopPiece.color == boardSpaces[i * 4 + 2].TopPiece.color)
                {
                    boardSpaces[i * 4].TopPiece.currentlySelected = true;
                    boardSpaces[i * 4 + 1].TopPiece.currentlySelected = true;
                    boardSpaces[i * 4 + 2].TopPiece.currentlySelected = true;
                    boardSpaces[i * 4 + 3].TopPiece.currentlySelected = true;

                    return boardSpaces[i * 4].TopPiece.color;
                }
            }

            // Up/Down
            else if (boardSpaces[i].TopPiece != null && boardSpaces[i + 4].TopPiece != null && boardSpaces[i + 8].TopPiece != null && boardSpaces[i + 12].TopPiece != null)
            {
                if (boardSpaces[i].TopPiece.color == boardSpaces[i + 4].TopPiece.color && boardSpaces[i + 8].TopPiece.color == boardSpaces[i + 12].TopPiece.color && boardSpaces[i].TopPiece.color == boardSpaces[i + 8].TopPiece.color)
                {
                    boardSpaces[i].TopPiece.currentlySelected = true;
                    boardSpaces[i + 4].TopPiece.currentlySelected = true;
                    boardSpaces[i + 8].TopPiece.currentlySelected = true;
                    boardSpaces[i + 12].TopPiece.currentlySelected = true;

                    return boardSpaces[i].TopPiece.color;
                }
            }

            // Top left to bottom right
            else if (boardSpaces[0].TopPiece != null && boardSpaces[5].TopPiece != null && boardSpaces[10].TopPiece != null && boardSpaces[15].TopPiece != null)
            {
                if (boardSpaces[0].TopPiece.color == boardSpaces[5].TopPiece.color && boardSpaces[10].TopPiece.color == boardSpaces[15].TopPiece.color && boardSpaces[0].TopPiece.color == boardSpaces[10].TopPiece.color)
                {
                    boardSpaces[0].TopPiece.currentlySelected = true;
                    boardSpaces[5].TopPiece.currentlySelected = true;
                    boardSpaces[10].TopPiece.currentlySelected = true;
                    boardSpaces[15].TopPiece.currentlySelected = true;
                    return boardSpaces[0].TopPiece.color;
                }
            }

            // Top right to bottom left
            else if (boardSpaces[3].TopPiece != null && boardSpaces[6].TopPiece != null && boardSpaces[9].TopPiece != null && boardSpaces[12].TopPiece != null)
            {
                if (boardSpaces[3].TopPiece.color == boardSpaces[6].TopPiece.color && boardSpaces[9].TopPiece.color == boardSpaces[12].TopPiece.color && boardSpaces[3].TopPiece.color == boardSpaces[9].TopPiece.color)
                {
                    boardSpaces[3].TopPiece.currentlySelected = true;
                    boardSpaces[6].TopPiece.currentlySelected = true;
                    boardSpaces[9].TopPiece.currentlySelected = true;
                    boardSpaces[12].TopPiece.currentlySelected = true;
                    return boardSpaces[3].TopPiece.color;
                }
            }
        }
        return 2;
    }
}
