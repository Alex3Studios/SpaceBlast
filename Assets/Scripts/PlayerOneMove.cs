using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerOneMove : MonoBehaviour {

	//Variables
    public float PlayerSpeed = 5f;
    public float PlayerRotation = 10f;
    public float JumpForce = 800f;
    public bool IsRight = false;
    public bool CanFlip = true;
    private Player player1;

    void Awake()
    {
        player1 = ReInput.players.GetPlayer(0);
    }

    //Update Function
    void Update()
    {
        //Move
        //float Move = Input.GetAxis ("Horizontal");
        //float MoveVertical = Input.GetAxis ("Vertical");
        float MoveX = player1.GetAxis("RotateX");
        float MoveY = player1.GetAxis("RotateY");
        float heading = Mathf.Atan2(MoveY, MoveX);

        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
    }

}