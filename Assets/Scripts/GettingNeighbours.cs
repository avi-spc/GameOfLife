using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingNeighbours : MonoBehaviour
{
    public GameObject[] neighbours;
    public PlatformGenerator platform;

    public int i, totalNeighbours;
    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformGenerator>();
        i = gameObject.GetComponent<UnitIndex>().index;
        ConnectToNeighbours();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ConnectToNeighbours()
    {
        if (i == 0 || i == platform.xSize - 1 || i == platform.xSize * platform.zSize - platform.xSize || i == platform.xSize * platform.zSize - 1)
        {
            totalNeighbours = 3;
            neighbours = new GameObject[totalNeighbours];
            CornerCases();
        }
        else if ((i > 0 && i < platform.xSize) || (i > platform.xSize*platform.zSize-platform.xSize && i < platform.xSize*platform.zSize-1))
        {
            totalNeighbours = 5;
            neighbours = new GameObject[totalNeighbours];

            if (i > platform.xSize)
            {
                neighbours[0] = platform.platUnit[i - (platform.xSize + 1)];
                neighbours[1] = platform.platUnit[i - platform.xSize];
                neighbours[2] = platform.platUnit[i - platform.xSize + 1];
                neighbours[3] = platform.platUnit[i + 1];
                neighbours[4] = platform.platUnit[i - 1];
            }
            else
            {
                neighbours[0] = platform.platUnit[i - 1];
                neighbours[1] = platform.platUnit[i + 1];
                neighbours[2] = platform.platUnit[i + platform.xSize - 1];
                neighbours[3] = platform.platUnit[i + platform.xSize];
                neighbours[4] = platform.platUnit[i + platform.xSize + 1];
            }
        }
        else if (MultipleLeftVertical(i))
        {
            totalNeighbours = 5;
            neighbours = new GameObject[totalNeighbours];

            neighbours[0] = platform.platUnit[i - platform.xSize];
            neighbours[1] = platform.platUnit[i - platform.xSize + 1];
            neighbours[2] = platform.platUnit[i + 1];
            neighbours[3] = platform.platUnit[i + platform.xSize];
            neighbours[4] = platform.platUnit[i + platform.xSize + 1];
        }
        else if (MultipleRightVertical(i))
        {
            totalNeighbours = 5;
            neighbours = new GameObject[totalNeighbours];

            neighbours[0] = platform.platUnit[i - platform.xSize - 1];
            neighbours[1] = platform.platUnit[i - platform.xSize];
            neighbours[2] = platform.platUnit[i - 1];
            neighbours[3] = platform.platUnit[i + platform.xSize -1];
            neighbours[4] = platform.platUnit[i + platform.xSize];
        }
        else
        {
            totalNeighbours = 8;
            neighbours = new GameObject[totalNeighbours];

            neighbours[0] = platform.platUnit[i - platform.xSize - 1];
            neighbours[1] = platform.platUnit[i - platform.xSize];
            neighbours[2] = platform.platUnit[i - platform.xSize + 1];
            neighbours[3] = platform.platUnit[i - 1];
            neighbours[4] = platform.platUnit[i + 1];
            neighbours[5] = platform.platUnit[i + platform.xSize - 1];
            neighbours[6] = platform.platUnit[i + platform.xSize];
            neighbours[7] = platform.platUnit[i + platform.xSize + 1];

        }

    }

    void CornerCases()
    {
        if (i == 0)
        {
            neighbours[0] = platform.platUnit[i + 1];
            neighbours[1] = platform.platUnit[i + platform.xSize];
            neighbours[2] = platform.platUnit[i + platform.xSize + 1];
        }
        else if (i == platform.xSize - 1)
        {
            neighbours[0] = platform.platUnit[i - 1];
            neighbours[1] = platform.platUnit[i + platform.xSize - 1];
            neighbours[2] = platform.platUnit[i + platform.xSize];
        }
        else if (i == platform.xSize * platform.zSize - platform.xSize)
        {
            neighbours[0] = platform.platUnit[i - platform.xSize];
            neighbours[1] = platform.platUnit[i - platform.xSize - 1];
            neighbours[2] = platform.platUnit[i + 1];
        }
        else if (i == platform.xSize * platform.zSize - 1)
        {
            neighbours[0] = platform.platUnit[i - (platform.xSize + 1)];
            neighbours[1] = platform.platUnit[i - platform.xSize];
            neighbours[2] = platform.platUnit[i - 1];
        }
    }

    public bool MultipleLeftVertical(int ind)
    {
        if (ind % platform.xSize == 0)
            return true;
        return false;

    }

    public bool MultipleRightVertical(int ind)
    {
        if (ind % platform.xSize == platform.xSize - 1)
        {
            return true;
        }
        return false;
    }
}
