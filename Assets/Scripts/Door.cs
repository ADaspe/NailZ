using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    public int nailCounter;
    public bool plankOrNot;
    private SpriteRenderer sr;
    public Sprite doorSprite;
    public Sprite blockedDoorSprite;
    [SerializeField]
    public GameObject zombieSpawn;
    [SerializeField]
    List<GameObject> spawns;
    [SerializeField]
    public int minTimeSpawn;
    [SerializeField]
    public int maxTimeSpawn;
    int timeSpawn;
    public int nbrZombie;
    public bool needToSpawn;

    public ScoreScript score;
    

    // Start is called before the first frame update
    void Start()
    {
        nailCounter = 0;
        nbrZombie = 1;
        plankOrNot = false;
        sr = GetComponent<SpriteRenderer>();
        needToSpawn = true;
        minTimeSpawn = score.minTimeSpawn;
        maxTimeSpawn = score.maxTimeSpawn;
        
    }

    private void Update()
    {
        if (needToSpawn)
        {
            needToSpawn = false;
            StartCoroutine(Spawn());

        }
        
    }
    IEnumerator Spawn()
    {

        timeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        yield return new WaitForSeconds(timeSpawn);
        if (nbrZombie >= nailCounter) { 
            SpawnZombie(nbrZombie);
        }
        else
        {
            nbrZombie++;
        }
        needToSpawn = true;
    }
    public void SpawnZombie(int nbrZombieToSpawn)
    {
        sr.sprite = doorSprite;
        switch (nbrZombie) {
            case 1:
                GameObject zombie = Instantiate(zombieSpawn);
                zombie.transform.position = spawns[1].transform.position;
                break;
            case 2:
                GameObject zombie1 = Instantiate(zombieSpawn);
                GameObject zombie2 = Instantiate(zombieSpawn);
                zombie1.transform.position = spawns[0].transform.position;
                zombie2.transform.position = spawns[2].transform.position;
                break;
            case 3:
                GameObject zombie4 = Instantiate(zombieSpawn);
                GameObject zombie5 = Instantiate(zombieSpawn);
                GameObject zombie6 = Instantiate(zombieSpawn);
                zombie4.transform.position = spawns[0].transform.position;
                zombie5.transform.position = spawns[1].transform.position;
                zombie6.transform.position = spawns[2].transform.position;
                break;
                
        }
        nbrZombie = 1;
        nailCounter = 0;

        plankOrNot = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Plank"))
        {
            
            if (!plankOrNot)
            {
                plankOrNot = true;
                if(sr.sprite.Equals(doorSprite))
                {
                    sr.sprite = blockedDoorSprite;
                }
                Destroy(collision.gameObject);
            }
            ScoreScript.fermePorte = ScoreScript.fermePorte + 400;
        } else if (collision.CompareTag("Clou") && plankOrNot && nailCounter<3)
        {
            nailCounter++;
            ScoreScript.clouPorte = ScoreScript.clouPorte + 75;
        }

    }

    
      

}
