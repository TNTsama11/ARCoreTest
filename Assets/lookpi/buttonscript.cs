using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class buttonscript : MonoBehaviour {
    
    bool flag = true;

    void hide()//隐藏
    {
        transform.localScale = Vector3.zero;
    }
   
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Button myButton = gameObject.GetComponent<Button>();
        if (myButton.interactable == true)
        {
            myButton.interactable = false;
            if (flag==true)
            {
                transform.DOMove(new Vector3(3, this.transform.position.y, this.transform.position.z), 0.6f).SetEase(Ease.OutBack).OnComplete(hide);
                flag = false;
            }
        }
	}
}
