using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject platform = GameObject.FindGameObjectWithTag("Platform");
        transform.position = new Vector3(platform.GetComponent<PlatformGenerator>().xSize / 2, platform.GetComponent<PlatformGenerator>().xSize , platform.GetComponent<PlatformGenerator>().zSize / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
}
