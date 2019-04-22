using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertOnClick : MonoBehaviour
{
    InvertMatCol IMC;

    // Use this for initialization
    void Start()
    {
        IMC = GameObject.Find("GameManager").GetComponent<InvertMatCol>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { IMC.InvertMenu(); IMC.Invert();});
    }
    // Update is called once per frame
    void Update()
    {

    }
}
