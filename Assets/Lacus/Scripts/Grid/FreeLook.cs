using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    [SerializeField] private ReadLevelFile file;

    private Vector3 initialPosition = new Vector3(-1.0f, -1.0f, -1.0f);
    private Vector3 displacement;
    private Vector3 cameraPosition;

    private float maximumLeft = 2;
    private float maximumUp = -3;

    private Vector2 maximumDownRight;

    private bool isDragging = false;

    void Start()
    {
        maximumDownRight = file.FarthestWallPosition();

        // Correcció de la generació de tiles
        maximumDownRight.y = -maximumDownRight.y;
        maximumDownRight.x -= 3.35f;
        maximumDownRight.y += 2.9f;




    }

    private void Update()
    {
        CameraMovement();
        /*if (buttonReset)
        {
            Camera.main.transform.position = initialPosition
        }*/
    }


    void CameraMovement()
    {

        //Debug.Log("Left: " + maximumLeft + " Up: " + maximumUp + " Right: " + maximumDownRight.x + " Down: " + maximumDownRight.y);
        // No ho fico al Start, perque aquest script s'executa abans de que es generi el nivell
        if (initialPosition == new Vector3(-1.0f, -1.0f, -1.0f))
        {
            initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            
            displacement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;


            if(!isDragging)
            {
                isDragging = true;
                cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            isDragging = false;
        }

        if (isDragging)
        {
            UnStuckCameraOnCollision();
            if (CheckBoundariesX())
            {
                Camera.main.transform.position = new Vector3(cameraPosition.x - displacement.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            if (CheckBoundariesY())
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, cameraPosition.y - displacement.y, Camera.main.transform.position.z);
            }
            
        }


    }

    bool CheckBoundariesX()
    {
        // AABB
        //Debug.Log("Term 1: " + Camera.main.transform.position.x + " >= " + maximumLeft + " Term 2: " + Camera.main.transform.position.x + " <= " + maximumDownRight.x);

        if (Camera.main.transform.position.x >= maximumLeft &&
            Camera.main.transform.position.x <= maximumDownRight.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckBoundariesY()
    {
        Debug.Log("Term 1: " + Camera.main.transform.position.y + " >= " + maximumUp + "Term 2: " + Camera.main.transform.position.y + " >= " + maximumDownRight.y);
        // AABB
        if (Camera.main.transform.position.y >= maximumUp &&
            Camera.main.transform.position.y <= maximumDownRight.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UnStuckCameraOnCollision()
    {
        if (Camera.main.transform.position.x < maximumLeft)
        {
            Camera.main.transform.position = new Vector3(maximumLeft, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        if (Camera.main.transform.position.x > maximumDownRight.x)
        {
            Camera.main.transform.position = new Vector3(maximumDownRight.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        /*if (Camera.main.transform.position.y > maximumUp)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, maximumUp, Camera.main.transform.position.z);
        }
        if (Camera.main.transform.position.y < maximumDownRight.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, maximumDownRight.y, Camera.main.transform.position.z);
        }*/


    }
}
