using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private float mouseX;
    private float mouseY;

    private Vector2 joystickOriginalPos;

    public Transform circle;
    public Transform outerCircle;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = outerCircle.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            if (mouseY < joystickOriginalPos.y + 900){
                
                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

                circle.transform.position = (pointA);
                outerCircle.transform.position = (pointA);

                // circle.GetComponent<SpriteRenderer>().enabled = true;
                // outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            }
            
        }
        if(Input.GetMouseButton(0)){
            if (mouseY < joystickOriginalPos.y + 900){
                touchStart = true;
            }
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        } else {
            touchStart = false;
        }
    }

    private void FixedUpdate(){

        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        if(touchStart){

            Vector2 offset = (pointB - pointA);
            Vector2 direction = Vector2.ClampMagnitude(offset, 0.7f);
            moveCharacter(direction);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);

        } else {
            outerCircle.transform.position = joystickOriginalPos;
            circle.transform.position = joystickOriginalPos;
            // circle.GetComponent<SpriteRenderer>().enabled = false;
            // outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void moveCharacter(Vector2 direction){
        player.Translate(direction * speed * Time.deltaTime);
    }
}
