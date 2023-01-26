using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Color playerColour;
    private Color newColour;
    public int health;
    private GameObject GameController;
    public Sprite[] possibleShapes;
    // Start is called before the first frame update
    void Start()
    {
        newColour = Color.magenta;
        playerColour = this.GetComponent<SpriteRenderer>().color;
        health = 5;
        GameController = GameObject.FindGameObjectWithTag("GameController");
        GameController.GetComponent<GameManager>().UpdateHealthText();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Color enemycolour = col.gameObject.GetComponent<SpriteRenderer>().color;
            Sprite enemySprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
            Sprite playerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            if(enemycolour == playerColour || enemySprite == playerSprite)
            {
                int score;
                if (enemycolour == playerColour && enemySprite == playerSprite)
                    score = 50;
                else
                    score = 10;
                GameController.GetComponent<GameManager>().score += score;
                GameController.GetComponent<GameManager>().UpdateScoreText();
            }
            else
            {
                health--;
                GameController.GetComponent<GameManager>().UpdateHealthText();
            }

            Destroy(col.gameObject, 0.25f);
            if (health > 0)
                GameController.GetComponent<GameManager>().SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            switch (Input.inputString.ToLower())
            {
                case "w":
                    newColour = Color.red;
                    break;
                case "a":
                    newColour = Color.magenta;
                    break;
                case "s":
                    newColour = Color.cyan;
                    break;
                case "d":
                    newColour = Color.yellow;
                    break;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<SpriteRenderer>().sprite = possibleShapes[0];
            }else if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<SpriteRenderer>().sprite = possibleShapes[1];
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().sprite = possibleShapes[2];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<SpriteRenderer>().sprite = possibleShapes[3];
            }

            if(newColour != playerColour){
                this.GetComponent<SpriteRenderer>().color = newColour;
                playerColour = newColour;
            }
        }
    }
}
