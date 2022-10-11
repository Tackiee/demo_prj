using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource;
    public Button playButton;
    public Button stopButton;
    public Text TimerText;
    public SerialReceive SR;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        playButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(true);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        showTime();
        if (SR.input_check == false)
        {
            playButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            audioSource.UnPause();
        }

        if (SR.input_check == true)
        {   playButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            audioSource.Pause();
        }
    }

    string Str(float length)
    {
        int len = (int)length;
        int min = len / 60;
        int sec = len % 60;

        return $"{min}:{sec.ToString("D2")}";
    }

    void showTime()
    {
        string s1 = Str(audioSource.time);
        string s2 = Str(audioSource.clip.length);
        //Debug.Log($"{s1}/{s2}");
        TimerText.text = s1 + "/" + s2;
    }

    public void playtoStopmusic() //再生マークだけど、機能は一時停止
    {
            playButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            audioSource.Pause();
    }

    public void stopToPlaymusic() //停止マークだけど、機能は再生
    {
            playButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            audioSource.Play();
    }
}
