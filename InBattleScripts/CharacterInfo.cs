using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;

    private void Update()
    {
        activeTile.isBlocked = true;
    }
}
