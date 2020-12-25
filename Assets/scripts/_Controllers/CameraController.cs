using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform camPosition;
    Camera mainCam;

    private void InitCamera()
    {
        mainCam = GetComponent<Camera>();
        camPosition = GetComponent<Transform>();
    }

    private void SetCamPosition()
    {
        const int pixelInOne_UNIT = 100;
        const float SCREEN_BORDER_SIZE = 0.4f;

        Level activeLevel = LevelManager.Instance.ActiveLevel;

        int blockSize_Y = activeLevel.GraphicBlockSize.y;
        int blockSize_X = activeLevel.GraphicBlockSize.x;

        float levelPixelHeight = (float)blockSize_Y * (float)activeLevel.LevelPrototype.GetLength(0);
        //float levelPixelWidth = (float)blockSize_X * (float)tLevel.LevelPrototype.GetLength(1);

        float x = (levelPixelHeight / pixelInOne_UNIT + SCREEN_BORDER_SIZE * 2) / 2;
        float y = levelPixelHeight / pixelInOne_UNIT / 2;
        
        mainCam.orthographicSize = x;

        camPosition.position = new Vector3(x, y, camPosition.position.z);

    }


    // Start is called before the first frame update
    void Start()
    {
        InitCamera();

        SetCamPosition();

    }


    // Update is called once per frame
    void Update()
    {

    }


}
