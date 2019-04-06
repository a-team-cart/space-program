using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSpawner : MonoBehaviour
{
    // public variables -------------------------
    public GameObject m_star;                       // The star to be initiated

    // private variables ------------------------
    private float m_counter = 0.0f;                 // Counter for spawner
    private float m_spawningInterval;               // Time before another star is spawn
    private float m_minTime = 2f;                   // Min time in sec before another spawn                    
    private float m_maxTime = 7f;                   // Max time in sec before another spawn 

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Select the interval first
        SelectInterval();
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always SpawStars
        SpawStars();	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Spaw a star after some time ------------------------------------------
    private void SpawStars()
    {
        // Start the counter
        m_counter += Time.deltaTime;

        // Check when the interval is crossed
        if (m_counter >= m_spawningInterval)
        {
            // Spaw a star and select a speed
            GameObject alpha = Instantiate(m_star, transform.position, transform.rotation);
            alpha.GetComponent<movingStarController>().PickSpeed();
            alpha.transform.parent = gameObject.transform;

            // Find a new interval
            SelectInterval();

            // Reset Timer
            m_counter = 0f;
        }


    }


    // Select time to be the interval ----------------------------------------
    private void SelectInterval()
    {
        // Select an interval in the max-min range
        m_spawningInterval = Random.Range(m_minTime, m_maxTime);
    }
}
