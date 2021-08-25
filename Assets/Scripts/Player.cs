using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //[SerializeField]
    static private Rigidbody2D rigidbody2D;
    static public float posOfCol;
    static public int score;
    public Text text;
    public Text endText; 
    static public int highScore;
    private SpriteRenderer SpriteRenderer;
    [SerializeField] private DATABASE data;
    private int o = 0; 

    void Start()
    {
        score = -0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = data.characters[PlayerPrefs.GetInt("Data")].character;
        posOfCol = 5;
        if (!MainMenu.devilMode)
        highScore = PlayerPrefs.GetInt("highScore");
        else
            highScore = PlayerPrefs.GetInt("devilHigh");
        o = 0;

    }

    // Update is called once per frame
    private void Update()
    {
        text.text = score.ToString();
        endText.text = score.ToString();
        GameObject cam = GameObject.Find("Main Camera"); 
        if ( cam.transform.position.y - 10 > transform.position.y)
        {
            if (MainMenu.devilMode)
            {
                PlayerPrefs.SetInt("devilHigh", Mathf.Max(highScore, score));
            }
            else PlayerPrefs.SetInt("highScore", Mathf.Max(highScore, score));
            ScoreBoard.gameOver = true;
            //Destroy(gameObject);
         
            if (o == 0)
            {
                FindObjectOfType<AudioManager>().Play("GameOver");
                o = 1; 
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && collision.transform.position.y < 5)
        {
            this.transform.parent = collision.transform;
            posOfCol = collision.transform.position.y;
            FindObjectOfType<AudioManager>().Play("HitGround");
            score++;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            this.transform.parent = null;
        }
    }

    

    static public void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0,10f));
    }

    
}
