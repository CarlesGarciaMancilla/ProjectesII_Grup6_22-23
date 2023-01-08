using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.SceneManagement;

public class LacusMovement : MonoBehaviour
{
    //public Transform lacusParent;
    [SerializeField] private LacusStats lacusStats;
    [SerializeField] private GameObject Lacus;
    [SerializeField] private Transform destination;
    private float rotationAngle = 0f;
    private Vector3 initialPosition;
    [SerializeField] private Collider2D destinationCollider;
    [SerializeField] private LacusMovementPrediction destinationBattery;
    public GameObject keyspacep;
    private string sceneName;


    [HideInInspector] public bool isMoving = false;

    private bool resetDestination = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        keyspacep = GameObject.Find("space");
        initialPosition = transform.position;
        //ResetLacus();
        //ResetLacus();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lacusStats.batteryLeft);
        InitiateToDestinationMovement();

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
            SceneManager.LoadScene(sceneName);
        }
 
    }


    // Funció que rota en Lacus donat una rotació amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        Lacus.transform.DORotateQuaternion(rotation, 0.3f);
    }

    public void InitiateToDestinationMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) || keyspacep.activeSelf == false)
        {
            if (!isMoving)
            {
                Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
                Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
                isMoving = true;
            }

        }
    }
    public void ToDestinationMovement()
    {
        Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
        Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
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
                destinationBattery.FillTempBattery();
            }
            
            rotationAngle = 0f;
            resetDestination = false;
        }
    }


    public void ResetLacus()
    {
        isMoving = false;
        keyspacep.SetActive(true);
        transform.DOComplete(false);
        transform.position = initialPosition;
        ResetDestinationPosition();

        // Diria que s'ha de fer aixo per que es pugi fer reset a la bateria
        lacusStats.ResetBattery();

        // No va la recarrega del destination
        destinationBattery.FillTempBattery();
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
        destinationBattery.FillTempBattery(lacusStats.batteryLeft);
    }


    public void InitiateMovement()
    {       
            if (!isMoving)
            {
                Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
                Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
                isMoving = true;
            }       
    }
}
