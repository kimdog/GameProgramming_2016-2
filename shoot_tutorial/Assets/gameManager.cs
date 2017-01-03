using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameManager : MonoBehaviour {

    public GameObject fpsPlayer;
    public GameObject human_target; // kill for start

    public Text m_Message;  // ui text

    private vrPersonController player_script;
    private bool isStartGame;

    // 0. machine start aduio
    // 1. ready BGM
    // 2. start game ternel BGM
    private AudioSource[] audio;

    public int score;

	// Use this for initialization
	void Start () {
        player_script = fpsPlayer.GetComponent<vrPersonController>();
        isStartGame = false;
        score = 0;

        audio = GetComponents<AudioSource>();

        // start BGM
        audio[1].Play();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(!isStartGame) {
            // m_Message.text = string.Empty;
            start_ui();
            startGame();
        }
        else
        {
            compute_score();  
        }
	}

    void startGame()
    {
        // if kill target, then start game.
        if (!human_target.activeSelf)
        {
            // play fisrt course
            player_script.course = 1;

            // play once
            isStartGame = true;

            // stop BGM, play new BGM
            audio[1].Stop();
            audio[2].Play();

            // play start audio
            audio[0].Play();
        }
    }

    void start_ui()
    {
        string msg;

        msg = "Score : ";
        msg += score;
        msg += "\n\n\n";
        msg += "Kill target to start GAME !!";
        msg += "\n\n";

        m_Message.text = msg;
    }

    void compute_score()
    {
        string msg;
        msg = "Score : ";
        msg += score;
        m_Message.text = msg;
    }
}
