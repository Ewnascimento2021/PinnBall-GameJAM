using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public int scoreAtual;
    public int scoreRecord;
    public string nomeDaCena;

    [SerializeField]
    private TMP_Text textPoint;
    [SerializeField]
    private TMP_Text textRecord;

    [SerializeField]
    private AudioSource gatilho;

    static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }
    public bool isRightTriggerPressed;
    public bool isLeftTriggerPressed;
    public bool isGameStarted;
    public bool isTeleporting;

    public float lastTimeStamp;
    private float timerSpeed = 3f;
    private void Start()
    {
        
        scoreAtual = 0;
        nomeDaCena = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey (nomeDaCena + "score"))
        {
            scoreRecord = PlayerPrefs.GetInt(nomeDaCena + "score");
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("LTrigger")|| Input.GetButtonDown("RTrigger"))
            gatilho.Play();
        if(Input.GetAxisRaw("LTrigger") == 1)
        {
            isLeftTriggerPressed = true;
        }
        else
        {
            isLeftTriggerPressed = false;
        }
        if (Input.GetAxisRaw("RTrigger") == 1)
        {
            isRightTriggerPressed = true;
        }
        else
        {
            isRightTriggerPressed = false;
        }
        if (isTeleporting)
        {
            TeleportTimer();
        }
        ChecarScore();
        textPoint.text = $"Score: {scoreAtual}";
        textRecord.text = $"Recorde: {scoreRecord}";

            
    }
    void ChecarScore()
    {
        if(scoreAtual > scoreRecord)
        {
            scoreRecord = scoreAtual;
            PlayerPrefs.SetInt(nomeDaCena + "score", scoreRecord);
        }
    }
    private void TeleportTimer()
    {
        if ((Time.time - lastTimeStamp >= timerSpeed))
        {
            isTeleporting = false;
        }
    }
}
