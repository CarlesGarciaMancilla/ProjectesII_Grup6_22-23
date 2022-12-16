using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class LacusMovement : MonoBehaviour
{
    //public Transform lacusParent;
    [SerializeField] private LacusStats lacusStats;
    [SerializeField] private GameObject Lacus;
    [SerializeField] private Transform destination;
    private float rotationAngle = 0f;
    private Vector3 initialPosition;
    [SerializeField] private Collider2D destinationCollider;

    [HideInInspector] public bool isMoving = false;

    private bool resetDestination = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        InitiateToDestinationMovement();
        //InitiateMovementWithJumps();
        //InitiateMovementContinuous();
        //Forward();
        //ForwardWithSpaceKey();
        CheckIfObjectClicked();

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }

        if (lacusStats.batteryLeft == 0)
        {
            destination.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        //if (lacusStats.batteryLeft == 0 || Input.GetKeyDown(KeyCode.R)) 
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ResetLacus();
        }
 
    }



    // Funci� que fa avan�ar en Lacus en direcci� al empty una �nica casella 
    void ForwardWithSpaceKey()
    {
        // Limitar el moviment del Lacus (Implementar vida/bateria)
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    // Funci� que fa avan�ar en Lacus en direcci� al empty seguit per� no �s prec�s 
    public void Forward()
    {
        // Inici del moviment   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 1 && isMoving)
        {
            transform.DOLocalMoveX(destination.transform.position.x, 4f, false);
            transform.DOLocalMoveY(destination.transform.position.y, 4f, false);
        }
    }

    // Funci� que fa avan�ar en Lacus en direcci� al empty una �nica casella per� no es crida al Update() sino en les colisions
    public void ForwardWithJumps()
    {
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 1 && isMoving)
        {
            Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    // Funci� que rota en Lacus donat una rotaci� amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        // Rotar amb DoTween
        Lacus.transform.DORotateQuaternion(rotation, 0.3f);
    }
    
    private void InitiateMovementWithJumps()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            ForwardWithJumps();
        }
    }

    public void InitiateToDestinationMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving)
            {
                Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
                Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
            }

        }
    }
    public void ToDestinationMovement()
    {
        Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1.5f, false);
        Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1.5f, false);
    }


    private void CheckIfObjectClicked()
    {
        if (isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rotationAngle += 90f;
                ForwardDestination();
                resetDestination = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rotationAngle -= 90f;
                ForwardDestination();
                resetDestination = true;
            }

            this.gameObject.transform.Rotate(0f, 0f, rotationAngle, Space.World);

            if (resetDestination)
            {
                ResetDestinationPosition();
            }
            
            rotationAngle = 0f;
            resetDestination = false;
        }
    }


    public void ResetLacus()
    {
        isMoving = false;
        transform.DOComplete(false);
        transform.position = initialPosition;
        lacusStats.batteryLeft = lacusStats.maxBattery;
        ResetDestinationPosition();
    }

    public void ForwardDestination()
    {
        destination.transform.localPosition = new Vector3(destination.transform.localPosition.x + 1.6f, 0f, 0f);

        /*
        if (lacusStats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.RIGHT)
        {
            destination.transform.localPosition = new Vector3(destination.transform.localPosition.x + 1.6f, 0f, 0f);
        }
        else if (lacusStats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.UP)
        {
            destination.transform.localPosition = new Vector3(0f, destination.transform.localPosition.y + 1.6f, 0f);
        }
        else if (lacusStats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.LEFT)
        {
            destination.transform.localPosition = new Vector3(destination.transform.localPosition.x - 1.6f, 0f, 0f);
        }
        else if (lacusStats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.DOWN)
        {
            destination.transform.localPosition = new Vector3(0f, destination.transform.localPosition.y - 1.6f, 0f);
        }*/
    }

    public void ResetDestinationPosition()
    {
        destination.transform.localPosition = new Vector3(1.6f, 0, 0);
    }
}
