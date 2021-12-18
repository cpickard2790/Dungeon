using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // between frames
    private Vector3 moveDelta;
    public int speed = 1;
    private RaycastHit2D rc;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset the moveDelta, so new frames go back to 0
        moveDelta = new Vector3(x, y, 0);

        // swap sprite direction, whether going right or left
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rc = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0,
            new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
       
        if (rc.collider == null)
        {
            // Make character move
            transform.Translate(0, moveDelta.y * Time.deltaTime * speed, 0);
        }

        rc = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0,
            new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (rc.collider == null)
        {
            // Make character move
            transform.Translate(moveDelta.x * Time.deltaTime * speed, 0, 0);
        }
    }
}
