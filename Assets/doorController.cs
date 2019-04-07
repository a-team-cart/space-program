using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    // public variables -------------------------
    public bool m_openDoor;                                                 // Open the door animation

    // private variables ------------------------
    private Vector3 m_finalDestination = new Vector3(0f, 2.13f, 0f);       // Where the door should go
    private float m_speed = 5f;                                            // Animation speed
    private Vector3 m_initial;                                             // Initial pos

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        m_initial = transform.position;
     	   
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
        }
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
}
