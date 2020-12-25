using System;
using System.Collections;
using UnityEngine;

class Bullet : MonoBehaviour
{
    public GameObject prefab_explosion;
    CapsuleCollider2D collider2D;

    public static event BulletFinishRun_Handler BulletFinishRun_event;

    private IEnumerator coroutine;

    void Init()
    {
        collider2D = GetComponent<CapsuleCollider2D>();

        //coroutine = WaitBulletExpl(3f, false);
        //StartCoroutine(coroutine);


    }

    private IEnumerator WaitBulletExpl(float waitTime, bool isBig)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            BulletExplosion(isBig);
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (!CheckLevelArea()) BulletExplosion(true);
    }

    private bool CheckLevelArea()
    {
        int levelProtoWidth = LevelManager.Instance.ActiveLevel.LevelPrototype.GetLength(1);
        int levelProtoHeight = LevelManager.Instance.ActiveLevel.LevelPrototype.GetLength(0);
        float blockSize = (float)LevelManager.Instance.ActiveLevel.GraphicBlockSize.x / 100;

        float _levelWidth = blockSize * (float)levelProtoWidth;
        float _levelHeight = blockSize * (float)levelProtoHeight;


        bool isLevelArea = transform.position.y > 0 & transform.position.x > 0;
        if (isLevelArea) isLevelArea = transform.position.y < _levelHeight & transform.position.x < _levelWidth;

        return isLevelArea;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        //Debug.Log($"{otherCollider.gameObject.name}");

        BasePiece piece;
        bool b = otherCollider.gameObject.TryGetComponent<BasePiece>(out piece);

        if (b)
        {
            BulletExplosion(otherCollider.gameObject.tag == "Enemy");

        }


    }

    private void BulletExplosion(bool isBigExpl)
    {

        BulletFinishRun_event?.Invoke();
        //gc.SetBulletRun(false);


        prefab_explosion.SetActive(true);
        prefab_explosion.GetComponent<Explosion>().StartExplosion(isBigExpl);

        Destroy(gameObject, 1f);
    }
}
