using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TileSpriteFletxa : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public SpriteRenderer spriteRenderer;
    public GameObject highlight;
    public float cooldown;
    private Vector3 rotationRight = new Vector3(0, 0, 0f);
    private Vector3 rotationLeft = new Vector3(0, 0, 0f);
    private float timeRotation;
    public Collider2D colliderArrow;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? color1 : color2;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - this.timeRotation < cooldown) 
            {
                return;
            }
            this.timeRotation = Time.time;
            this.rotationRight.z += 90f;
            CheckIfObjectClickedRight();
            this.rotationRight.z = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Time.time - this.timeRotation < cooldown)
            {
                return;
            }
            this.timeRotation = Time.time;
            this.rotationLeft.z -= 90f;
            CheckIfObjectClickedLeft();
            this.rotationRight.z = 0;
        }

    }

    public class MouseClick : MonoBehaviour
    {
        public int vibration = 1;
        public float elasticity = 1f;

    }

    public void CheckIfObjectClickedRight()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);



        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace);

        if (col == colliderArrow)
        {
            
            Debug.Log("rotacion");
            col.gameObject.transform.DORotate(rotationRight, 0.5f, RotateMode.LocalAxisAdd);
        }

    }
    public void CheckIfObjectClickedLeft()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);



        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace);

        if (col == colliderArrow)
        {
            Debug.Log("rotacion");
            col.gameObject.transform.DORotate(rotationLeft, 0.5f, RotateMode.Fast);
        }

    }
}