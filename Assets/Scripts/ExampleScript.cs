using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    Vector3 MousePosition;
    void Start()
    {
        //camera = GetComponent<Camera>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 15f);
            if(hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
