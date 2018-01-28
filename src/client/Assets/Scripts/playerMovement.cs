using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private bool move;
    private Vector3 target;
    int z = 0;
    int x = 0;
    private void Start()
    {
        //TODO - replace this completly
    }
    private void Update()
    {
        //Cursor Position relative to player
        //Debug.Log(Camera.main.ViewportToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            target = GridController.highlightHex;
            target.y = 0;
            if (!move)
            {
                move = true;
            }
            //rotation
            Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.y = 0;
            transform.LookAt(mouseWorldPosition, Vector3.up);

        }

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        //Player Position
        Debug.Log("PX:" + transform.position.x + " PZ:" + transform.position.z);
    }
}
