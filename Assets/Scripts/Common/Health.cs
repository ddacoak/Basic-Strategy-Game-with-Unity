using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int current = 4;

    public Color color = Color.red;

    // Update is called once per frame
    void Update()
    {
        // set 3d text to 
        TextMesh tm = GetComponentInChildren<TextMesh>();
        tm.text = new string('-', current);

        // set 3d text color
        tm.renderer.material.color = color;

        // facing the camera
        tm.transform.forward = Camera.main.transform.forward;
    }

    void LateUpdate()
    {
        // dead?     
        if (current <= 0)
        {
            Destroy(gameObject);
        }
    }
}