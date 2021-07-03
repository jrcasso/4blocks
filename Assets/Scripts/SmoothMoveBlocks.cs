using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveBlocks : MonoBehaviour {
    public bool Is_Cluster = false;
    public static bool Is_Selected = false;
    public float UserSameDirectionMoveMultiplier = 2.0f;
    public Vector3 DirectionVector = new Vector3(0, 0, 0);

    public void GameMoveTheBlock() {
        if (Is_Cluster == false)
        {
            if (transform.position.x == GameObject.Find("Spawn2").transform.position.x)
            {
                DirectionVector = Vector3.right;
            }
            if (transform.position.x == GameObject.Find("Spawn4").transform.position.x)
            {
                DirectionVector = Vector3.left;
            }
            if (transform.position.y == GameObject.Find("Spawn1").transform.position.y)
            {
                DirectionVector = Vector3.down;
            }
            if (transform.position.y == GameObject.Find("Spawn3").transform.position.y)
            {
                DirectionVector = Vector3.up;
            }
            transform.Translate(0.01f * DirectionVector);
        }
    }

    //public string GetValidKeyDown()
    //{
    //    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S){
    //        return ("down");
    //    }
    //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W){
    //        return ("up");
    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A){
    //        return ("left");
    //    }
    //    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D){
    //        return ("right");
    //    }
    //    else { return ""; }
    //}

    private void OnMouseDown()
    {
        if(Is_Cluster == false)
        {
            GameObject.Find("Spawn").GetComponent<SpawnBlocksDiscrete>().target = gameObject;
        }
    }

    private void RotateTheBlock()
    {
        Debug.Log("Tried to rotate.");
        Rigidbody temprigid = transform.GetComponent<Rigidbody>();
        temprigid.freezeRotation = false;
        transform.Rotate(0,0,-90);
        //DirectionVector = Quaternion.Euler(0,0,-90) * DirectionVector;
        temprigid.freezeRotation = true;
    }

    void Start () {
        Rigidbody temprigid = transform.GetComponent<Rigidbody>();
        temprigid.freezeRotation = true;
        InvokeRepeating("GameMoveTheBlock", 0.0f, 0.01f);
	}

    //void Update()
    //{

    //    if (GameObject.Find("Spawn").GetComponent<SpawnBlocksDiscrete>().target == gameObject)
    //    {
    //        if (Is_Cluster == true)
    //        {
    //            GameObject.Find("Spawn").GetComponent<SpawnBlocksDiscrete>().target = null;
    //        }

    //        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
    //        {
    //            if(DirectionVector == Vector3.down)
    //            {
    //                transform.Translate(UserSameDirectionMoveMultiplier * 0.01f * DirectionVector);
    //            }
    //            else if(DirectionVector == Vector3.up)
    //            {
    //                RotateTheBlock();
    //            }
    //            else
    //            {
    //                transform.Translate(Vector3.down);
    //            }
    //        }
    //        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
    //        {
    //            if (DirectionVector == Vector3.up)
    //            {
    //                transform.Translate(UserSameDirectionMoveMultiplier * 0.01f * DirectionVector);
    //            }
    //            else if (DirectionVector == Vector3.down)
    //            {
    //                RotateTheBlock();
    //            }
    //            else
    //            {
    //                transform.Translate(Vector3.up);
    //            }
    //        }
    //        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    //        {
    //            if (DirectionVector == Vector3.left)
    //            {
    //                transform.Translate(UserSameDirectionMoveMultiplier * 0.01f * DirectionVector);
    //            }
    //            else if (DirectionVector == Vector3.right)
    //            {
    //                RotateTheBlock();
    //            }
    //            else
    //            {
    //                transform.Translate(Vector3.left);
    //            }
    //        }
    //        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    //        {
    //            if (DirectionVector == Vector3.right)
    //            {
    //                transform.Translate(UserSameDirectionMoveMultiplier * 0.01f * DirectionVector);
    //            }
    //            else if (DirectionVector == Vector3.left)
    //            {
    //                RotateTheBlock();
    //            }
    //            else
    //            {
    //                transform.Translate(Vector3.right);
    //            }
    //        }
    //    }
    //}

    void Update()
    {

        if (GameObject.Find("Spawn").GetComponent<SpawnBlocksDiscrete>().target == gameObject)
        {
            if (Is_Cluster == true)
            {
                GameObject.Find("Spawn").GetComponent<SpawnBlocksDiscrete>().target = null;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (DirectionVector != Vector3.up)
                {
                    transform.Translate(Vector3.down);
                }
                else
                {
                    RotateTheBlock();
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (DirectionVector != Vector3.down)
                {
                    transform.Translate(Vector3.up);
                }
                else
                {
                    RotateTheBlock();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (DirectionVector != Vector3.right)
                {
                    transform.Translate(Vector3.left);
                }
                else
                {
                    RotateTheBlock();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (DirectionVector != Vector3.left)
                {
                    transform.Translate(Vector3.right);
                }
                else
                {
                    RotateTheBlock();
                }
            }
        }
    }
}

//if(Is_Selected == true)

