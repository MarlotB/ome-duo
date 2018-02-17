using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour
{

    private int playerMoney; // money at start
    public Text ScoreText;
   
    

    void Start()
    {
               playerMoney = 1027;
        ScoreText.text = "Geld: €" + playerMoney.ToString();
           }

    // Update is called once per frame
    void Update()
    {
               if (playerMoney <= 0.0f) // if money is 0 then player dies
        {
            SceneManager.LoadScene("GameOverScene"); // loads game over screen
        }
          }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("EndLevel"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (trig.gameObject.CompareTag("Money"))
        {
            trig.gameObject.SetActive(false);
            playerMoney = playerMoney + 20;
            ScoreText.text = "Geld: €" + playerMoney.ToString();
        }
        if (trig.gameObject.CompareTag("Games"))
        {
            trig.gameObject.SetActive(false);
            playerMoney = playerMoney - 40;
            ScoreText.text = "Geld: €" + playerMoney.ToString();
        }
        if (trig.gameObject.CompareTag("Food"))
        {
            trig.gameObject.SetActive(false);
            playerMoney = playerMoney - 6;
            ScoreText.text = "Geld: €" + playerMoney.ToString();
        }
        if (trig.gameObject.CompareTag("Doctor"))
        {
            trig.gameObject.SetActive(false);
            playerMoney = playerMoney - 100;
            ScoreText.text = "Geld: €" + playerMoney.ToString();
        }
    }
    
} 