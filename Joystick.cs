using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 4.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private Vector2 joystickOriginalPos;

    // to access mouse/pointer coordinates
    private float mouseX;
    private float mouseY;

    public Transform circle;
    public Transform outerCircle;

    public Transform playerSprite;
    private Vector2 playerPos;

    public Transform playerShadow;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = outerCircle.transform.position;   
        speed = 4.0f;

        animator.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {

        // moves playerSprite to playerMovementObject
        playerPos = player.transform.position;
        playerSprite.transform.position = new Vector2(playerPos.x, playerPos.y);
        playerShadow.transform.position = new Vector2(playerPos.x, playerPos.y - 0.22f);

        if(Input.GetMouseButtonDown(0)){

            if (mouseY < joystickOriginalPos.y + 600){ // make this scalable for all devices

                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

                circle.transform.position = (pointA);
                outerCircle.transform.position = (pointA);

                // circle.GetComponent<SpriteRenderer>().enabled = true;
                // outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            }
            
        }
        if(Input.GetMouseButton(0)){
            if (mouseY < joystickOriginalPos.y + 600){ // make this scalable for all devices
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

            animator.SetBool("isMoving", true);

            if (offset.x > 0){
                playerSprite.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (offset.x < 0){
                playerSprite.transform.eulerAngles = new Vector3(0, 180, 0);
            }

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);

        } else {

            outerCircle.transform.position = joystickOriginalPos;
            circle.transform.position = joystickOriginalPos;

            animator.SetBool("isMoving", false);

            // circle.GetComponent<SpriteRenderer>().enabled = false;
            // outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void moveCharacter(Vector2 direction){
        player.Translate(direction * speed * Time.deltaTime);
    }
}
