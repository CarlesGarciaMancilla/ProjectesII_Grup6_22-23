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
    public GameObject keyr;
    private string sceneName;


    [HideInInspector] public bool isMoving = false;

    private bool resetDestination = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        keyr = GameObject.Find("reset");
       
        keyspacep = GameObject.Find("space");
        initialPosition = transform.position;
        //ResetLacus();
        //ResetLacus();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lacusStats.batteryLeft);
        InitiateToDestinationMovement();

        RotationLacusKeyboard();

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }

        if (lacusStats.batteryLeft == 0)
        {
            destination.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        //if (lacusStats.batteryLeft == 0 || Input.GetKeyDown(KeyCode.R)) 
        if (Input.GetKeyDown(KeyCode.R) || keyr.activeSelf == false) 
        {
            SceneManager.LoadScene(sceneName);
            
        }
 
    }



    // Funció que rota en Lacus donat una rotació amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        Lacus.transform.DORotateQuaternion(rotation, 0.3f);
    }

    // ------------------------------
    // Funció principal de Moviment
    // ------------------------------

    IEnumerator ToDestinationMovementV2()
    {
        Debug.Log("AAA");
        Tween tweenX = Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
        Tween tweenY = Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);

        yield return tweenX.WaitForCompletion();
        yield return tweenY.WaitForCompletion();

        StartCoroutine(ToDestinationMovementV2());

        // This log will happen after the tween has completed
        Debug.Log("Tween completed!");
    }
    public void ToDestinationMovement()
    {
        Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
        Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
    }

    // Iniciador del Moviment i on hi accedeix el bucle per avançar
    public void InitiateToDestinationMovement()
    {

            ;
        if (Input.GetKeyDown(KeyCode.Space) || keyspacep.activeSelf == false)
        {
            if (!isMoving)
            {
                //ToDestinationMovement();
                Debug.Log("BBBB");
                StartCoroutine(ToDestinationMovementV2());
                isMoving = true;

            }

        }
    }
    
    // Funció avançar Destination
    public void ForwardDestination()
    {
        destination.transform.localPosition = new Vector3(destination.transform.localPosition.x + 1.6f, 0f, 0f);
    }

    // Reset del Destination
    public void ResetDestinationPosition()
    {
        destination.transform.localPosition = new Vector3(1.6f, 0, 0);
        destinationBattery.FillTempBattery(lacusStats.batteryLeft);
    }

    

    // S'ha de cambiar / eliminar per la versió de click a sobre del lacus
    private void RotationLacusKeyboard()
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






    // Mirar en un futur els problemes del reset
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
}
