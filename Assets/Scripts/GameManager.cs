using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameOverText;
    private GameObject player;
    public GameObject enemy;
    private Vector3[] spawnLocations = { new Vector3(10.0f, 0.0f, 0.0f), new Vector3(-10.0f, 0.0f, 0.0f), new Vector3(0.0f, 6.0f, 0.0f), new Vector3(0.0f, -6.0f, 0.0f) };
    public int score;
    public Sprite[] possibleShapes;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateScoreText();
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        int rndNum = UnityEngine.Random.Range(0, spawnLocations.Length);
        int rndShape = UnityEngine.Random.Range(0, possibleShapes.Length);
        quaternion rot = new quaternion(0, 0, 0, 0);
        Instantiate(enemy, spawnLocations[rndNum], rot);
        float rndSpeed = UnityEngine.Random.Range(2.0f, 8.0f);
        enemy.GetComponent<EnemyScript>().speed = rndSpeed;
        enemy.GetComponent<SpriteRenderer>().sprite = possibleShapes[rndShape];
    }

    public void UpdateHealthText()
    {
        healthText.text = $"Health: {player.GetComponent<PlayerScript>().health}";
    }

    public void UpdateScoreText()
    {
        scoretext.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>().health <= 0)
        {
            gameOverText.enabled = true;
            if(gameOverText.rectTransform.position.y > 750)
            {
                gameOverText.rectTransform.position -= new Vector3(0, 2.5f, 0);

            }
        }
    }
}
