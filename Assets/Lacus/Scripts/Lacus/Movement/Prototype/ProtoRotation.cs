using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoRotation : MonoBehaviour
{
    [SerializeField] private LacusMovement LacusM;
    [SerializeField] private Transform destination;
    [SerializeField] private Transform Lacus;

    private float rotationAngle = 0;


    public void ClickRotation(Transform _gameObject, Collider2D objectCollider, LayerMask objectLayer, AudioSource objectAudio)
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace, objectLayer);

        if (col == objectCollider)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
            {
                rotationAngle += 90f;
                objectAudio.Play();
            }
            else if (Input.GetMouseButtonDown(1) && Time.timeScale != 0f)
            {
                rotationAngle -= 90f;
                objectAudio.Play();
            }
            _gameObject.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;
        }
    }

    public IEnumerator LacusOnTileRotation(Collider2D collider)
    {
        // Ha d'estar aixi, si no no rota perfectament
        yield return new WaitForSeconds(0.35f);
        if (collider.transform.rotation != Lacus.transform.rotation)
        {
            destination.localPosition = new Vector3(0, 0, 0);
            RotateLacus(collider.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }

        // No treure, si no es torna voig
        LacusM.ResetDestinationPosition();
        yield return new WaitForSeconds(0.3f);

    }

    // Funci� que rota en Lacus donat una rotaci� amb un valor Z
    public void RotateLacus(Quaternion rotation)
    {
        Lacus.transform.DORotateQuaternion(rotation, 0.3f);
    }

    public void RotateSprite(Transform objectTarget, Quaternion rotation)
    {
        objectTarget.transform.DORotateQuaternion(rotation, 0.3f);
    }
}
