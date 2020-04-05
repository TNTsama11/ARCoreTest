using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cricles : MonoBehaviour {
    public float speed;
    public GameObject cricle;
    public float targetv;
    float crentv=0;
    float t = 0;
    public float mMoveTime;
    public bool swich = false;
    // Use this for initialization
    void Start () {
        targetv = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (swich == true)
        {
           
            if (crentv < targetv)
            {
                t += 1f / mMoveTime * Time.deltaTime;
                crentv = Mathf.Lerp(0f, targetv, t);
                cricle.GetComponent<Image>().fillAmount = crentv;
            }
            else
            {
                cricle.GetComponent<Image>().fillAmount = targetv;
                 

            }
        }
        else
        {
            cricle.GetComponent<Image>().fillAmount = 0f;
            crentv = 0;
            t = 0;
        }
    }

}
