using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    public TMP_Text timer;
    public TMP_Text keystxt;
    public Animator doorAnim;

    public GameObject door;
    public GameObject winnerPan;
    public GameObject loserPan;

    public float timeToLose;
    public bool isOpen;
    public bool isWin;

    private void Start()
    {
        playerController.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timeToLose = timeToLose - Time.deltaTime;

        keystxt.text = "Keys: " + playerController.keys.ToString("F0") + "/6";
        timer.text = "Time to lose: " + timeToLose.ToString("F0");

        if (isOpen) doorAnim.Play("Door_Anim");
        if (timeToLose <= 0) loserPan.SetActive(true);
        if (isWin) winnerPan.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
