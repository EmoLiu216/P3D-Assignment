using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public int sorce;
    public Text m_text;
    List<string> rb = new List<string>();
    void Start()
    {
        
    }

    
    void Update()
    {
        m_text.text = "Score£º" + sorce;
        if(sorce==2)
        {
            m_text.text = "Challenge success!!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {  
        if (!rb.Contains(collision.transform.name))
        {
            rb.Add(collision.transform.name);
            sorce++;
        }
    }
}
