using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoArrow : MonoBehaviour
{
    float rotationAngle = 0;

    private ProtoRotation rotationScript;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rotationAngle -= 90f;
            this.transform.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;

        }
    }
}
