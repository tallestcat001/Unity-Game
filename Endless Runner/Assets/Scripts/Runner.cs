using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float positionX = 2.5f;
    [SerializeField] float speed = 25.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void OnKeyUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           if(roadLine != RoadLine.LEFT)
            {
                roadLine--;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine != RoadLine.RIGHT)
            {
                roadLine++;
            }
        }
    }

    void Update()
    {
        OnKeyUpdate();
    }

    private void Move()
    {
        rigidBody.position = Vector3.Lerp(rigidBody.position, new Vector3((int)roadLine * positionX, 0, 0), speed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
