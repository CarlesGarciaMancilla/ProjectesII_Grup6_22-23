using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticlesClick : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem clickParticles;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);
        
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = mousePosWorldSpace;
            clickParticles.Play();
        }

    }
}
