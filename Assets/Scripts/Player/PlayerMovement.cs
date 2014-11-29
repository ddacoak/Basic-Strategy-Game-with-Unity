using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float floorOffset = 1;

    public float moveSpeed;	

    private Transform myTransform;				// this transform
    private Vector3 destinationPosition;		// The destination Point
    private float destinationDistance;			// The distance between myTransform and destinationPosition

    void Start()
    {
        myTransform = transform;							// sets myTransform to this GameObject.transform
        destinationPosition = myTransform.position;			// prevents myTransform reset
    }
    
    // Update is called once per frame
    void Update()
    {
        // keep track of the distance between this gameObject and destinationPosition
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (destinationDistance < 1.5f)
        {		// To prevent shakin behavior when near destination
            moveSpeed = 0;
        }
        else if (destinationDistance > 1.5f)
        {			// To Reset Speed to default
            moveSpeed = 3;
        }

        // Moves the Player if the Right Mouse Button was clicked
        if (Input.GetMouseButtonDown(1) && isSelected() && GUIUtility.hotControl == 0)
        {

            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
        }

        // To prevent code from running if not needed
        if (destinationDistance > .5f)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
        }
    }

    // Find out if its selected (if the selection circle is visible)
    bool isSelected()
    {
        MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in children)
        {
            if (r.gameObject.name == "SelectionCircle" && r.enabled)
            {
                return true;
            }
        }
        return false;
    }
}