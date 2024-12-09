
using UnityEngine;

public class mouseAction : MonoBehaviour
{
    private void OnMouseUp()
    {
        Linedrawscript.instance.GetClick(this.gameObject);
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
}
