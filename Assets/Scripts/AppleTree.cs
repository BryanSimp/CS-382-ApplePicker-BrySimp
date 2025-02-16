using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject anvilPrefab;

    public float speed = 2f;

    public float lefAndRightEdge = 10f;

    public float changeDirChance = 0.01f;

    public float dangerChance = 0.2f;

    public float dropDelay = 2f;
    public float dropCount = 0f;
    public Rounds rounds;
    void Start()
    {
        //Start Dropping apples
        Invoke("DropStuff", 2f);
        GameObject roundGO = GameObject.Find("Rounds");
        rounds = roundGO.GetComponent<Rounds>();
    }

    void DropStuff(){
        if (Random.value > dangerChance){
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }else{
            GameObject anvil = Instantiate<GameObject>(anvilPrefab);
            anvil.transform.position = transform.position;
        }
        
        dropCount += 1f;
        if(dropCount > 10f){
            dropCount = 0f;
            RoundIncrease();
        }
        Invoke ("DropStuff", dropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if( pos.x < -lefAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if ( pos.x > lefAndRightEdge ){
            speed = -Mathf.Abs(speed);
        }else if (Random.value < changeDirChance){
            speed *= -1;
        }
    }

    void RoundIncrease(){
        rounds.level += 1;
        dropDelay *= 0.9f;
        dangerChance *= 1.1f;
    }
    
}
