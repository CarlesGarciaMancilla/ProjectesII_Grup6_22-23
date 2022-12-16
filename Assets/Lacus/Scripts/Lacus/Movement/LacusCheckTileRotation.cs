using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusCheckTileRotation : MonoBehaviour
{

    [SerializeField] private LacusMovement LacusM;
    [SerializeField] private LacusStats LacusS;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Arrow"))
        {
            LacusM.Rotate(collider.transform.rotation);
            LacusS.batteryLeft--;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Wait?");
        LacusM.ToDestinationMovement();
    }
}
