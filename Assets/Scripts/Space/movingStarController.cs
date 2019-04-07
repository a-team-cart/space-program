using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingStarController : MonoBehaviour
{
    // public variables -------------------------
    

    // private variables ------------------------
    private float m_speed = 5f;                     // Speed of the star
    private float m_minSpeed = 5f;                  // Minimum speed of the star
    private float m_maxSpeed = 10f;                 // Maximum speed of the star

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always move a star
        Vector3 currentPos = transform.position;
        currentPos.z -= Time.deltaTime * m_speed;

        // Update new position
        transform.position = currentPos;
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    
    // Chose a cruising speed ------------------------------------------
    public void PickSpeed()
    {
        // Pick a random number within the speed min/max interval
        m_speed = Random.Range(m_minSpeed, m_maxSpeed);
    }
}
