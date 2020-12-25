using System;
using UnityEngine;

class BaseTank : MonoBehaviour
{
    public bool _isCanM = false;
    public bool isCanMoving { get => _isCanM; set => _isCanM = value; }
    public bool isMoving { get; set; }
    public en_TankType tankType { get; private set; }

    public Sprite[] sprites;

    protected Sprite sprite;
    protected float Speed { get => m_speed; private set => m_speed = value; }

    protected Vector3 targetPosition;
    protected Rigidbody2D rb2D;
    protected BoxCollider2D boxCollider2D;
    [SerializeField]
    protected Transform rayOrigin;

    protected float step;


    [SerializeField]
    private float m_speed;
    [SerializeField]
    float thrust = 300.0f;
    GameObject prefabBullet;
    Bullet m_bullet;


    protected virtual void Init()
    {
        prefabBullet = Resources.Load<GameObject>("Prefabs/bullet");
        sprite = GetComponent<SpriteRenderer>().sprite;
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        targetPosition = transform.position;
        //gc.BulletStartRun_Event += Fire;

    }


    public void SetSpeed(float speed) => Speed = speed;

    public void SetTankType(en_TankType type) => tankType = type;

    private double Katet(float sideA, float sideB)
    {
        sideA *= sideA;
        sideB *= sideB;

        float c = sideA + sideB;

        return Math.Sqrt(c);
    }

    private bool CheckNextPoint(Vector2 direction, float blockSize, int levelWidth, int levelHeight)
    {
        float _levelWidth = blockSize * 2 * (float)levelWidth;
        float _levelHeight = blockSize * 2 * (float)levelHeight;

        //blockSize -= 0.0001f;
        Vector2 target = direction * blockSize;

        bool isLevelArea = transform.position.y + target.y > 0 + blockSize & transform.position.x + target.x > 0 + blockSize;
        if (isLevelArea) isLevelArea = transform.position.y + target.y < _levelHeight - blockSize * 3 & transform.position.x + target.x < _levelWidth - blockSize * 3;

        if (isLevelArea)
        {
            //Debug.DrawRay(rayOrigin.position, target, Color.green, 1f);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, target, blockSize);

            Vector2 targetR = target + new Vector2(0.06f * direction.y, 0.06f * direction.x);
            //Debug.DrawRay(rayOrigin.position, targetR, Color.red, 1f);
            RaycastHit2D hitR = Physics2D.Raycast(rayOrigin.position, targetR, (float)Katet(blockSize, boxCollider2D.size.x / 2));

            Vector2 targetL = target - new Vector2(0.06f * direction.y, 0.06f * direction.x);
            //Debug.DrawRay(rayOrigin.position, targetL, Color.yellow, 1f);
            RaycastHit2D hitL = Physics2D.Raycast(rayOrigin.position, targetL, (float)Katet(blockSize, boxCollider2D.size.x / 2));

            isCanMoving = (hit.collider || hitR.collider || hitL.collider) ? false : true;


            //if (!isCanMoving)
            //{
            //    if (hit.collider) Debug.Log($"c:{hit.collider.name}");
            //    if (hitR.collider) Debug.Log($"c:{hitR.collider.name}");
            //    if (hitL.collider) Debug.Log($"c:{hitL.collider.name}");
            //}

            return isCanMoving;
        }
        return isLevelArea;
    }


    #region TANK Movement 

    public void MoveForward(float blockSize, int levelWidth, int levelHeight)
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        Vector3 tmp_targetPoint = new Vector3(transform.position.x, transform.position.y + blockSize, 0);

        bool tmp_ = CheckNextPoint(Vector2.up, blockSize, levelWidth, levelHeight);

        if (tmp_) targetPosition = tmp_targetPoint;
        //else Debug.Log("cant move to UP");


    }

    public void MoveBack(float blockSize, int levelWidth, int levelHeight)
    {
        transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);

        Vector3 tmp_targetPoint = new Vector3(transform.position.x, transform.position.y - blockSize, 0);

        bool tmp_ = CheckNextPoint(Vector2.down, blockSize, levelWidth, levelHeight);

        if (tmp_) targetPosition = tmp_targetPoint;
        //else Debug.Log("cant move to Down");

    }

    public void MoveRight(float blockSize, int levelWidth, int levelHeight)
    {
        transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);

        Vector3 tmp_targetPoint = new Vector3(transform.position.x + blockSize, transform.position.y, 0);

        bool tmp_ = CheckNextPoint(Vector2.right, blockSize, levelWidth, levelHeight);

        if (tmp_) targetPosition = tmp_targetPoint;
        //else Debug.Log("cant move to Right");
    }

    public void MoveLeft(float blockSize, int levelWidth, int levelHeight)
    {
        transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);

        Vector3 tmp_targetPoint = new Vector3(transform.position.x - blockSize, transform.position.y, 0);

        bool tmp_ = CheckNextPoint(Vector2.left, blockSize, levelWidth, levelHeight);

        if (tmp_) targetPosition = tmp_targetPoint;
        //else Debug.Log("cant move to Left");
    }
    #endregion


    void Fire()
    {
        float y = (float) LevelManager.Instance.ActiveLevel.GraphicBlockSize.x / 2 / 100;

        Vector3 direction = rayOrigin.position - transform.position;

        Vector3 initPosition = rayOrigin.position + direction.normalized * y;
        //Debug.Log($"offsetVector3 normalized >>> {direction.normalized.ToString("F5")}");

        Quaternion initQuaternion = transform.rotation;

        GameObject go = prefabBullet;

        m_bullet = go.GetComponent<Bullet>();

        go = Instantiate(m_bullet.gameObject, initPosition, initQuaternion, rayOrigin);

        go.GetComponent<Rigidbody2D>().AddForce(direction * thrust);

    }



}

