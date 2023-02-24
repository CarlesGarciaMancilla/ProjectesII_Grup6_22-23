using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ProtoRotation : MonoBehaviour
{
    private float rotationAngle = 0;


    public void ClickRotation(Transform _gameObject, Collider2D objectCollider, LayerMask objectLayer, AudioSource objectAudio)
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace, objectLayer);

        if (col == objectCollider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rotationAngle += 90f;
                objectAudio.Play();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                rotationAngle -= 90f;
                objectAudio.Play();
            }
            _gameObject.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;
        }
    }
    public void SpriteRotation()
    {

    }
}
