using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabinstantiator : MonoBehaviour
{
    public GameObject enemyprefabtest;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newEnemyObject = Instantiate(enemyprefabtest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
