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

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        maximumDownRight = file.FarthestWallPosition();

        // Correcci� de la generaci� de tiles
        maximumDownRight.y = -maximumDownRight.y;
        maximumDownRight.x -= 4.35f;
        maximumDownRight.y += 6.4f;
    }

    private void Update()
    {
        CameraMovement();
    }


    void CameraMovement()
    {
        // No ho fico al Start, perque aquest script s'executa abans de que es generi el nivell
        if (initialPosition == new Vector3(-1.0f, -1.0f, -1.0f))
        {
            initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            
            displacement = mainCamera.ScreenToWorldPoint(Input.mousePosition) - mainCamera.transform.position;


            if(!isDragging)
            {
                isDragging = true;
                cameraPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            isDragging = false;
        }

        if (isDragging)
        {

            if (CheckBoundariesX())
            {
                mainCamera.transform.position = new Vector3(cameraPosition.x - displacement.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            if (CheckBoundariesY())
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraPosition.y - displacement.y, mainCamera.transform.position.z);
            }
            UnStuckCameraOnCollision();

        }


    }

    bool CheckBoundariesX()
    {
        // AABB
        if (mainCamera.transform.position.x >= maximumLeft &&
            mainCamera.transform.position.x <= maximumDownRight.x)
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
        // AABB
        if (mainCamera.transform.position.y <= maximumUp &&
            mainCamera.transform.position.y >= maximumDownRight.y)
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
        if (mainCamera.transform.position.x > maximumDownRight.x)
        {
            mainCamera.transform.position = new Vector3(maximumDownRight.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
        if (mainCamera.transform.position.x < maximumLeft)
        {
            mainCamera.transform.position = new Vector3(maximumLeft, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
        if (mainCamera.transform.position.y < maximumDownRight.y)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, maximumDownRight.y, mainCamera.transform.position.z);
        }
        if (mainCamera.transform.position.y > maximumUp)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, maximumUp, mainCamera.transform.position.z);
        }
    }
}
