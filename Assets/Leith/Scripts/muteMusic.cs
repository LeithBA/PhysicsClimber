using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteMusic : MonoBehaviour
{
    MusicManager MM;

    void Awake()
    {
        MM = GameObject.Find("GameManager").GetComponent<MusicManager>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MM.Mute();});
    }
}
