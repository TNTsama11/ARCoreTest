using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ray2test : MonoBehaviour {
    float t;
    public float myRuntime;
    public GameObject lookpoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);//从相机位置发射射线
        RaycastHit  hitInfo;//定义一个变量存储碰撞信息
        if(Physics.Raycast(ray,out hitInfo))//判断射线碰到物体
        {
            Debug.DrawRay(ray.origin, hitInfo.point,Color.green);
            GameObject gameobj = hitInfo.collider.gameObject;//存贮碰到的物体
            Debug.Log("name is" + gameobj.name);
            if (gameobj.tag == "UIComp")
            {
                lookpoint.GetComponent<cricles>().swich = true;//调用圆环上的脚本，将其中swich设为真
                if (t < myRuntime)
                { 
                    t += Time.deltaTime;//开始计时
                    
                }
                else
                {
                    
                    gameobj.GetComponent<Button>().interactable = true;
                   
                    
                }
            }
            else
            {
                lookpoint.GetComponent<cricles>().swich = false;
                t = 0;
            }
        }
        else
        {
            lookpoint.GetComponent<cricles>().swich = false;
            t = 0;
        }
       

	}
}
