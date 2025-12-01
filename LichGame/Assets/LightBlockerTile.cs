using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class LightBlockerTile : MonoBehaviour
{
    public SpriteRenderer renderer;
    void Start()
    {
        Vector3Int tilePosition = new Vector3Int(Mathf.FloorToInt(transform.position.x-0.5f), Mathf.FloorToInt(transform.position.y-0.5f), 0);
        //transform.position = tilePosition;

        Sprite s = WallTilemap.instance.tilemap.GetSprite(tilePosition);
        renderer.sprite = s;
    }

}
