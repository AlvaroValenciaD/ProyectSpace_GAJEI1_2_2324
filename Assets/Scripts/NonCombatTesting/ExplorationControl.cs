using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rb;
    public float v, h;
   public float speed;
    public float runSpeed;
    public bool upTrue;
    public bool downTrue;
    public bool leftTrue;
    public bool rightTrue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical") * -1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(v, 0, h) * runSpeed * Time.deltaTime);
           
        }
        else
        {
             transform.Translate(new Vector3(v, 0, h) * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {


        }
    }
}
