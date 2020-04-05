using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui3devent : MonoBehaviour {
   public bool Event = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Event == true)
        {
            Debug.Log("3秒Down");
        }
		
	}
    public void setEvent()
    {
        Event = true;
    }
    public void endEvent()
    {
        Event = false;
    }
}
