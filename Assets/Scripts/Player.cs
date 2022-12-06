using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 TPosition;
    private bool isMoving = false;
    public Vector3 previousPosition;
    public Rigidbody2D rigidBody2d;
    Vector2 worldPos;
    // ходьба WASD
    //private void Update()
    //{
//        if (Input.GetKey(KeyCode.D))
//        {
//            transform.Translate(transform.right* speed * Time.deltaTime);
//}

//if (Input.GetKey(KeyCode.A))
//{
//    transform.Translate(transform.right * speed * Time.deltaTime * -1);
//}

//if (Input.GetKey(KeyCode.W))
//{
//    transform.Translate(transform.up * speed * Time.deltaTime);
//}

//if (Input.GetKey(KeyCode.S))
//{
//    transform.Translate(transform.up * speed * Time.deltaTime * -1);
//}
//}

//ходьба за мышкой

private void Update()
    {
        Camera cam = Camera.main;
        GameObject panel = GameObject.Find("Panel");
        RectTransform rt = (RectTransform)panel.transform;
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < RectTransformUtility.WorldToScreenPoint(cam, panel.transform.position).y - rt.rect.height / 2)
        {
            TriggerPosition();
        }

        if (isMoving)
        {
            ItsMove();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * speed * Time.deltaTime * -1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.up * speed * Time.deltaTime * -1);
        }
    }

    void TriggerPosition()
    {
        TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TPosition.z = transform.position.z;
        isMoving = true;
    }

    void ItsMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, TPosition, speed * Time.deltaTime);

        if (TPosition == transform.position)
        {
            isMoving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ObstacleUp")
        {
            transform.Translate(transform.up * speed * Time.deltaTime * (-1));
            isMoving = false;
        }

        if (col.gameObject.tag == "ObstacleDown")
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
            isMoving = false;
        }

        if (col.gameObject.tag == "ObstacleLeft")
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            isMoving = false;
        }

        if (col.gameObject.tag == "ObstacleRight")
        {
            transform.Translate(transform.right * speed * Time.deltaTime * (-1));
            isMoving = false;
        }
    }
}

//private void Start()
//    {
//        rigidBody2d = GetComponent<Rigidbody2D>();
//    }

//    private void Update()
//    {
//        Camera cam = Camera.main;
//        GameObject panel = GameObject.Find("Panel");
//        RectTransform rt = (RectTransform)panel.transform;
//        if (Input.GetMouseButtonDown(0))
//        {
//            TriggerPosition();
//        }

//        if (isMoving)
//        {
//            ItsMove();
//        }

//    }

//    private void FixedUpdate()
//    {

//    }

//    void TriggerPosition()
//    {
//        TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        isMoving = true;
//    }

//    void ItsMove()
//    {
//        rigidBody2d.MovePosition(Vector2.MoveTowards(transform.position, TPosition, speed * Time.deltaTime));


//        if (Vector2.Distance(transform.position, TPosition) < 0.01)
//        {
//            isMoving = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D col)
//    {
//        if (col.gameObject.tag == "ObstacleUp")
//        {

//            TPosition = Camera.main.ScreenToWorldPoint(transform.position);
//            isMoving = false;


//        }
//    }
//}

