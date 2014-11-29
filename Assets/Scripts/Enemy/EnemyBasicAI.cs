using UnityEngine;
using System.Collections;

public class EnemyBasicAI : MonoBehaviour {

    // declare states
    public enum StatesEnemy { DOWN, UP, ATTACK }

    public StatesEnemy state;

    private float currentTime;
    public float currentTimeIni;

    // Use this for initialization
    void Start()
    {
        setUp();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case StatesEnemy.UP:
                UpBehaviour();
                break;

            case StatesEnemy.DOWN:
                DownBehaviour();
                break;

            case StatesEnemy.ATTACK:
                AttackBehaviour();
                break;
        }
    }

    // SETS
    private void setUp()
    {
        // start counter
        currentTime = currentTimeIni;
        // change state
        state = StatesEnemy.UP;
    }

    private void setDown()
    {
        // start counter
        currentTime = currentTimeIni;
        // change state
        state = StatesEnemy.DOWN;
    }

    // BEHAVIOURS 
    private void UpBehaviour()
    {
        // decrement counter
        currentTime -= Time.deltaTime;
        // goes up
        transform.Translate(Time.deltaTime * 1.5f, 0, 0);

        // goes down when counter < 0
        if (currentTime < 0)
        {
            setDown();
        }
    }

    private void DownBehaviour()
    {
        // decrement counter
        currentTime -= Time.deltaTime;
        // goes down
        transform.Translate(Time.deltaTime * -1.5f, 0, 0);

        // gows up when counter <0
        if (currentTime < 0)
        {
            setUp();
        }
    }

    private void AttackBehaviour()
    { 
        
    }
}
