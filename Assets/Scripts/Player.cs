using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ScoreManager scoreManager;

    public TextMeshProUGUI scoreText;

    public float jumpForce = 100;

    private Rigidbody2D rb;

    public int score = 0;
    public AudioClip successSound;
    public AudioClip flapSound;
    public AudioClip crashSound;

    private AudioSource audioSource;

    void Start()
    {
        //GetComponent can get the component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                //impulse is a force that is applied instantly, like throwing a ball
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                audioSource.PlayOneShot(flapSound);
            }
            
        }

        //animations
        if(rb.velocity.y > 0)
        {
            //quaternion - rotation in 3D space
            //euler - transforms the rotation into a Vector3
            transform.rotation = Quaternion.Euler(0, 0, 30);

        }
        else
        {
           transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        score++;
        scoreText.text = score.ToString("D4");
        audioSource.PlayOneShot(successSound);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        scoreManager.ShowScoreBoard(score);
        gameObject.SetActive(false); //deactivate the player
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
