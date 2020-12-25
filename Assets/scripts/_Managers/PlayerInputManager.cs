using UnityEngine;

class PlayerInputManager : Singleton<PlayerInputManager>
{

    void Init()
    {
       

    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        CheckKeyboardInput();

    }


    private void CheckKeyboardInput()
    {
        CheckFire();

        CheckMove();

    }

    private static void CheckMove()
    {
        if (Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            var lm = LevelManager.Instance;
            var v = true;

            v = lm.Players[0].isMoving;
            if (!v)
            {
                lm.Players[0].isMoving = true;

                int levelProtoWidth = lm.ActiveLevel.LevelPrototype.GetLength(1);
                int levelProtoHeight = lm.ActiveLevel.LevelPrototype.GetLength(0);
                float moveDistance = (float)lm.ActiveLevel.GraphicBlockSize.x / 2 / 100;

                if (Input.GetKey(KeyCode.UpArrow)) lm.Players[0].MoveForward(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.DownArrow)) lm.Players[0].MoveBack(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.LeftArrow)) lm.Players[0].MoveLeft(moveDistance, levelProtoWidth, levelProtoHeight);
                if (Input.GetKey(KeyCode.RightArrow)) lm.Players[0].MoveRight(moveDistance, levelProtoWidth, levelProtoHeight);

            }
        }
    }

    private void CheckFire()
    {
        if (!bulletIsRun && Input.GetKeyDown(KeyCode.Space))
        {
            SetBulletRun(true);
            //BulletStartRun_Event?.Invoke();

        }
    }

    public bool bulletIsRun { get; private set; } = false;
    public void SetBulletRun(bool isRun) => bulletIsRun = isRun;

    void IsBulletEndRun() => Debug.Log("Fuck");



}
