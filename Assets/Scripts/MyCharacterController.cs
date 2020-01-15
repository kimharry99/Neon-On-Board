using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MyCharacterController : SingletonBehaviour<MyCharacterController>
{
    private Character character = null;
    [SerializeField]
    private Map map;

    void Update()
    {
        if(map.canGetTilePos)
        {
            //Debug.Log(map.tileWorldPos);
            //Debug.Log(character.transform.position);
            character.StartMoing(Vector3.Normalize(new Vector3(map.tileWorldPos.x, map.tileWorldPos.y + 0.6f) - character.transform.position), 
                new Vector3(map.tileWorldPos.x, map.tileWorldPos.y + 0.6f, character.transform.position.z));
            map.canGetTilePos = false;
            UnselectCharacter();
        }
    }
    private void UnselectCharacter()
    {
        if(character != null)
        {
            character.pointer.SetActive(false);
            character = null;
        }
    }
    public void ChooseCharacter(Character _character)
    {
        UnselectCharacter();
        character = _character;
        //Debug.Log(character.spd);
        character.pointer.SetActive(true);
    }

    public bool IsCharSelected()
    {
        if(character == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
