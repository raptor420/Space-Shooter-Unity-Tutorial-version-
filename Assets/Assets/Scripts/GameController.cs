using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

public Text scoreText;
    public Text highscore;
public GameObject[] Hazards;
public Vector3 spawnValues;
public int hazardcount;
     
public float spawnrate;
public float startwait;
public float wavewait;
private int score =0;
public int ScorePoint;
private bool gameOver;
private bool Restart;
public GameObject gameOverText;
IEnumerator spawnwaves()
{
yield return new WaitForSeconds(startwait);
while (true)
{
for (int i = 0; i < hazardcount; i++)
{
                GameObject Hazard = Hazards[Random.Range(0,Hazards.Length)];


Vector3 spawnposition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
Quaternion spawnrotation = Quaternion.identity;
Instantiate(Hazard, spawnposition, spawnrotation);
yield return new WaitForSeconds(spawnrate);
}
yield return new WaitForSeconds(wavewait);
            if (gameOver)
            {
                break;

            }
}
}
void Start () {
        highscore.text =  "HIGH SCORE " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    gameOver = false;
    Restart = false;
StartCoroutine (spawnwaves());
scoreText.text = "Score " + 0;

}
public  void updateScore()
{
score= score +ScorePoint;
scoreText.text = "Score " + score;

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);

            highscore.text = "HIGH SCORE " + PlayerPrefs.GetInt("HighScore").ToString();
        }


}

public  void  Gameisover()
{
        gameOverText.SetActive(true);
        gameOver = true;

}

    public void restartgame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
	
// Update is called once per frame
void Update () {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButton("Fire1"))
            {

                restartgame();
            }
        }
}
}
