using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{
  //  SpriteRenderer m_SpriteRenderer;
  //  m_SpriteRenderer = GetComponent<SpriteRenderer>();
    private healthManager help;
    private Basic boterhamworst;
    float attackspeed = 50f;
    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        boterhamworst = FindObjectOfType<Basic>();
        help = FindObjectOfType<healthManager>();
    }
    void SetTransformX(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }
    float timePassed = 0f;
    void Update()
    {
        //Debug.Log("attackspeed is " + attackspeed);
        //Debug.Log("attackspeed is " + attackspeed);
       // Debug.Log("timepassed is " + timePassed);
        
            
        
        timePassed += Time.deltaTime;
        //Debug.Log(timePassed);
        if (timePassed > attackspeed)
        {
            //Debug.Log("piss");
            //Debug.Log("holy shit hij werkt");
            timePassed = 0f;
            boterhamworst.Kill();
        }



        
            
            
        
       // Debug.Log("mijn state is " + state + " en timePassed is " +  timePassed);
    }

    // Update is called once per frame


    public void Change()
    {
        if (state == 0)
        {
            SetTransformX(transform.position.y+10f);
            
            // transform.position = Lavafloor.transform.position;
            state = 1;
            attackspeed = 1.5f;
        } else if (state == 1)
        {
            
            attackspeed = 1.0f;
            state = 2;
        }
        else if (state == 2)
        {
            attackspeed = 0.5f;
            state = 3;
        } else 
        {
            
        }
        
    }


   
            

}
