
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    [SerializeField]
    float Speed;
    [SerializeField]
    float Offset;
    Vector3 StartPos, EndPos;

    private void Update()
    {
        if (Target.gameObject.transform.position.y < this.transform.position.y - Offset)
        {
            StartPos =transform.position;
           EndPos =new Vector3(this.transform.position.x, this.transform.position.y - 2, this.transform.position.z);
            this.transform.position = Vector3.Lerp(StartPos,EndPos,Speed);
        }
    }

    

}
