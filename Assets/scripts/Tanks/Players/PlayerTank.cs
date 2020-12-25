using System;
using UnityEngine;

class PlayerTank : BaseTank
{
    AudioSource audioMoving;
    public bool FirstPlayer { get; private set; } = false;


    protected override void Init()
    {
        base.Init();
        audioMoving = GetComponent<AudioSource>();
    }

    public void SetFirst(bool isFirst) => FirstPlayer = isFirst;

    private void Start()
    {
        Init();

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);


        if (Vector3.Distance(transform.position, targetPosition) < 0.0001f) isMoving = false;

        if (isMoving) audioMoving.Play();

    }

    private void FixedUpdate()
    {
        step = Speed * Time.fixedDeltaTime; // calculate distance to move
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
    }

   

}

