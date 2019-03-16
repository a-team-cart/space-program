using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Are you debugging?")]
    public bool _iAmDebugging = false;

    [Header("Global Ressources")]
    public float _evaluation = 100f;
    public float _energy = 100f;
    public float _credit = 100f;

    [Header("Ressource Modifiers")]
    public float _defaultModifierValue = 0.5f;
    public float _evaluationModifier;
    public float _energyModifier;
    public float _creditModifier;

    [Header("Global Ressources References")]
    public Text _evaluationRef;
    public Text _energyRef;
    public Text _creditRef;
    public Text _isWorkingRef;
    public Text _isSpendingRef;
    public Text _isRestingRef;
    public Text _gameStatusRef;

    [Header("Global Ressources Booleans")]
    //boolean condition for when to increment
    public bool _isWorking = false;
    public bool _isResting = false;
    public bool _isSpending = false;

    [Header("Game Status")]
    public string _gameStatus = "not determined yet";

    [Header("Task Properties")]
    //Ali's Code
    public int m_tasksCompleted;
    public List<string> completedTasks;


    // Start is called before the first frame update
    void Start()
    {
        //init function to initialize values
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //Display the status of all the variable on terminal
        DisplayStatus();

        //ressource behaviour
        RessourceBehaviour();

        //winning or losing conditions
        YourAFailure();
        YouBurntOutCuzYouSuck();
        YourStillAFailureButYouDidAnOKJob();
      
        //debug COMMENT OUT WHEN OUTSIDE OF DEBUG MODE
        if(_iAmDebugging)
            debugBehaviour();
    }

    // -------------------------------------
    // Function that links Evaluation/Energy/Credit to the terminals
    // LINK ALL YOUR TERMINAL REFERENCES HERE!!!!
    // REPLACE TERMINAL UI WITH UR OWN REFERENCES TO THE TERMINAL
    // -------------------------------------

    public void DisplayStatus(){

        //EVAL/ENERGY/CREDIT VALUES
        // _evaluationRef.text = TERMINAL UI;
        // _energyRef.text =  TERMINAL UI;
        // _creditRef.text = TERMINAL UI;

        //THE BOOLEANS
        // _isWorkingRef.text = TERMINAL UI;
        // _isRestingRef.text = TERMINAL UI;
        // _isSpendingRef.text = TERMINAL UI;

        //GAME STATUS
        // _gameStatusRef.text = TERMINAL UI;
    }


    // -------------------------------------
    // Debug function to test out timers in timer scene //COMMENT OUT WHEN NOT DEBUGGING!!!!!
    // -------------------------------------

    public void debugBehaviour(){
        //input debug
        if(Input.GetKey("space")){
            _isWorking = true;
        }
        else{
            _isWorking = false;
        }

        if(Input.GetKey("e")){
            _isResting = true;
        }
        else{
            _isResting = false;
        }

        if(Input.GetKey("c")){
            _isSpending = true;
        }
        else{
            _isSpending = false;
        }
        //debug modifier boosts
        if(Input.GetKeyDown("m"))
            StartCoroutine(ApplyEvalModifierForThisAmountOfTime(10.0f,10.0f));
        if(Input.GetKeyDown("n"))
            StartCoroutine(ApplyEnergyModifierForThisAmountOfTime(10.0f,10.0f));

        //display the value on screen
        _evaluationRef.text = _evaluation.ToString();
        _energyRef.text = _energy.ToString();
        _creditRef.text = _credit.ToString();
        _isWorkingRef.text = _isWorking.ToString();
        _isRestingRef.text = _isResting.ToString();
        _isSpendingRef.text = _isSpending.ToString();
        _gameStatusRef.text = _gameStatus;


    }

    //initializing function
    public void init(){
        //initialize modifier with the default value
        _evaluationModifier = _defaultModifierValue;
        _energyModifier = _defaultModifierValue;
        _creditModifier = _defaultModifierValue;
    }

    // -------------------------------------
    // How Evaluation/Energy/Credit will behave based on a set of booleans
    //--------------------------------------

    public void RessourceBehaviour(){

        //if your working, increase eval
        if(_isWorking){
            _evaluation += Time.deltaTime * _evaluationModifier;
            _energy -= Time.deltaTime * _energyModifier;
        } else{
            _evaluation -= Time.deltaTime * _evaluationModifier; // if ur not working, then decrease it anyways
        }

        //if ur working, increase energy but decrease eval
        if(_isResting){
            _energy += Time.deltaTime * _energyModifier;
            _evaluation -= Time.deltaTime * _evaluationModifier;
        }

        //if ur spending, decrease credit
        if(_isSpending){
            _credit -= Time.deltaTime * _creditModifier;
        }

        //------------------------------
    }

    // -------------------------------------
    // Change modifier momentarily
    // -------------------------------------

    public IEnumerator ApplyEvalModifierForThisAmountOfTime(float appliedTime, float increaseAmount){
        //increase the modifier by said amount
        _evaluationModifier += increaseAmount;
        yield return new WaitForSeconds(appliedTime);
        //reset the modifier to original value after the time has run out
        _evaluationModifier -= increaseAmount;
    }

    public IEnumerator ApplyEnergyModifierForThisAmountOfTime(float appliedTime, float increaseAmount){
        //increase the modifier by said amount
        _energyModifier += increaseAmount;
        yield return new WaitForSeconds(appliedTime);
        //reset the modifier to original value after the time has run out
        _energyModifier -= increaseAmount;
    }

    // -------------------------------------
    // Score & Task Methods //OLD SCRIPT , TO BE CHANGED!!!
    // -------------------------------------
    public void TaskCompleted(string taskCompleted)
    {
        m_tasksCompleted++;
        completedTasks.Add(taskCompleted);
    }
    
    public void CompileTasksCompleted()
    {
        //Print out completed tasks in a list for the report

    }

    // -------------------------------------
    // Losing and Winning Condition Methods
    // -------------------------------------
    public void YourAFailure(){
        if(_evaluation < 0)
            _gameStatus = "You failed the company";
            // Debug.Log("You failed the company");
    }

    public void YouBurntOutCuzYouSuck(){
        if(_energy < 0)
            _gameStatus = "You Burnt out bro";
            // Debug.Log("You Burnt out bro");
    }

    public void YourStillAFailureButYouDidAnOKJob(){
        if(_evaluation > 500)
            _gameStatus = "Go work at McDonald, It pays better";
            // Debug.Log("Go work at McDonald, It pays better");
    }

    // -------------------------------------
    // Application Methods
    // -------------------------------------
    //Quit the application
    private void Quit()
    {
        Application.Quit();
    }

    //Restart application
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
