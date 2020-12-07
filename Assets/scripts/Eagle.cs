using UnityEngine;

class Eagle : MonoBehaviour
{
    public Sprite[] sprites;
    public bool isAlive = true;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

}