using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnClick : MonoBehaviour {

    void OnMouseDown()
    {
        SceneController.ChangeScene("Level1");
    }
}
