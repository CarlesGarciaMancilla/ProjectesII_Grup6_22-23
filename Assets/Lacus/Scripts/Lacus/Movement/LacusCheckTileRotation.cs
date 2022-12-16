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
            LacusS.batteryLeft--;
            StartCoroutine(WaitToForward(collider));

        }
    }

    IEnumerator WaitToForward(Collider2D collider)
    {
        // Ha d'estar aixi, si no no rota perfectament
        yield return new WaitForSeconds(0.35f);
        if (collider.transform.rotation != transform.rotation)
        {
            LacusM.Rotate(collider.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }
        // Ficar Audio Aqui
        // No treure, si no es torna voig
        
        LacusM.ResetDestinationPosition();
        yield return new WaitForSeconds(0.3f);
        LacusM.ToDestinationMovement();
    }
}
