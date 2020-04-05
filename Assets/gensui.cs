using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gensui : MonoBehaviour {

    float m_speed = 2f;
    Transform m_Root;
    Transform m_Target;
    Vector3 m_vec3Offset;

    public GameObject m_Cam;

    public GameObject m_Menu;
    // Use this for initialization
    void Start () {
        m_Root = m_Menu.transform;
        m_Target = m_Cam.transform;
        m_vec3Offset = m_Root.position - m_Target.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Target == null)
        {
            return;
        }
        else
        {
            m_Root.position = Vector3.Lerp(m_Root.position, m_Target.position + m_vec3Offset, m_speed * Time.deltaTime);
        }
	}
}
