using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Chase : MonoBehaviour
{
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.position + new Vector3(0, 0, 1);

        transform.rotation = cam.rotation;
    }
}
