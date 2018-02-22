using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour
{

    private int playerMoney; // money at start
    public Text ScoreText;
   	public Camera mainCamera;
   	private Color32 darkBlue;
   	private Color32 lightBlue;

    public float duration = 1.0F;
    public Renderer rend;

	AudioSource m_MyAudioSource;

    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    void Start()
    {
		darkBlue = new Color32(93, 114, 118, 0);
		lightBlue = new Color32(82, 217, 244, 0);
               playerMoney = 1027;
        ScoreText.text = "Geld: €" + playerMoney.ToString();
		rend = GetComponent<Renderer>();
           }

    // Update is called once per frame
    void Update()
    {
               if (playerMoney <= 0.0f) // if money is 0 then player dies
        {
            SceneManager.LoadScene("GameOverScene"); // loads game over screen
        }
          }

    void OnTriggerEnter2D (Collider2D trig)
	{
		if (trig.gameObject.CompareTag ("EndLevel")) {
			SceneManager.LoadScene ("GameOverScene");
		}
		if (trig.gameObject.CompareTag ("Money")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney + 20;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}
		if (trig.gameObject.CompareTag ("Games")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 40;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();

			//Fetch the AudioSource from the GameObject
        	m_MyAudioSource = GetComponent<AudioSource>();

			//Check to see if you just set the toggle to positive
       		if (m_Play == true && m_ToggleChange == true)
        	{
            	//Play the audio you attach to the AudioSource component
            	m_MyAudioSource.Play();
            	//Ensure audio doesn’t play more than once
            	m_ToggleChange = false;
      	  	}
        	//Check if you just set the toggle to false
        	if (m_Play == false && m_ToggleChange == true)
        	{
            	//Stop the audio
            	m_MyAudioSource.Stop();
            	//Ensure audio doesn’t play more than once
            	m_ToggleChange = false;
        	}
		}
		if (trig.gameObject.CompareTag ("Food")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 6;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}
		if (trig.gameObject.CompareTag ("Doctor")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 100;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}
		if (playerMoney < 990) {
			mainCamera.backgroundColor = darkBlue;
			float lerp = Mathf.PingPong(Time.time, 7) / duration;
			mainCamera.backgroundColor = Color.Lerp(darkBlue, lightBlue, Mathf.PingPong(Time.time, 1));
		}

    }

	void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }
    
} 