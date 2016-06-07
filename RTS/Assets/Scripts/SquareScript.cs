using UnityEngine;
using System.Collections;

public class SquareScript : MonoBehaviour
{
    public GameObject PlayerObject;
    public bool isTaken;
    public Color OGColor;

    private Renderer rend;
    private Color tempColor;
    private RaycastHit hit;

    void Start()
    {
        rend = GetComponent<Renderer>();
        OGColor = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.up, out hit, 1.0f))
        {
            PlayerObject = hit.collider.gameObject;
            isTaken = true;
        }
        else
        {
            PlayerObject = null;
            isTaken = false;
        }
    }
    
    void OnMouseEnter()
    {
        tempColor = GetComponent<Renderer>().material.color;
        rend.material.color = Color.cyan;
    }

    void OnMouseOver()
    {
        
    }

    void OnMouseExit()
    {
        rend.material.color = tempColor;
        tempColor = OGColor;
    }
}
