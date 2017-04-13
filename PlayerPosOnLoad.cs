using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosOnLoad : MonoBehaviour {

    public void PosOnLoad(float posx, float posy, float posz)
    {
        transform.position = new Vector3(posx, posy, posz);
    }
}
