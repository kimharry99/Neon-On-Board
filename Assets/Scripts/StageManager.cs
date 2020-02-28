using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    private List<Character> characterList = new List<Character>();
    private Character selectedCharacter = null;
    [SerializeField]
    private Map map;

    void Update()
    {
        if(map.canGetTilePos)
        {
            //Debug.Log(map.tileWorldPos);
            //Debug.Log(character.transform.position);
            selectedCharacter.StartMoing(Vector3.Normalize(new Vector3(map.tileWorldPos.x, map.tileWorldPos.y + 0.6f) - selectedCharacter.transform.position), 
                new Vector3(map.tileWorldPos.x, map.tileWorldPos.y + 0.6f, selectedCharacter.transform.position.z));
            map.canGetTilePos = false;
            UnSelectCharacter();
        }
    }
    private void UnSelectCharacter()
    {
        if(selectedCharacter != null)
        {
            selectedCharacter.pointer.SetActive(false);
            selectedCharacter = null;
        }
    }
    public void SelectCharacter(Character _character)
    {
        UnSelectCharacter();
        selectedCharacter = _character;
        //Debug.Log(character.spd);
        selectedCharacter.pointer.SetActive(true);
    }

    public bool IsCharSelected()
    {
        if(selectedCharacter == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
