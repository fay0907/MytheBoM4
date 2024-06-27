using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrrorooowww : MonoBehaviour
{
    public static int AAAAA = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator death()
    {
        yield return new WaitForSeconds(0.5f);
        AAAAA++;
        Destroy(gameObject);
    }
}
