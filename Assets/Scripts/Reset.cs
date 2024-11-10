using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject Shirt;
    public GameObject Pants;

    public GameObject Shirt_yellow;
    public GameObject Pants_yellow;

    public GameObject Shirt_formal;
    public GameObject Pants_formal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBtnPressed(){
        Shirt.SetActive(false);
        Pants.SetActive(false);
        Shirt_yellow.SetActive(false);
        Pants_yellow.SetActive(false);
        Shirt_formal.SetActive(false);
        Pants_formal.SetActive(false);
    }
}
