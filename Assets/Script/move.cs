using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    // Use this for initialization
    private Animator anim;
    
    
    float speed = 1f;
    float time=3f;
    bool idle = true;
    bool walk = false;
    Vector3 oldtrans;
    void Start () {
        anim = GetComponent<Animator>();
        oldtrans = this.transform.position;


    }

	
	// Update is called once per frame
	void Update () {
        
        time -= Time.deltaTime;
        
        if (time <= 0)
        {
            if (idle==true)
            {                
                time = Random.Range(1, 10);
                int angl = Random.Range(-90, 90);

               
                    transform.Rotate(new Vector3(0, angl, 0));
               
                
                idle = false;
                walk = true;
            }
            else
            {
                time = Random.Range(1, 10);
                idle = true;
                anim.CrossFade("WAIT00", 0.5f);
            }
        }
        if (idle==false)
        {
            if (walk == true)
            {
                anim.CrossFade("WALK00_F", 0.1f);
                walk = false;
            }
            if (Mathf.Abs(transform.position.x)-oldtrans.x>=5 || Mathf.Abs(transform.position.z) - oldtrans.z >= 5)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                print("0.0");
            }
            transform.Translate(Vector3.forward * Time.deltaTime*speed);
            
        }

    }
    
}
