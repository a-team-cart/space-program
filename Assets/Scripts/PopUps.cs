using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

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
    public GameObject m_winning;
    public GameObject m_slacker;
    public GameObject m_burnout;

	public GameObject m_currentPopUp;

    [Header("Button References")]
    public GameObject m_coffeeButton;
    public GameObject m_sleepButton;
    public GameObject m_washroomButton;
    public GameObject m_emailButton;

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
    // public float m_personalEmailsBoost;
    public float m_personalEmailsCost;

    [Header("Timer in second")]
    public float m_timerInSeconds;

    //event system
    private GameObject m_es;

    //is the game done?
    private bool m_gameIsDone = false;

	//audio manager (call Ali's script )
	AudioManager m_audioManager;

    // Start is called before the first frame update
    void Start()
    {
    	//fetch the audio manager
        m_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        //set the timer to 0
        m_timerInSeconds = 0;
        //start with the cursor being invisbile
        Cursor.visible = false;

        // Get the event system
        m_es = GameObject.FindGameObjectWithTag("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //increment the timer over time
        m_timerInSeconds += Time.deltaTime;

        //winning or losing popups
        if(m_gameManager.m_orbitNum >= 30)
        {
            Congratulations();
        }
        if(m_gameManager._evaluation <= 0)
        {
            Slacker();
        }
        if(m_gameManager._energy <= 0)
        {
            BurnOut();
        }
        if(m_gameIsDone && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        //DEBUGGING--------
        if(m_isDebugging)
            DebugPopUps();
    }

    //WINNING/LOSING POP UPS
    public void Congratulations(){
        m_winning.SetActive(true);
        m_currentPopUp = m_winning;
        m_gameIsDone = true;
        //deactivate player/controls
        PlayerControls(false);
    }

    public void BurnOut(){
        m_burnout.SetActive(true);
        m_currentPopUp = m_burnout;
        m_gameIsDone = true;
        //deactivate player/controls
        PlayerControls(false);
    }

    public void Slacker(){
        m_slacker.SetActive(true);
        m_currentPopUp = m_slacker;
        m_gameIsDone = true;
        //deactivate player/controls
        PlayerControls(false);
    }

    //ACTIVATING THE POP UPS, CALL THESE FUNCTIONS TO TRIGGER THE POPUPS
    public void CoffeePopUp(){
    	m_coffeeMachine.SetActive(true);
    	m_currentPopUp = m_coffeeMachine;

        //deactivate player/controls
        PlayerControls(false);
        StartCoroutine(SelectButton(m_coffeeButton));
    }

    public void SleepPodPopUp(){
    	m_sleepPod.SetActive(true);
    	m_currentPopUp = m_sleepPod;

        //deactivate player/controls
        PlayerControls(false);
        StartCoroutine(SelectButton(m_sleepButton));
    }

    public void WashroomPopUp(){
    	m_washroom.SetActive(true);
    	m_currentPopUp = m_washroom;

        //deactivate player/controls
        PlayerControls(false);
        StartCoroutine(SelectButton(m_washroomButton));
    }

    public void PersonalEmailsPopUp(){
    	m_personalEmails.SetActive(true);
    	m_currentPopUp = m_personalEmails;

        //deactivate player/controls
        PlayerControls(false);
        StartCoroutine(SelectButton(m_emailButton));
    }

    //POP UP OPTIONS
    public void DrinkCoffee(){
        m_gameManager._energy += m_coffeeBoost;
        m_gameManager._credit -= m_coffeeCost;

        //audio
        m_audioManager.CoffeeDrank();

        //close pop
        CancelPopUp();
    }

    public void CheckEmail(){
        m_gameManager._energy -= m_personalEmailsCost;

        //audio
        m_audioManager.CheckEmail();

        //close pop
        CancelPopUp();
    }

    public void UseWashroom(){
        m_timerInSeconds += m_washroomUse;

        //audio
        m_audioManager.BathroomTime();

        //close pop
        CancelPopUp();
    }

    public void ContemplateLife(){
        m_timerInSeconds += m_washroomCost;
        m_gameManager._energy += m_washroomBoost;

        //audio
        m_audioManager.ThinkingHard();

        //close pop
        CancelPopUp();
    }

    public void Sleep(){
        m_timerInSeconds += m_sleepCost;
        m_gameManager._energy = 100.0f;

        //audio
        m_audioManager.SleepTime();

        //close pop
        CancelPopUp();
    }

    //DEACTIVATE PLAYER CONTROLS
    private void PlayerControls(bool activate){
        if(!activate){
            m_player.GetComponent<FirstPersonController>().m_isMoving = false;
            Cursor.visible = false;
        } else{
            m_player.GetComponent<FirstPersonController>().m_isMoving = true;
            Cursor.visible = false;
        }
    }

    //CANCEL POP UP
    public void CancelPopUp(){
        m_currentPopUp.SetActive(false);
        m_currentPopUp = null;

        //Call audio feedback
        m_audioManager.CancelPopUp();

        //re-activate player/controls
        m_player.GetComponent<FirstPersonController>().m_isMoving = true;
        Cursor.visible = false;
    }

    private IEnumerator SelectButton(GameObject firstButton)
    {
        // Wait a frame before selecting the button (so it can be highlighted)
        yield return null;
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(null);
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(firstButton);
    }

    //DEBUGGING-----------------------
    private void DebugPopUps(){
        if(Input.GetKey("c"))
            CoffeePopUp();
        if(Input.GetKey("v"))
            SleepPodPopUp();
        if(Input.GetKey("b"))
            WashroomPopUp();
        if(Input.GetKey("n"))
            PersonalEmailsPopUp();
    }
}
