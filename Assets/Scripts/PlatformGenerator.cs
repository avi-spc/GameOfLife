using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    Vector3[] vertices;

    public int xSize;
    public int zSize;

    public GameObject platformUnit;
    public GameObject[] platUnit;

    void Awake() {
        platUnit = new GameObject[xSize * zSize];
        GeneratePlatform();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlatform() {
        vertices = new Vector3[xSize * zSize];
        for (int i=0, z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                vertices[i] = new Vector3(x, 0, z);
                platUnit[i] = Instantiate(platformUnit, vertices[i], Quaternion.Euler(90, 0, 0));
                platUnit[i].GetComponentInChildren<UnitIndex>().index = i;
                platformUnit.name = "Unit" + i.ToString();
                i++;
            }
        }
    }
    
}
