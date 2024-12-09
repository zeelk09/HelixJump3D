
using UnityEditor;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    Vector3 StartPos,direction;
    [SerializeField]
    float Speed;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        { 
            direction = StartPos - Input.mousePosition;
            this.gameObject.transform.Rotate(new Vector3(0,direction.x*Speed,0));
            StartPos = Input.mousePosition;
        }

    }
}
