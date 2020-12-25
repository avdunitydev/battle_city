using UnityEngine;

class GameManager : Singleton<GameManager>
{

    private void StartLevel(int levelNumber)
    {
        LevelManager.Instance.InstantiateLevel(levelNumber);

    }



    private void Awake()
    {
               StartLevel(1);


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  
}
