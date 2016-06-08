using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquareGenerationScript : MonoBehaviour
{
    public GameObject square;
    public GameObject player;

    public Vector3 playerPosition = new Vector3(0,0,0);

    public int gridWidth;
    public int gridDepth;

    private float squareWidth;
    private float squareHeight;
    private float squareDepth;

    private float squareHeightOffset;

    public List<List<GameObject>> grid = new List<List<GameObject>>();

    public GameObject selectedTile;

    private GameObject Player;
    public GameObject selectedPlayer;

    void setSizes()
    {
        squareWidth = square.GetComponent<Renderer>().bounds.size.x;
        squareHeight = square.GetComponent<Renderer>().bounds.size.y;
        squareDepth = square.GetComponent<Renderer>().bounds.size.z;

        squareHeightOffset = squareHeight / 2;
    }

    void generateGrid()
    {
        for(int z = 0; z < gridDepth; z++)
        {
            List<GameObject> row = new List<GameObject>();
            for(int x = 0; x < gridWidth; x++)
            {
                GameObject gridSquare = Instantiate(square) as GameObject;
                gridSquare.name = z + "," + x;
                gridSquare.transform.position = new Vector3(x, 0, z);
                if((z % 2 == 0 && x % 2 != 0) || (z % 2 != 0 && x % 2 == 0))
                {
                    gridSquare.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    gridSquare.GetComponent<Renderer>().material.color = Color.black;
                }
                row.Add(gridSquare);
            }
            grid.Add(row);
        }
    }

    public Vector3 Move(Vector3 _playerPosition, Vector3 _squarePosition)
    {
        float XOffset = _playerPosition.x - _squarePosition.x;
        float ZOffset = _playerPosition.z - _squarePosition.z;

        //if()
        Vector3 newPosition = new Vector3();
        return newPosition;
    }

	// Use this for initialization
	void Start ()
    {
        setSizes();
		generateGrid();
        Player = Instantiate(player);
        Player.name = "Player";
        playerPosition.y = grid[0][0].transform.position.y + (Player.GetComponent<Renderer>().bounds.size.y / 2) + squareHeightOffset;
        Player.transform.position = new Vector3 (playerPosition.x, playerPosition.y, playerPosition.z);
    }

    void Update()
    {
        foreach(var selPlayer in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(selPlayer.GetComponent<PlayerScript>().isSelected)
            {
                selectedPlayer = selPlayer;
                break;
            }
            else
            {
                selectedPlayer = null;
            }
        }
    }
}
