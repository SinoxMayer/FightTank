using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bildboard : MonoBehaviour
{
    //public Transform cam;
    public Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
