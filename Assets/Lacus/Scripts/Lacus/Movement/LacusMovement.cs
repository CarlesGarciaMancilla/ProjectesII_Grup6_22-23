using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

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

        if (lacusStats.batteryLeft <= 1 || Input.GetKeyDown(KeyCode.R)) 
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

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rotationAngle -= 90f;

            }
            this.gameObject.transform.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;
        }
    }


    public void ResetLacus()
    {
        transform.position = initialPosition;
        isMoving = false;
        lacusStats.batteryLeft = lacusStats.maxBattery;
    }
}
