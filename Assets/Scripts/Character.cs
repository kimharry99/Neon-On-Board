using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 direion, des;
    [SerializeField]
    private int _id;
    public int Id
    {
        get { return _id; }
    }
    public float spd;
    public GameObject pointer;

    protected bool moving = false;

    void Start()
    {
        direion = Vector3.zero;
        des = transform.position;
    }
    void Update()
    {
        if (moving)
        {
            Move(direion, des);
        }
    }
    //Update안에서 항상 실행
    //direction은 단위벡터
    private void Move(Vector3 direction, Vector3 des)
    {
        //Debug.Log(Vector3.Distance(des, transform.position));
        if (Vector3.Distance(des, transform.position) < 0.1f)
        {
            transform.position = new Vector3(des.x, des.y, des.z);
            moving = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x + direction.x * spd * Time.deltaTime, transform.position.y + direction.y * spd * Time.deltaTime, transform.position.z);
        }
    }

    public void StartMoing(Vector3 _diretion, Vector3 _des)
    {
        direion = _diretion;
        des =  _des;
        moving = true;
    }

    void OnMouseDown()
    {
        GameManager.inst.stageManager.SelectCharacter(this.transform.GetComponent<Character>());
    }
}
