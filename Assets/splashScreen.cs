using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    // public variables -------------------------
    public VideoPlayer m_video;                     // Instance of the video player
    public GameObject m_blackScreen;                // Black screen before video
    public int m_sceneIndex;                        // What scene to load after the splash screen

    // private variables ------------------------
    private float m_counter = 0.0f;                 // Splash screen counter
    private bool m_played = false;                  // Is the video playing
    

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Count time
        m_counter += Time.deltaTime;

        // Scenario of the time scene based on the counter
        if (m_counter >= 1f && !m_played)
        {
            m_video.Play();
            m_played = true;
        }

        if (m_counter >= 1.1f)
            m_blackScreen.SetActive(false);
    	
        if (m_counter >= 11f)
            SceneManager.LoadScene(m_sceneIndex);
    }
}
