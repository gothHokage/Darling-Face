using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Bag : MonoBehaviour
{

    public GameObject Baggy;
    public GameObject Mono;
    public bool BagIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && BagIsOpen == false)
        {
            Baggy.SetActive(true);
            BagIsOpen = true;
            
        }
        
    }


}
