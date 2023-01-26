using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Color[] colourChoices = { Color.magenta, Color.red, Color.cyan, Color.yellow };
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyColour();
    }

    void SetEnemyColour()
    {
        int rndNum = Random.Range(0, 3);
        this.GetComponent<SpriteRenderer>().color = colourChoices[rndNum];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (transform.position.x > 0.0f)
            dir = Vector3.left;
        else if (transform.position.x < 0.0f)
            dir = Vector3.right;
        else if (transform.position.y > 0.0f)
            dir = Vector3.down;
        else if (transform.position.y < 0.0f)
            dir = Vector3.up;
        this.transform.Translate(dir * Time.deltaTime * speed);
    }
}
