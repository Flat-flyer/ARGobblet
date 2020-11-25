using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndPlacePiece : GameManager
{
    private bool PlacedPiece;
    private Vector3 PreviousPos;

    private GameObject SelectedPiece;
    private Piece PieceData;
    [SerializeField]
    private BoardManager GameManager;
    private BoardSpaceData BoardData;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        Input.simulateMouseWithTouches = true;
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (Touch touch in Input.touches)
        //if (touch.phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0) == true)
        {
            Debug.Log("Touch Event Started");
            //Ray raycast = Camera.main.ScreenPointToRay(touch.position);
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Attempting Raycast");

                if (raycastHit.collider.CompareTag("BoardPiece") == true)
                {
                    // Selects piece if no piece is selected
                    if (raycastHit.collider.gameObject.GetComponent<Piece>().color == GameManager.turn && PieceData == null)
                    {
                        SelectedPiece = raycastHit.collider.gameObject;
                        PieceData = SelectedPiece.GetComponent<Piece>();
                        PieceData.currentlySelected = true;
                        PreviousPos = PieceData.gameObject.transform.position;
                        Debug.Log("Hit Piece:" + SelectedPiece.name);
                    }

                    // Selects piece when theres already a piece selected
                    else if (raycastHit.collider.gameObject.GetComponent<Piece>().color == GameManager.turn)
                    {
                        PieceData.transform.position = Vector3.MoveTowards(PieceData.transform.position, PreviousPos, 10);

                        PieceData.currentlySelected = false;
                        SelectedPiece = raycastHit.collider.gameObject;
                        PieceData = SelectedPiece.GetComponent<Piece>();
                        PieceData.currentlySelected = true;
                        PreviousPos = PieceData.gameObject.transform.position;
                    }
                }
                else if (raycastHit.collider.CompareTag("BoardSpace") == true && SelectedPiece != null)
                {
                    BoardData = raycastHit.collider.gameObject.GetComponent<BoardSpaceData>();
                    Debug.Log("Hit Board Space:" + BoardData.gameObject.name);

                    if (BoardData.TopPiece != null && BoardData.TopPiece.size < PieceData.size)
                    {
                        StartCoroutine(move(SelectedPiece.transform, BoardData.gameObject.transform.position, 1));
                        //SelectedPiece.transform.position = Vector3.Lerp(SelectedPiece.transform.position, BoardData.gameObject.transform.position, 10);
                    }
                    else if (BoardData.TopPiece == null)
                    {
                        Debug.Log("Placed piece on the empty board");
                        StartCoroutine(move(SelectedPiece.transform, BoardData.gameObject.transform.position, 1));
                        //SelectedPiece.transform.position = Vector3.Lerp(SelectedPiece.transform.position, BoardData.gameObject.transform.position, 10);
                    }
                }
                else if (raycastHit.collider.CompareTag("EndTurnButton") == true)
                {
                    Debug.Log("Ending Turn");
                    GameManager = GameObject.FindGameObjectWithTag("MainBoard").GetComponent<BoardManager>();
                    GameManager.endTurn();
                    if (PieceData != null)
                    {
                        BoardData.TopPiece = PieceData;
                        PieceData.currentlySelected = false;
                    }
                    PieceData = null;
                    SelectedPiece = null;
                }
            }
        }
    }

    IEnumerator move(Transform startPos, Vector3 endPos, float duration)
    {
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;
        float counter = 0.0f;

        Vector3 start = startPos.position;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            startPos.position = Vector3.Lerp(start, endPos, counter / duration);
            yield return null;
        }
        isMoving = false;
    }

    public void OnTapEvent()
    {
        Debug.Log("Tap Event Occured");
    }
}
