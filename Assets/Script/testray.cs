using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    float timer_f = 0f;
    int timer_i = 0;
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo))
        {
            
            Debug.DrawLine(ray.origin, hitInfo.point);
            GameObject gameObj = hitInfo.collider.gameObject;
            Debug.Log("碰到了" + gameObj.name);
            if (gameObj.tag == "UI3D")
            {               
                timer_f += Time.deltaTime;
                timer_i = (int)timer_f;
                if (timer_i >= 3)
                {
                    gameObj.GetComponent<ui3devent>().setEvent();
                    
                    timer_f = 0f;
                    timer_i = 0;
                }              
            }
            else
            {
                timer_f = 0f;
                timer_i = 0;
            }
        }
        
    }
}
