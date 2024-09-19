using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    private GameOver GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        // find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        // get the ScoreCounter (Script) component of scoreGo
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();

        // find gameOver instance
        GameOverText = FindObjectOfType<GameOver>();
        Debug.Log("GameOver instance: " + GameOverText);
    }

    // Update is called once per frame
    void Update()
    {
        // get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        // convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
        // find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            // increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        //bad apple
        if (collidedWith.CompareTag("BadApple")) {
            Destroy(collidedWith);
           
            // game over
            if (GameOverText != null) {
                GameOverText.TriggerGameOver();
            } else {
                Debug.LogError("GameOver instance is null!");
            }
        }
    }
}
