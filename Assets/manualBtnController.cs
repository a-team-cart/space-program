using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manualBtnController : MonoBehaviour
{
    // public variables -------------------------
    public employeeManualController m_manualManager;    // Object holding the manual controller
    public bool m_direction;                            // Direction of the btn (true for next, false for previous)


    // private variables ------------------------


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        
    }


    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        
    }


    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // If the button got pressed -------------------------------------
    public void GotPressed()
    {
        // Change page if pressed
        m_manualManager.ChangePage(m_direction);
    }

    // If the button got overed --------------------------------------
    public void IsOver()
    {
        
    }
}
