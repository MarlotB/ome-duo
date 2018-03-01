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
   	public Color32 darkBlue;
   	public Color32 lightBlue;
    public GameObject Panel;
    public Button HealthOK;
    public GameObject HealthNoPickup;
    public GameObject Panel2;
    public Button RentOK;
    public GameObject RentNoPickup;
    public AudioClip MoneySoundEffect;
    public AudioSource MoneySoundEffectSource;
    public AudioClip FoodSoundEffect;
    public AudioSource FoodSoundEffectSource;
    public AudioClip GamesSoundEffect;
    public AudioSource GamesSoundEffectSource;
    public AudioClip DoctorSoundEffect;
    public AudioSource DoctorSoundEffectSource;
    public AudioClip BooksSoundEffect;
    public AudioSource BooksSoundEffectSource;


    public float duration = 1.0F;
    public Renderer rend;

	   //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    void Start()
    {
		//darkBlue = new Color32(93, 114, 118, 0);
		//lightBlue = new Color32(82, 217, 244, 0);
               playerMoney = 1027;
        ScoreText.text = "Geld: €" + playerMoney.ToString();
		rend = GetComponent<Renderer>();
        Panel.gameObject.SetActive(false);
        HealthOK.gameObject.SetActive(false);
        Panel2.gameObject.SetActive(false);
        RentOK.gameObject.SetActive(false);
        MoneySoundEffectSource.clip = MoneySoundEffect;
        FoodSoundEffectSource.clip = FoodSoundEffect;
        GamesSoundEffectSource.clip = GamesSoundEffect;
        DoctorSoundEffectSource.clip = DoctorSoundEffect;
        BooksSoundEffectSource.clip = BooksSoundEffect;
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
			MoneySoundEffectSource.Play ();
		}
		if (trig.gameObject.CompareTag ("Games")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 40;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
			GamesSoundEffectSource.Play ();

		}
		if (trig.gameObject.CompareTag ("Food")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 6;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
			FoodSoundEffectSource.Play ();
		}
		if (trig.gameObject.CompareTag ("Doctor")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 83;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
			DoctorSoundEffectSource.Play ();
		}
		if (trig.gameObject.CompareTag ("Rent")) {
			trig.gameObject.SetActive (false);
			playerMoney = playerMoney - 400;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}
		if (trig.gameObject.CompareTag ("HealthNoPickup")) {
			Panel.gameObject.SetActive (true);
			HealthOK.gameObject.SetActive (true);
			playerMoney = playerMoney - 110;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}
		if (trig.gameObject.CompareTag ("RentNotPickup")) {
			Panel2.gameObject.SetActive (true);
			RentOK.gameObject.SetActive (true);
			playerMoney = playerMoney - 300;
			ScoreText.text = "Geld: €" + playerMoney.ToString ();
		}

		if (!trig.CompareTag ("Background")) {
        	checkAmountOfMoney(trig);
		}

        if (trig.gameObject.CompareTag("Books"))
        {
            trig.gameObject.SetActive(false);
            playerMoney = playerMoney - 40;
            ScoreText.text = "Geld: €" + playerMoney.ToString();
            BooksSoundEffectSource.Play();
        }

    }

    public void checkAmountOfMoney (Collider2D trig)
	{
		// darkblue color if the amount of money < 990
		if (playerMoney < 990 && mainCamera.backgroundColor != darkBlue) {
			StartCoroutine(changeCameraBackgroundColor(lightBlue, darkBlue, 1f));
		}

		if (playerMoney > 990 && mainCamera.backgroundColor != lightBlue) {
			StartCoroutine(changeCameraBackgroundColor(darkBlue, lightBlue, 1f));
		}
	}

	public IEnumerator changeCameraBackgroundColor(Color32 startColor, Color32 endColor, float duration)
	{
		float lerpControl = 0;
		float timeRemaining = duration;
	     while (timeRemaining > 0)
	     {
	         timeRemaining -= Time.deltaTime;
			 lerpControl += Time.deltaTime/duration;
			 mainCamera.backgroundColor = Color.Lerp(startColor, endColor, lerpControl);
	         yield return null;
	     }
		mainCamera.backgroundColor = endColor;
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