using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerScript : MonoBehaviour
{
    public GameObject belowTile;

    public bool isSelected;

    public int playerMovement = 2;

    private char[] splitSeperators = {',', ';'};

    private List<GameObject> movableSquares = new List<GameObject>();
    private Renderer rend;
    private Color col;


    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            belowTile = hit.collider.gameObject;
        }
    }

    void ShowMovementGrid(Color col)
    {
        // clears the list before population
        movableSquares.Clear();

        // splits the name string to x and y coords
        string tileCoords = belowTile.name;
        string[] tileCoordsSplit = tileCoords.Split(splitSeperators, 2);

        // Converts the string coords to integers
        int x = Convert.ToInt32(tileCoordsSplit[0]);
        int y = Convert.ToInt32(tileCoordsSplit[1]);

        // iterates through the possible squares using the x and y coords
        for (int i = x - playerMovement; i < x + playerMovement + 1; i++)
        {
            for (int j = y - playerMovement; j < y + playerMovement + 1; j++)
            {
                // Check if Player is able to move to the selected square
                if(Math.Abs(x - i) + Math.Abs(y - j) <= playerMovement)
                {
                    movableSquares.Add(GameObject.Find(i + "," + j));
                }
            }
        }

        // changes the colour of the selected squares to show the movement grid
        foreach(var ms in movableSquares)
        {
            if(ms != null)
            {
                ms.GetComponent<Renderer>().material.color = col;
            }
        }
    }

    void OnMouseEnter()
    {
        if (!isSelected)
            rend.material.color = Color.yellow;
    }

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        if(!isSelected)
            rend.material.color = col;
    }

    void OnMouseDown()
    {
        if (!isSelected)
        {
            rend.material.color = Color.green;
            isSelected = true;
            ShowMovementGrid(Color.magenta);
        }
        else
        {
            rend.material.color = Color.yellow;
            isSelected = false;

            // sets colour back to original when Player isn't selected
            foreach(var ms in movableSquares)
            {
                if(ms != null)
                {
                    ms.GetComponent<Renderer>().material.color = ms.GetComponent<SquareScript>().OGColor;
                }
            }

            movableSquares.Clear();
        }
    }
}
