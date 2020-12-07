using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class GameController : MonoBehaviour
{
    public static GameController instance;

    public LevelManager levelManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

    }

    private void Init()
    {

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyboardInput();
    }


    private void CheckKeyboardInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            if (!levelManager.Player.isMoving)
            {
                levelManager.Player.isMoving = true;

                int levelProtoWidth = levelManager.ActiveLevel.LevelPrototype.GetLength(1);
                int levelProtoHeight = levelManager.ActiveLevel.LevelPrototype.GetLength(0);
                float moveDistance = (float)levelManager.ActiveLevel.graphicBlockSize.x / 2 / 100;

                if (Input.GetKey(KeyCode.UpArrow)) levelManager.Player.MoveForward(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.DownArrow)) levelManager.Player.MoveBack(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.LeftArrow)) levelManager.Player.MoveLeft(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.RightArrow)) levelManager.Player.MoveRight(moveDistance, levelProtoWidth, levelProtoHeight);

            }
        }


    }
}
