using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardWaves;
    public float startWavesDelay;
    public float waveDelay;
    public float spawnDelay;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    public int score;

    private bool gameOver;

    void Start()
    {
        score = 0;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateText();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (gameOver)
        {
            gameOverText.text = "Game Over";
            restartText.text = "Press 'R' to restart.";
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWavesDelay);
        while(true)
        {
            yield return new WaitForSeconds(waveDelay);
            for (int i = 0; i < hazardWaves; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(spawnValues.z, spawnValues.z + 5));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateText();
    }

    public void GameOver()
    {
        gameOver = true;
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
