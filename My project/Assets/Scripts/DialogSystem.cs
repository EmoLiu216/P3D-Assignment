using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject b1;
    public GameObject b2;
    public int currentIndex=0;

  

    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
       
        c1.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);     
    }
    void Update()
    {
        
    }
    public void CloseDialog() {
       
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        b1.SetActive(false);
        b2.SetActive(false);
        Time.timeScale = 1;

    }

    public void ContinueDialog()
    {
        currentIndex++;
        if (currentIndex == 1) {
            c1.SetActive(false);
            c2.SetActive(true);
            c3.SetActive(false);
        }
        else if (currentIndex == 2)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
            
        }
        else if(currentIndex>2)
        {
            CloseDialog();
        }
    }
}

