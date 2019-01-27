using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionRules : MonoBehaviour {

    public int neighboursCount;
    public GettingNeighbours gettingNeighbours;
    public int liveNeighbours, deadNeighbours;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SetNeighboursCount();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            ExecuteSimulation();
        }
    }

    public void SetNeighboursCount() {
        gettingNeighbours = gameObject.GetComponent<GettingNeighbours>();
        neighboursCount = gettingNeighbours.totalNeighbours;

        for (int i = 0; i < neighboursCount; i++)
        {
            if (gettingNeighbours.neighbours[i].GetComponentInChildren<Renderer>().material.color.r == 1f &&
                gettingNeighbours.neighbours[i].GetComponentInChildren<Renderer>().material.color.g == 1f &&
                gettingNeighbours.neighbours[i].GetComponentInChildren<Renderer>().material.color.b == 1f &&
                gettingNeighbours.neighbours[i].GetComponentInChildren<Renderer>().material.color.a == 1f)
            {
                deadNeighbours++;
            }
            else
            {
                liveNeighbours++;
            }
        }
    }

    public void ExecuteSimulation() {
        

        if (gameObject.GetComponent<Renderer>().material.color.r == 0f &&
            gameObject.GetComponent<Renderer>().material.color.g == 0f &&
            gameObject.GetComponent<Renderer>().material.color.b == 0f &&
            gameObject.GetComponent<Renderer>().material.color.a == 1f)
        {
            if(liveNeighbours < 2 || liveNeighbours > 3)
                gameObject.GetComponent<Renderer>().material.color = Color.white;
            if (liveNeighbours == 2 || liveNeighbours == 3)
                gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    
        if (gameObject.GetComponent<Renderer>().material.color.r == 1f &&
            gameObject.GetComponent<Renderer>().material.color.g == 1f &&
            gameObject.GetComponent<Renderer>().material.color.b == 1f &&
            gameObject.GetComponent<Renderer>().material.color.a == 1f )
        {
            if(liveNeighbours == 3)
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
