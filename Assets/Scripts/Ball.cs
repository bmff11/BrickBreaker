using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Vector2 startingVelocity = new Vector2(15, -20);
    private Vector3 startingPosition;
    public GameObject gameover;
    public GameObject youwin;
    public Text livesValue;
    public Text pointsValue;

    int lives = 3;
    int points = 0;

    void Start() {
        livesValue.text = lives.ToString();
        startingPosition = transform.position;
        GetComponent<Rigidbody2D>().velocity = startingVelocity;
    }



    void Update() {
        if (transform.position.y < -7.6) {
            GetOut();
        }
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = startingVelocity;
        }
    }
    void GetOut() {
        Debug.Log("You are out");
        lives = lives - 1;
        livesValue.text = lives.ToString();

        transform.position = startingPosition;
        GetComponent<Rigidbody2D>().velocity = new Vector2();

        if (lives == 0) {
            GameOver();
        }
    }

    void GameOver() {
        gameover.SetActive(true);
    }

    public void YouBrokeABrick() {
        points += 1;
        pointsValue.text = points.ToString();
        var bricksleft = FindObjectsOfType<Brick>().Length;
        if(bricksleft == 0) {
            youwin.SetActive(true);
        }
    }
}