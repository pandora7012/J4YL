using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{
    private int direction;
    public bool hadLanded;
    public int speed;
    private  Rigidbody2D rigidbody2D;
    public DATABASE data; 
    public Sprite nor1;
    public Sprite nor2;
    public Sprite dev2;
    public Sprite dev1; 
    private int state;
    private float pk;
    private Color color;
    private int r, p;
    void Awake()
    {
        if (MainMenu.devilMode)
            gameObject.GetComponent<SpriteRenderer>().sprite = dev2;
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = data.maps[PlayerPrefs.GetInt("MAP")].platNor;
        }
        state = 2; 
        hadLanded = false; 
        direction = 1;
        pk = Random.Range(-0.7f, 0.7f);
        if (transform.position.y == 5)
        {
            speed = 0;
            transform.position = new Vector2(0, 5);
            pk = 0;
        }
        else
        {
            if (!MainMenu.devilMode)
                speed = (int)Random.Range(2f - PlatformManager.initPosPlat/30, 4f - PlatformManager.initPosPlat/30);
            else speed = (int) Random.Range(4f, 10f);
        }
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        color = gameObject.GetComponent<SpriteRenderer>().color;
        p = -1;
        r = Random.Range(0, 150);
        
    }
    
    private void Update()
    {
        movement();
        stateHandle();
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(0) )
        {
            setToSimulated();
            Player.Jump();
            Debug.Log("1");
            Invoke("simulated", 0.7f);
                
        }
        if (transform.position.y - Player.posOfCol > 6.2f)
        {
            Destroy(gameObject);
        }
        if (r < 50 && gameObject.transform.position.y <0 && !hadLanded)
        {
            if (color.a <= 0)
            {

                p = 1;
            }
            else if (color.a >= 1)
            {
                p = -1;
            }

            color.a += p * Time.deltaTime * 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        if (hadLanded)
        {
            color.a = 1;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
    
    
    private void movement()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime * direction , transform.position.y + direction* pk*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            if (hadLanded) state--;

            direction *= -1;

        }
        else if ( collision.collider.tag == "Player")
        {
            hadLanded = true;
        }
        
    }
    public void setToSimulated()
    {
        if (hadLanded == true)
        {
            rigidbody2D.simulated = false;
        }
    }

    public void simulated()
    {
        rigidbody2D.simulated = true;
    }

    private void stateHandle()
    {
        if (state == 1)
        {
            if (MainMenu.devilMode)
                gameObject.GetComponent<SpriteRenderer>().sprite = dev1; 
            else 
            this.gameObject.GetComponent<SpriteRenderer>().sprite =  data.maps[PlayerPrefs.GetInt("MAP")].platBre;
            ;
        }
        else if (state == 0)
        {
            Destroy(gameObject);
        }
    }

    
}
