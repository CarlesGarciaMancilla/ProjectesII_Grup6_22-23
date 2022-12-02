using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusCheckTileRotation : MonoBehaviour
{

    public LacusMovement LacusM;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Arrow"))
        {
            LacusM.Rotate(collider.transform.rotation);

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
