using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour {
    public float rotateSpeed = 50f;
    public GameObject WinPanel;
    void Start()
    {

    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));

#if UNITY_EDITOR
        Vector3 rotate = transform.rotation.eulerAngles; //獲得遊戲物件當前的旋轉值
        //Debug.Log("rotate is" + rotate);
#endif
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(WinPanel!=null)
            WinPanel.SetActive(true);
            Destroy(other.gameObject);
            //Debug.Log("Win");
        }
    }

}
