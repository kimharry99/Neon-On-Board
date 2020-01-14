using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;
    public bool canGetTilePos = false;
    public Vector3 tileWorldPos;

    void Start()
    {
        tilemap = this.transform.GetComponent<Tilemap>();
    }

    #region mouse function
    void OnMouseOver()
    {
        if(MyCharacterController.inst.IsCharSelected())
        {
            tilemap.RefreshAllTiles();
            int x, y;
            x = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x;
            y = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y;

            Vector3Int v3Int = new Vector3Int(x, y, 0);

            //Debug.Log(v3Int);

            //타일 색 바꿀 때 이게 있어야 하더군요
            tilemap.SetTileFlags(v3Int, TileFlags.None);

            //타일 색 바꾸기
            tilemap.SetColor(v3Int, (new Color(0.1f, 0, 0)));
        }
    }

    void OnMouseExit()
    {
        tilemap.RefreshAllTiles();
    }

    private Vector3Int downTile;
    private bool toCheckUp = false;
    void OnMouseDown()
    {
        if (MyCharacterController.inst.IsCharSelected())
        {
            int x, y;
            x = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x;
            y = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y;

            downTile = new Vector3Int(x, y, 0);
            toCheckUp = true;
        }
    }

    void OnMouseUp()
    {
        if (toCheckUp)
        {
            int x, y;
            x = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x;
            y = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y;

            Vector3Int upTile = new Vector3Int(x, y, 0);
            if (upTile == downTile)
            {
                tileWorldPos = tilemap.CellToWorld(downTile);
                canGetTilePos = true;
            }
        }
        toCheckUp = false;
    }
    #endregion
}
