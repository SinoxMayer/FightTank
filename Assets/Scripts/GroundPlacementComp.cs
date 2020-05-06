using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementComp : MonoBehaviour
{

    [SerializeField] private GameObject placeableObjectPre;
    [SerializeField] private KeyCode newObjectHotkey = KeyCode.B;

    private GameObject currentPlaceableObj;
    private float mouseWheelRotation;
    private GameManager gameManager;

    public bool placedToGround =false;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleNewObjectHotkey();
        if (currentPlaceableObj != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
            
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObj = null;
            placedToGround = true;
        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation = Input.mouseScrollDelta.y;
        currentPlaceableObj.transform.Rotate(Vector3.up,mouseWheelRotation * 10f);
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.tag != "Duvar" && hitInfo.transform.tag == "Zemin")
        {
            currentPlaceableObj.transform.position = hitInfo.point;
            currentPlaceableObj.transform.rotation = Quaternion.FromToRotation(Vector3.up , hitInfo.normal);
        }
    }

    private void HandleNewObjectHotkey()
    {
        if (Input.GetKeyDown(newObjectHotkey))
        {
            if (gameManager.score >= 600)
            {   

                if (currentPlaceableObj == null)
                {
                    currentPlaceableObj = Instantiate(placeableObjectPre);
                    gameManager.ScoreBoard(-600);
                }
                else
                {
                    Destroy(currentPlaceableObj);
                }

            }
           
          
        }
    }
}
