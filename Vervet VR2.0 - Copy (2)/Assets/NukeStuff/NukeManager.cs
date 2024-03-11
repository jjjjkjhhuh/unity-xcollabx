using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NukeManager : MonoBehaviour
{

    Vector3 startPosition;

    [Header("Made By Whalemert GIVE CREDITS!")]
    [Header("https://discord.gg/qk6YS7MBnx")]

    public AudioSource Prenukemsg;
    public GameObject Prenuke;
    public GameObject NukeeventOBJ;
    public GameObject OldPostProcessing;
    public AudioSource CountDownSound;
    public TextMeshProUGUI CountdownText;
    public GameObject Music;
    public GameObject spawnmap;

    [Header("Timer Section")]
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    [Header("TP Section")]
    public GameObject GorillaPlayer;
    public GameObject TeleportTo;
    public Collider[] CollidersToDisable;
    public float DisableTime;

    [Header("Nuke Section")]
    public GameObject NukeOBJ;
    public AudioSource Explosion;
    public GameObject ExplosionEffect;
    public float NukeAnimTime;
    public float ExplosionTime;
    public float CancelNukeTime;

    void Start()
    {
        Prenukeevent();
    }


    public void Prenukeevent()
    {
        Music.SetActive(false);
        spawnmap.SetActive(true);
        Prenuke.SetActive(true);
        startPosition = NukeOBJ.transform.position;
        Prenukemsg.Play(0);
        OldPostProcessing.SetActive(false);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        CountDownSound.Play(0);
        timerIsRunning = true;
        foreach (Collider collider in CollidersToDisable)
        {
            collider.enabled = false;
        }

        GorillaPlayer.transform.position = TeleportTo.transform.position;

        StartCoroutine(EnableCollidersAfterDelay());

        yield return new WaitForSeconds(15);
        CountDownSound.Stop();
        StartCoroutine(NukeEvent());
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        CountdownText.text = string.Format("" + seconds);
    }

    private IEnumerator NukeEvent()
    {
        NukeeventOBJ.SetActive(true);
        NukeOBJ.SetActive(true);
        yield return new WaitForSeconds(NukeAnimTime);
        NukeOBJ.transform.position = startPosition;
        NukeOBJ.SetActive(false);
        Explosion.Play(0);
        ExplosionEffect.SetActive(true);
        yield return new WaitForSeconds(ExplosionTime);
        ExplosionEffect.SetActive(false);
        yield return new WaitForSeconds(CancelNukeTime);
        NukeeventOBJ.SetActive(false);
        Prenuke.SetActive(false);
        Music.SetActive(true);
        OldPostProcessing.SetActive(true);
    }

    private IEnumerator EnableCollidersAfterDelay()
    {
        yield return new WaitForSeconds(DisableTime);

        foreach (Collider collider in CollidersToDisable)
        {
            collider.enabled = true;
        }
    }
}
