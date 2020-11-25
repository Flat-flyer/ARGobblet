using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;

    public Piece[,] pieceBoard = new Piece[4, 4];
    

    //void makeSingleton()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    void Awake()
    {
        //makeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckWin(BoardSpaceData[] boardSpaces)
    {
        for (int i = 0; i < 4; i++)
        {
            if (boardSpaces[i * 4].TopPiece.color == 0 && boardSpaces[i * 4 + 1].TopPiece.color == 0 && boardSpaces[i * 4 + 2].TopPiece.color == 0 && boardSpaces[i * 4 + 3].TopPiece.color == 0)
            {
                boardSpaces[i * 4].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 1].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 2].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 3].TopPiece.currentlySelected = true;
                return true;
            }
            else if (boardSpaces[i * 4].TopPiece.color == 1 && boardSpaces[i * 4 + 1].TopPiece.color == 1 && boardSpaces[i * 4 + 2].TopPiece.color == 1 && boardSpaces[i * 4 + 3].TopPiece.color == 1)
            {
                boardSpaces[i * 4].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 1].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 2].TopPiece.currentlySelected = true;
                boardSpaces[i * 4 + 3].TopPiece.currentlySelected = true;
                return true;
            }
        }
        return false;
    }

// end of class
}