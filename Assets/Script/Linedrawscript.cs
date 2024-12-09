
using System.Collections.Generic;
using UnityEngine;

public class Linedrawscript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> CollectedObject;

    public static Linedrawscript instance;
    private void Awake()
    {
        instance = this;
    }
    public void GetClick(GameObject obj)
    { 
        CollectedObject.Add(obj);

        if (CollectedObject.Count == 2)
        { 
            DrawLibes();
            CollectedObject.Clear();
        }

    }

    private void DrawLibes()
    {
      LineRenderer ll = CollectedObject[0].AddComponent<LineRenderer>();

        ll.SetPosition(0, CollectedObject[0].transform.position);
        ll.SetPosition(1, CollectedObject[1].transform.position);


    }
}
