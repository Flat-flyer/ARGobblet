using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpaceData : MonoBehaviour
{
    public Piece[] PieceArray = new Piece[4];
    public Piece TopPiece = null;
    public int PiecesInSpace = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoardPiece") == true)
        {
            if (PiecesInSpace > 0 && PieceArray[PiecesInSpace].size < other.GetComponent<Piece>().size)
            {
                PiecesInSpace++;
                PieceArray[PiecesInSpace] = other.GetComponent<Piece>();
                TopPiece = PieceArray[PiecesInSpace];
            }
            else if (PiecesInSpace == 0)
            {
                PiecesInSpace++;
                PieceArray[PiecesInSpace] = other.GetComponent<Piece>();
                TopPiece = PieceArray[PiecesInSpace];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoardPiece") == true)
        {
            if (other.GetComponent<Piece>() == PieceArray[PiecesInSpace])
            {
                PieceArray[PiecesInSpace] = null;
                PiecesInSpace --;
                TopPiece = PieceArray[PiecesInSpace];
            }
        }
    }
}
