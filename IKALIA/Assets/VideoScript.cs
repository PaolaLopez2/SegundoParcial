using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoScript : MonoBehaviour {
    public RawImage rawimage;
    public VideoPlayer videoplayer;
    public AudioSource audio;


	// Use this for initialization
	void Start () {
        StartCoroutine(PlayVideo());
	}
	
	IEnumerator PlayVideo()
    {
        videoplayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoplayer.isPrepared)
        {
            yield return waitForSeconds;
            break;

        }

        rawimage.texture = videoplayer.texture;
        videoplayer.Play();
        audio.Play();
    }
}
