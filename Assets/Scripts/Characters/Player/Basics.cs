using UnityEngine;
using System.Collections;

public class Basics : MonoBehaviour   {

    public GameObject bullet;
    public Transform gunPoint;
    Manager statesManager;

    [Range(0.5f, 2.5f)]
    public float speed;


    Rigidbody2D rb;
    void Awake()
    {
        statesManager = GetComponent<Manager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        
    }

    void Update()
    {
        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shooting_True();
        }

    }

    void FixedUpdate()
    {
        //walking
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
           transform.localScale = new Vector3(1, 1,1) ;
            
            right();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            left();
        }

    }
	

    //  -----------------------FUNTIONS---------------------

    
        void right()   
        {

			
            Vector2 p = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1f, transform.position.y), speed * Time.deltaTime);
            rb.MovePosition(p);
            statesManager.StateChanger(Manager.States.walk, true);
            
        }


         void left()    //left
        {

            Vector2 p2 = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1f, transform.position.y), speed *Time.deltaTime);
            rb.MovePosition(p2);
            statesManager.StateChanger(Manager.States.walk, true);
            
        }



    void Shooting_True()
    {
        Instantiate(bullet, gunPoint.position, Quaternion.identity);
        statesManager.StateChanger(Manager.States.shoot, true);
    }

    public void Shooting_False()
    {
        statesManager.StateChanger(Manager.States.shoot, false);
    }

    
}
