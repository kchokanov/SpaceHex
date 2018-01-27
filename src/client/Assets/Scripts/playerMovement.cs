using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float speed;
    private bool move;
    private Vector3 target;
    private void Start()
    {
        //TODO - replace this completly
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!move)
            {
                move = true;
            }
        }

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
