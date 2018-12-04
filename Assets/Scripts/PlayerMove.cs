using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	//Variables
     public float PlayerSpeed = 5f;
     public float PlayerRotation = 10f;
     public bool IsRight = false;
     public bool CanFlip = true;
 
     //Update Function
     void Update () {
        //Move
        float Move = Input.GetAxis ("Horizontal");
        float MoveVertical = Input.GetAxis ("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2 (MoveVertical * PlayerSpeed, GetComponent<Rigidbody2D>().velocity.x);
        GetComponent<Rigidbody2D>().velocity = new Vector2 (Move * PlayerSpeed, GetComponent<Rigidbody2D>().velocity.x);
        GetComponent<Rigidbody2D>().AddTorque (Move * PlayerRotation);

        
        //Flip
        if (Move > 0 && !IsRight) {
                Flip ();
        } else if (Move < 0 && IsRight) {
                Flip ();
        }
    }
 
     //Flip Function
     void Flip() {
         if (CanFlip) {
                IsRight = !IsRight;
                transform.Rotate(0f, 180f, 0f);
        }
     }


     public void Recoil() {
             GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100 * 100);
     }
}