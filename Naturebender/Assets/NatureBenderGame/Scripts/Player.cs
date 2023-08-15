using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    public bool busy;
    public Transform floatingTarget;
    public Tree treeTarget;
    public Hole holeTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            
            collision.TryGetComponent(out treeTarget);
            
        }

        if (collision.CompareTag("Hole"))
        {
            collision.TryGetComponent(out holeTarget);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            if(!busy)
            treeTarget = null;
            
        }

        if (collision.CompareTag("Hole"))
        {
           
            holeTarget = null;
            
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 inputVector = new Vector3(x, y, 0);
        transform.position = transform.position + inputVector.normalized * speed * Time.deltaTime;

    }


    void FloatingWaypoint()
    {
        floatingTarget.RotateAround(transform.position, Vector3.forward, 90 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FloatingWaypoint();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!busy)
            {
                if (treeTarget)
                {
                    
                        busy = true;
                    holeTarget = treeTarget.target.GetComponent<Hole>();
                        holeTarget.OpenHole();
                        treeTarget.target = floatingTarget;
                        treeTarget.Levitate();
                    
                }              
            }
            else
            {
                if (treeTarget)
                {
                    if (holeTarget != null)
                    {
                                               
                        treeTarget.target = holeTarget.transform;
                        holeTarget.CloseHole();
                        treeTarget.Plant();
                        busy = false;
                    }
                }
            }
        }
            
                
         
       
    }
}
