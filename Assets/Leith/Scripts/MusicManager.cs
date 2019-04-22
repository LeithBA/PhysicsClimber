using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip musicStartClip;
    public AudioClip musicLoopClip;

    public Button muteButton;

    public Sprite on, off;
    AudioSource AS;
    GameState GS;
    void Start()
    {
        GetComponent<AudioSource>().loop = true;
        AS = transform.GetComponent<AudioSource>();
        GS = GameObject.Find("GameManager").GetComponent<GameState>();
        StartCoroutine(playMusic());
    }

    void LateUpdate()
    {
        if (muteButton == null && GS.inMenu == true)
        {
            muteButton = GameObject.Find("MuteMusic").GetComponent<Button>();
            if (AS.mute == true)
                muteButton.GetComponent<Image>().sprite = off;

            else if (AS.mute == false)
                muteButton.GetComponent<Image>().sprite = on;
        }

    }

    IEnumerator playMusic()
    {
        AS.clip = musicStartClip;
        AS.Play();
        yield return new WaitForSeconds(AS.clip.length);
        AS.clip = musicLoopClip;
        AS.loop = true;
        AS.Play();
    }

    public void Mute()
    {
        AS.mute = !AS.mute;
        if (AS.mute == true)
            muteButton.GetComponent<Image>().sprite = off;

        else if (AS.mute == false)
            muteButton.GetComponent<Image>().sprite = on;
    }
}
