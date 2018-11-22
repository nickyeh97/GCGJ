using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour {

    public bool isAttraction;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isAttraction = true;        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttraction = false;
    }
}
