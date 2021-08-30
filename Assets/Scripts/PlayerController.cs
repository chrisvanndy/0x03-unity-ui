using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

	private Scene scene;
	public Rigidbody player;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text endText;
	public Image endImage;

	public float speed = 2000f;
	
	// Use this for initialization
	void Start() 
	{
		player = GetComponent<Rigidbody>();
		scene = SceneManager.GetActiveScene();
	}

  // Update is called once per frame
	void Update() 
	{
		 if (Input.GetKey("a") || Input.GetKey("left")) 
		 {
			  player.AddForce(-speed * Time.deltaTime, 0, 0);
		 }
		 if (Input.GetKey("d") || Input.GetKey("right"))
		 {
			  player.AddForce(speed * Time.deltaTime, 0, 0);
		 }
		 if (Input.GetKey("w") || Input.GetKey("up"))
		 {
			  player.AddForce(0, 0, speed * Time.deltaTime);
		 }
		 if (Input.GetKey("s") || Input.GetKey("down"))
		 {
			  player.AddForce(0, 0, -speed * Time.deltaTime);
		 
		 }
		 if (Input.GetKey("escape"))
		 {
				SceneManager.LoadScene("menu");
		 }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			score++;
			Destroy(other.gameObject);
			//other.GetComponent<MeshRenderer>().enabled = false;
			//Debug.Log("Score: " + score);
			SetScoreText();

		}
		if (other.GetComponent<Collider>().tag == "Trap")
		{
			health--;
			// Debug.Log("Health: " + health);
			SetHealthText();
			if (health == 0)
			{
				YouLose();
			}
		}

		if (other.GetComponent<Collider>().tag == "Goal")
		{
			// Debug.Log("You Win!");	
			YouWin();	
		}

	// updated UI element TextScore to players current score

	}
	void YouWin()
	{
		endImage.gameObject.SetActive(true);
		endImage.color = Color.green;
		endText.text = "You Win!";
		endText.color = Color.black;
		StartCoroutine(LoadScene(3.0F));
	}

	void YouLose()
	{
		endImage.gameObject.SetActive(true);
		endText.text = "You Lose!";
		StartCoroutine(LoadScene(3.0F));
	}

	void SetScoreText()
	{
		scoreText.text = $"Score: {score}";
	}

	void SetHealthText()
	{
		healthText.text = $"Health: {health}";
	}

	IEnumerator LoadScene(float seconds)
	{
		// Suspends coroutine execution for given seconds with scaled time
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");

	}
}