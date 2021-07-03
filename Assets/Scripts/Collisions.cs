using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

	//void OnCollisionExit(Collision collision) {
 //       if(collision.collider.tag == "Block")
 //       {
 //           Destroy(collision.gameObject);
 //       }
 //       if (collision.collider.tag == "Boundary")
 //       {
 //           Destroy(transform.gameObject);
 //       }
	//}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Block")
        {
            if(gameObject.tag != "Finish")
            {
                Destroy(collision.gameObject);
            }
        }
        if(collision.collider.tag == "Boundary")
        {
            Destroy(transform.gameObject);
            Debug.Log("Destroyed a block because of boundary.");
        }
        if (collision.collider.tag == "Finish")
        {
            foreach (Transform x in transform)
            {
                x.tag = "Finish";
            }
            gameObject.tag = "Finish";
            Rigidbody RigidVar = gameObject.GetComponent<Rigidbody>();
            RigidVar.isKinematic = true;
            SmoothMoveBlocks MoveVar = gameObject.GetComponent<SmoothMoveBlocks>();
            MoveVar.Is_Cluster = true;
            RoundPosition();
        }
    }

    private void RoundPosition()
    {
        Vector3 PosVec = new Vector3((float)System.Math.Round(gameObject.transform.position.x, 0), (float)System.Math.Round(gameObject.transform.position.y, 0), (float)System.Math.Round(gameObject.transform.position.z, 0));
        gameObject.transform.position = PosVec;
    }

    private void Update()
    {

    }

}