using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    [SerializeField] private Transform Lacus;

    private Vector3 initialPosition;
    private Vector3 displacement;
    private Vector3 cameraPosition;

    private float maximumLeft = -0.4f;

    private bool isDragging = false;

    void Start()
    {
        initialPosition = Lacus.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            displacement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;

            if (!isDragging)
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
            Camera.main.transform.position = cameraPosition-displacement;
        }

        /*if (buttonReset)
        {
            Camera.main.transform.position = initialPosition
        }*/
    }


}
