using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private float spd;
    void Start()
    {
        camera = this.transform.GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        //왼쪽
        if (Input.mousePosition.x < 10)
        {
            camera.transform.position = new Vector3(camera.transform.position.x - spd * Time.deltaTime, camera.transform.position.y, camera.transform.position.z);
        }
        //오른쪽
        if (Input.mousePosition.x > Screen.width - 10)
        {
            camera.transform.position = new Vector3(camera.transform.position.x + spd * Time.deltaTime, camera.transform.position.y, camera.transform.position.z);
        }
        //위족
        if (Input.mousePosition.y > Screen.height - 10)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + spd * Time.deltaTime, camera.transform.position.z);
        }
        //아래쪽
        if (Input.mousePosition.y < 10)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - spd * Time.deltaTime, camera.transform.position.z);
        }
    }
}
