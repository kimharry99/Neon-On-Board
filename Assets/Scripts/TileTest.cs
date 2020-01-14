using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//http://blog.daum.net/_blog/BlogTypeView.do?blogid=09dc4&articleno=18283286&categoryId=861132&regdt=20181018083030
public class TileTest : MonoBehaviour
{
    public Tilemap tilemap;

    //마우스가 타일 위에 위치할 때만 작업할 것이기 때문에 onMouseOver를 사용했습니다.

    //가능하면 기즈모로 하는것도 좋을것 같네요.

    void OnMouseOver()
    {
        try
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);
            //Debug.Log(ray.direction);
            //Debug.Log(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);

            if (tilemap = hit.transform.GetComponent<Tilemap>())
            {
                tilemap.RefreshAllTiles();

                int x, y;
                x = tilemap.WorldToCell(ray.origin).x;
                y = tilemap.WorldToCell(ray.origin).y;

                Vector3Int v3Int = new Vector3Int(x, y, 0);

                //Debug.Log(v3Int);

                //타일 색 바꿀 때 이게 있어야 하더군요
                tilemap.SetTileFlags(v3Int, TileFlags.None);

                //타일 색 바꾸기
                tilemap.SetColor(v3Int, (new Color(0.1f, 0, 0)));
            }
        }
        catch (NullReferenceException)
        {

        }
    }
    void OnMouseExit()
    {
        this.tilemap.RefreshAllTiles();
    }
}