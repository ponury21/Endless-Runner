using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class UIManager : MonoBehaviour
{

    public Text ScoreText, StatusText;

    public GameObject Menu, GameOver, Pause;
    //public Button NewGameButton;
    public int i=0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
 
            return instance;
        }
    }
 
    protected UIManager()
    {
    }
 
    private float score = 0;
 
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
 
    public void SetScore(float value)
    {
        score = value;
        UpdateScoreText();
    }
 
    public void IncreaseScore(float value)
    {
        if(GameManager.Instance.GameState==GameState.Playing)
        score += value;
        UpdateScoreText();
        
    }
 
    private void UpdateScoreText()
    {
        ScoreText.text = score.ToString();
    }
 
    public void SetStatus(string text)
    {
        StatusText.text = text;
    }
    public void newGame(){
        SceneManager.LoadScene("game");
    }
    public void menuReturn(){
        SceneManager.LoadScene("MainMenu");
    }
    public void hideUI(){
        Vector3 pos=Menu.transform.position;
        pos.y=2000f;
        Menu.transform.position=pos;
       // NewGameButton.gameObject.SetActive(false);
    }
    public void showUIDead(){
        Vector3 pos=Menu.transform.position,pos1=Menu.transform.position;
        pos.y=500f;
        pos1.y=2000f;
        Menu.transform.position=pos;
        Pause.transform.position=pos1;
        GameOver.transform.position=pos;
       // NewGameButton.gameObject.SetActive(true);
    }
    public void showUIPause(){
        Vector3 pos=Menu.transform.position,pos1=Menu.transform.position;
        pos.y=500f;
        pos1.y=2000f;
        Menu.transform.position=pos;
        GameOver.transform.position=pos1;
       // NewGameButton.gameObject.SetActive(true);
    }

}

