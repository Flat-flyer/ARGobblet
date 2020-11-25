using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int size = 0;
    public int color; //black is 1, white is 0
    public bool currentlySelected = false;
    [SerializeField]
    private GameObject Highlight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentlySelected == true)
        {
            if (Highlight.activeSelf == false)
            {
                Highlight.SetActive(true);
            }
        }
        else if (currentlySelected == false)
        {
            Highlight.SetActive(false);
        }
    } 
}
