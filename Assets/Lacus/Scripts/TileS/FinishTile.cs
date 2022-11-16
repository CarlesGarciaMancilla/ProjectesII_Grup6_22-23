using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTile : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public SpriteRenderer spriteRenderer;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? color1 : color2;
    }
}

