﻿
using UnityEngine;
using System.Collections;

public class UserWalk : MonoBehaviour
{

    public float Speed = 4f;//유저가 움직이는 속도
    Animator anim;
    Renderer rend;
    Rigidbody2D rb2;
    bool enter;//들어가는거, 나오는거 제어
    public GameObject User;
    bool move;//player의 움직임 제어한다
    
    

    // Use this for initialization
    void Start()
    {
        //      anim = GetComponent<Animator>();
 //       transform.position = new Vector3(0, 0, 0);
        rend = gameObject.GetComponent<Renderer>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        rend.enabled = true;
        enter = false;
        move = true;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void OnTriggerEnter2D(Collider2D other)//문에 도착했을때 
    {
        if (other.gameObject.tag=="Door")
            {
            enter = true;//문에 부딪치는 동안은 w키와 s키를 사용할 수 있다
        }

		if (other.gameObject.tag == "Enemy")
		{
			other.GetComponent<PatrolWalk>().changeSpeed();//문에 부딪치는 동안은 w키와 s키를 사용할 수 있다
		}
            
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag=="Door")
        {
            enter = false;//문에서 나오면 w키와 s키를 사용할 수 없다
        }
    }
    
    void Movement()//움직임 제어하는 함수
    {
        if (move==true && Input.GetKey(KeyCode.A) && transform.position.x>-28.8f)//왼쪽으로 이동, 복도를 벗어나지 않게 범위 제한
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180,0);//바라보는 방향 바뀐다
        }
        else if (move==true && Input.GetKey(KeyCode.D) && transform.position.x < 28.8f)//오른쪽으로 이동, 복도를 벗어나지 않게 범위 제한
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0,0);//바라보는 방향 바뀐다
        }
        else if (Input.GetKey(KeyCode.W) && enter==true)//숨기
        {
            rend.enabled = false;//player의 모습이 보이지 않는다
            move = false;//이때 player는 움직일 수 없다

        }
        else if (Input.GetKey(KeyCode.S) && enter == true)//나오기
        {
            rend.enabled = true;//player의 모습이 다시 나타난다
            move = true;//다시 player는 움직이는 것이 가능해진다
        }

    }

}
