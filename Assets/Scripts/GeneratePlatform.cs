using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePlatform : MonoBehaviour
{
    public Player2DMovement player;
    public GameObject platformPrefab;
    public GameObject rockPrefab;
    public float platformRespawnTime = 2.0f;
    public Text comandoText;
    public Text scoreText;
    public float generateCommandTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        float rtime = Random.Range(1.0f, 5.0f);

        Invoke("spawnRock", rtime);
        Invoke("spawnPlatform", platformRespawnTime);
        Invoke("callCommand", generateCommandTime);
        clearText();
    }

    private void spawnRock(){
        GameObject a = Instantiate(rockPrefab) as GameObject;
        a.transform.position = new Vector2(15,-0.85f);
        rockPrefab = a;

        float rtime = Random.Range(5.0f, 8.0f);

        Invoke("spawnRock", rtime);
    }

    private void clearText(){
        comandoText.text = "";
        comandoText.color = Color.green;
    }

    private void callCommand(){
        int randnum = Random.Range(1, 4);
        float randtime = Random.Range(1.0f, 6.0f);

        if(!player.IsJumping){
            if(randnum==1){
            comandoText.text = "Morto!";
            Invoke("checkPlayerIsPlayingDead", 0.6f);
        
            }else{
                comandoText.text = "Dino!";
                Invoke("checkPlayerIsUp", 0.6f);
            }
        }else{
            randtime = Random.Range(1.0f, 3.0f);
        }
        
        Invoke("callCommand", randtime);
    }

    private void checkPlayerIsPlayingDead(){
        if(player.isDead){
            Debug.Log("MORTO OK!");
            scoreText.text = (int.Parse(scoreText.text)+10).ToString();
        }else{
            comandoText.color = Color.red;
            if(int.Parse(scoreText.text) <= 10){
                scoreText.text = "0";
            }else{
                scoreText.text = (int.Parse(scoreText.text)-10).ToString();
            }
            
        }
        Invoke("clearText", 0.5f);
    }

    private void checkPlayerIsUp(){
        if(!player.isDead){
            Debug.Log("DINO OK!");
            scoreText.text = (int.Parse(scoreText.text)+10).ToString();
        }else{
            comandoText.color = Color.red;
            if(int.Parse(scoreText.text) <= 10){
                scoreText.text = "0";
            }else{
                scoreText.text = (int.Parse(scoreText.text)-10).ToString();
            }
        }
        Invoke("clearText", 0.5f);
    }

    private void spawnPlatform(){
        GameObject a = Instantiate(platformPrefab) as GameObject;
        a.transform.position = new Vector2(20,-2.92f);
        platformPrefab = a;

        if (platformRespawnTime == 2.0f){
            platformRespawnTime = 4.0f;
        }

        Invoke("spawnPlatform", platformRespawnTime);
    }
}
