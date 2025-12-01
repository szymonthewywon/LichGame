using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTilemap : MonoBehaviour
{
    public Tilemap tilemap;

    public static WallTilemap instance;

    void Awake()
    {
        instance = this;
    }
}
