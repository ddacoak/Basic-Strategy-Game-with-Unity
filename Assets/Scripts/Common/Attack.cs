using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    // attack range
    public float range = 5.0f;

    // helper variables to attack every few seconds
    public float interval = 1.5f;
    float intervalElapsed = 0.0f;

    // tag of the unit that should be attacked
    public string enemyTag = "";

    // arrow prefab (to shoot at enemies)
    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        intervalElapsed += Time.deltaTime;

        // ready for the next attack?
        if (intervalElapsed >= interval)
        {
            // attack any enemy unit that is close enough
            GameObject[] units = GameObject.FindGameObjectsWithTag(enemyTag);
            foreach (GameObject g in units)
            {
                // still alive?
                if (g != null)
                {
                    if (Vector3.Distance(g.transform.position, transform.position) <= range)
                    {
                        // look at the target
                        transform.LookAt(g.transform);

                        // create an arrow                        
                        GameObject a = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity); 

                        // set its target
                        a.GetComponent<Arrow>().target = g.transform;

                        // done for now
                        break;
                    }
                }
            }

            // reset interval
            intervalElapsed = 0.0f;
        }
    }
}