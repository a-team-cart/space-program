using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    // public variables -------------------------
    public bool m_openDoor;                                  // Open the door animation

    // private variables ------------------------
    private Vector3 m_finalDestination ;                     // Where the door should go
    private float m_speed = 0.5f;                              // Animation speed
    private Vector3 m_initial;                               // Initial pos

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the initial pos
        m_initial = transform.position;
     	
        // Get the final destination
        m_finalDestination = new Vector3(m_initial.x, 4.636f, m_initial.z);
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        if (m_openDoor)
        {
            // Catch the pos
            Vector3 currentPos = transform.position;
            // Lerp it
            currentPos = Vector3.Lerp( transform.position, m_finalDestination, m_speed * Time.deltaTime);

            // Update it
            transform.position = currentPos;

            // Check if the door arrived at destination
            if (currentPos.y > m_finalDestination.y - 0.1f)
                m_openDoor = false;
        }
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Open the door when it's called --------------------------------
    public void Open()
    {
        m_openDoor = true;
    }
}
