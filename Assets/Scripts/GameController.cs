using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreTextLeft;
    public Text scoreTextRight;

    public Starter starter;

    public GameObject ball;

    private int scoreLeft;
    private int scoreRight;

    private Vector3 startingPosition;

    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        //startingPosition = ball.transform.position;
        //ballController = ball.GetComponent<BallController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        
    }

    public void ScoreGoalLeft() {
        scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight() {
        scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }


    private void UpdateUI() {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
    
    
    private void ResetBall() {
        this.ball.transform.position = this.startingPosition;
    }
    

}
