using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarmentInfoUI : MonoBehaviour
{
    public Canvas garmentInfoCanvas;
    public Image targetImage; 
    // public Sprite ShirtSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GarmentSelected(Sprite _sprite){
        garmentInfoCanvas.enabled = true;
        targetImage.sprite = _sprite;
    }

    public void GarmentExit(){
        garmentInfoCanvas.enabled = false;
    }
}
