using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject shadow;
    public Transform target;
    public int lerpSpeed;
    public bool cured,ready;

    public Sprite trunk, floatingTrunk, tree,floatingTree;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out spriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null) 
        {

            if (ready)
            {
                if (Vector3.Distance(transform.position, target.position) <= 0.001f)
                {
                    Destroy(GetComponent<CircleCollider2D>());
                    Destroy(this);
                }
                
            }
        }
            transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);

    }
    public void Levitate()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        if(!cured)
            spriteRenderer.sprite = floatingTrunk;
        else
        {
            spriteRenderer.sprite = floatingTree;
            ready = true;
        }
            
        shadow.SetActive(true);

    }
    public void Plant()
    {
        shadow.SetActive(false);
        GetComponent<CircleCollider2D>().enabled = true;
        if (target.GetComponent<Hole>().fertile)
        {
            spriteRenderer.sprite = tree;
            cured = true;
        }
        else
        {
            if (!cured)
                spriteRenderer.sprite = trunk;
            else
            {
                spriteRenderer.sprite = tree;                
            }
                
        }
    }
}
