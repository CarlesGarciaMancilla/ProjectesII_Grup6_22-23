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
    private Vector3 initialPosition;
    [SerializeField] private Collider2D destinationCollider;
    [SerializeField] private LacusMovementPrediction destinationBattery;
    [SerializeField] private Animator lacusAnimator;
    private ProtoRotation rotationScript;

    public GameObject keyspacep;
    public GameObject keyr;
    private string sceneName;

    private Vector3 camInitialPos;

    public Camera mainCamera;

    private GameObject generateMap;
    private ButtonManager buttonManager;



    // Start is called before the first frame update
    void Start()
    {
        if (generateMap == null)
        {
            generateMap = GameObject.Find("Generate Map");
            buttonManager = generateMap.GetComponent<ButtonManager>();
        }

        // Aixo NO va aqui
        sceneName = SceneManager.GetActiveScene().name;
        keyr = GameObject.Find("reset");
        keyspacep = GameObject.Find("space");

        mainCamera = Camera.main;

        camInitialPos = mainCamera.transform.position;

        initialPosition = transform.position;
        ForwardDestination();

    }

    // Update is called once per frame
    void Update()
    {
        InitiateToDestinationMovement();

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }

        if (lacusStats.batteryLeft == 0)
        {
            destination.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        if (keyr.activeSelf == false) 
        {
            SceneManager.LoadScene(sceneName);
        }

        if (lacusStats.isMoving)
        {
            lacusAnimator.SetBool("isWalking", true);
        }
        else
        {
            lacusAnimator.SetBool("isWalking", false);
        }
 
    }

    // ------------------------------
    // Funció principal de Moviment
    // ------------------------------
    IEnumerator ToDestinationMovementVEdu()
    {
        // Degut al Lerp i com esta montat el bucle, el Lerp matxaca la posició del Lacus fent que quan
        // el Lacus xoca contra una paret no es faci el reset. Per tant, per la Alpha es reverteix al moviment pas a pas
        while (lacusStats.isMoving)
        {
            float duration = 1f;
            float currentDuration = 0f;
            Vector3 start = Lacus.transform.position;
            Vector3 dest = destination.transform.position;
            while (currentDuration < duration)
            {
                currentDuration = Mathf.Min(currentDuration + Time.deltaTime, duration);
                float ratio = currentDuration / duration;
                Lacus.transform.position = Vector3.Lerp(start, dest, ratio);
                mainCamera.transform.position = Lacus.transform.position + Vector3.back * 10f;
                yield return null;
            }
        }

    }

    IEnumerator ToDestinationMovementV3()
    {
        while (lacusStats.isMoving)
        {
            Tween tweenX = Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            Tween tweenY = Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);

            yield return tweenX.WaitForCompletion();
            yield return tweenY.WaitForCompletion();

            mainCamera.transform.DOMoveX(destination.transform.position.x, 1f, false);
            mainCamera.transform.DOMoveY(destination.transform.position.y, 1f, false);
        }

    }

    IEnumerator ToDestinationMovementV2()
    {
        
        Tween tweenX = Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
        Tween tweenY = Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);

        yield return tweenX.WaitForCompletion();
        yield return tweenY.WaitForCompletion();

        mainCamera.transform.DOMoveX(destination.transform.position.x, 0.35f, false);
        mainCamera.transform.DOMoveY(destination.transform.position.y, 0.35f, false);

        // Comprobar si en els stops s'atura
        if (lacusStats.isMoving)
        {

            StartCoroutine(ToDestinationMovementV2());
        }

    }

    // Iniciador del Moviment i on hi accedeix el bucle per avançar
    public void InitiateToDestinationMovement()
    {
        if (keyspacep.activeSelf == false)
        { 
            if (!lacusStats.isMoving)
            {
                keyspacep.SetActive(true);
                lacusStats.isMoving = true;
                StartCoroutine(ToDestinationMovementV3());

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

    // Mirar en un futur els problemes del reset
    public void ResetLacus()
    {
        lacusStats.isMoving = false;
        keyspacep.SetActive(true);
        transform.DOComplete(false);
        mainCamera.transform.DOComplete(false);
        // Diria que s'ha de fer aixo per que es pugi fer reset a la bateria
        lacusStats.ResetBattery();
        // No va la recarrega del destination
        destinationBattery.FillTempBattery();
        transform.position = initialPosition;
        ResetDestinationPosition();
        mainCamera.transform.position = camInitialPos;

        // Desactiva tots els interactuables de la escena, per ara, nomes botons i fletxes activables
        buttonManager.DeactivateSprites();

    }
}
