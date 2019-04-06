using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    [Header("Am I debugging?")]
    public bool m_isDebugging = false;

	//Reference to the pop up screens
    [Header("Reference to popups")]
	public GameObject m_coffeeMachine;
	public GameObject m_sleepPod;
	public GameObject m_washroom;
	public GameObject m_personalEmails;

	public GameObject m_currentPopUp;

	//Ressources
    [Header("Reference to game manager")]
    public GameManager m_gameManager;

    //Player
    [Header("Reference to player")]
    public GameObject m_player;

    //modifier
    [Header("Coffee Effect")]
    public float m_coffeeBoost;
    public float m_coffeeCost;

    [Header("Sleep Effect")]
    public float m_sleepBoost;
    public float m_sleepCost;

    [Header("Washroom Effect")]
    public float m_washroomUse;
    public float m_washroomBoost;
    public float m_washroomCost;

    [Header("Personal Emails Effect")]
    public float m_personalEmailsBoost;
    public float m_personalEmailsCost;

    [Header("Timer in second")]
    public float m_timerInSeconds;

	//audio manager (call Ali's script )
	AudioManager m_audioManager;

    // Start is called before the first frame update
    void Start()
    {
    	//fetch the audio manager
        m_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        //set the timer to 0
        m_timerInSeconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //increment the timer over time
        m_timerInSeconds += Time.deltaTime;

        //DEBUGGING--------
        if(m_isDebugging)
            DebugPopUps();
    }

    //ACTIVATING THE POP UPS, CALL THESE FUNCTIONS TO TRIGGER THE POPUPS
    public void CoffeePopUp(){
    	m_coffeeMachine.SetActive(true);
    	m_currentPopUp = m_coffeeMachine;

        //deactivate player/controls
        m_player.SetActive(false);
    }

    public void SleepPodPopUp(){
    	m_sleepPod.SetActive(true);
    	m_currentPopUp = m_sleepPod;

        //deactivate player/controls
        m_player.SetActive(false);
    }

    public void WashroomPopUp(){
    	m_washroom.SetActive(true);
    	m_currentPopUp = m_washroom;

        //deactivate player/controls
        m_player.SetActive(false);
    }

    public void PersonalEmailsPopUp(){
    	m_personalEmails.SetActive(true);
    	m_currentPopUp = m_personalEmails;

        //deactivate player/controls
        m_player.SetActive(false);
    }

    //POP UP OPTIONS
    public void DrinkCoffee(){
        m_gameManager._energy += m_coffeeBoost;
        m_gameManager._credit -= m_coffeeCost;

        //close pop
        CancelPopUp();
    }

    public void UseWashroom(){
        m_timerInSeconds += m_washroomUse;

        //close pop
        CancelPopUp();
    }

    public void ContemplateLife(){
        m_timerInSeconds += m_washroomCost;
        m_gameManager._energy += m_washroomBoost;

        //close pop
        CancelPopUp();
    }

    public void Sleep(){
        m_timerInSeconds += m_sleepCost;
        m_gameManager._energy = 100.0f;

        //close pop
        CancelPopUp();
    }

    //CANCEL POP UP
    public void CancelPopUp(){
        m_currentPopUp.SetActive(false);
        m_currentPopUp = null;

        //re-activate player/controls
        m_player.SetActive(true);
    }

    //DEBUGGING-----------------------
    private void DebugPopUps(){
        if(Input.GetKey("space"))
            CoffeePopUp();
    }
}
