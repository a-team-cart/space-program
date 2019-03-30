using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryController : MonoBehaviour
{
    // public variables -------------------------
    public int m_channelOneErrors;                  // Index that keeps the number of errors in channel 1
    public int m_channelTwoErrors;                  // Index that keeps the number of errors in channel 2

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

    // Add or delete an error in a channel -----------------------------
    public void ErrorCount(int channelIndex, bool direction)
    {
        // Check first in which channel the error should be solve
        if (channelIndex == 1)
        {
            // Look at the direction (add or delete)
            if (direction)
                m_channelOneErrors ++;
            else 
                m_channelOneErrors --;
        }

        if (channelIndex == 2)
        {
            // Look at the direction (add or delete)
            if (direction)
                m_channelTwoErrors ++;
            else 
                m_channelTwoErrors --;
        }
    }
}
