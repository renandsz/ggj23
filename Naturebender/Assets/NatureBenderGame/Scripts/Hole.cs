using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject treePrefab;
    public bool planted;
    public bool fertile;
    // Start is called before the first frame update
    void Start()
    {
        if (fertile) return;
        GameObject go =  Instantiate(treePrefab, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<Tree>().target = transform;
    }

    public void OpenHole()
    {
       // GetComponent<CircleCollider2D>().enabled = true;
        planted = false;
    }
    public void CloseHole()
    {
      //  GetComponent<CircleCollider2D>().enabled = false;
        planted = true;
    }

}
