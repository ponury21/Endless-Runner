using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;
using System;


    public class UIManager : MonoBehaviour
{

    public Text ScoreText, StatusText;
    public string PlayerName;
    public TextAsset textFile;
     public TextAsset nameFile;
    int[] scoreArray=new int [10];
    string[] nameArray=new string[10];
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;
    public GameObject Menu, GameOver, Pause,EnterNameMenu,NameInput,HighScores, ContinueBtn;
    //public GameObject[] highScoreTxt;
    public Text[] highScoreTxt;
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
 
    private int score = 0;
 
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

 
    public void SetScore(int value)
    {
        score = value;
        UpdateScoreText();
    }
 
    public void IncreaseScore(int value)
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
    public void SetName(string text){
        PlayerName=text;
    }
    public void newGame(){
        SceneManager.LoadScene("game");
    }
    public void startGame(){
        GameManager.Instance.Play();
    }
    public void Continue(){
        showUIDead();
    }
    public void menuReturn(){
        SceneManager.LoadScene("MainMenu");
    }
    public void hideUI(){
        Vector3 pos=Menu.transform.position;
        pos.y=2000f;
        Menu.transform.position=pos;
        EnterNameMenu.transform.position=pos;
       // NewGameButton.gameObject.SetActive(false);
    }
    public void showUIDead(){
        
        Vector3 pos=Menu.transform.position,pos1=Menu.transform.position;
        pos.y=500f;
        pos1.y=2000f;
        Menu.transform.position=pos;
        Pause.transform.position=pos1;
        GameOver.transform.position=pos;
        HighScores.transform.position=pos1;
        
       // NewGameButton.gameObject.SetActive(true);
    }
    public void showUIStart(){
        Vector3 pos=EnterNameMenu.transform.position;
        pos.y=500f;
        EnterNameMenu.transform.position=pos;
    }
    public void showHighScores(){
        highScoresFile();
        fillHighScoresTxt();
        Vector3 pos=HighScores.transform.position;
        pos.y=500f;
        HighScores.transform.position=pos;
    }
    public void fillHighScoresTxt(){
        for(int x=0;x<highScoreTxt.Length;x++){
            highScoreTxt[x].text=x.ToString()+" . "+nameArray[x]+" : "+scoreArray[x];
        }
    }
    public void showUIPause(){
        Vector3 pos=Menu.transform.position,pos1=Menu.transform.position;
        pos.y=500f;
        pos1.y=2000f;
        Menu.transform.position=pos;
        GameOver.transform.position=pos1;
       // NewGameButton.gameObject.SetActive(true);
    }
    public void highScoresFile(){
        for(int z=0;z<10;z++){
            scoreArray[z]=0;
        }
         string serializedData="";
         string pathscores=Application.dataPath + "/Scripts/scores.txt";
         string pathnames=Application.dataPath + "/Scripts/names.txt";
        theWholeFileAsOneLongString = textFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]) );
        for(int z=0;z<10;z++){
            scoreArray[z]=int.Parse(eachLine[z]);
        }
        theWholeFileAsOneLongString = nameFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]) );
        for(int z=0;z<10;z++){
            nameArray[z]=eachLine[z];
        }


        for(int x=0;x<10;x++){
            if(scoreArray[x]<score){
                for(int z=8;z>x;z--){
                    scoreArray[z]=scoreArray[z-1];
                    nameArray[z]=nameArray[z-1];
                }
                scoreArray[x+1]=scoreArray[x];
                scoreArray[x]=score;
                nameArray[x+1]=nameArray[x];
                nameArray[x]=PlayerName;
                x=10;
            }
        }
        for(int x=0;x<10;x++){
                serializedData=serializedData+scoreArray[x].ToString()+"\n";
            }
        File.WriteAllText(pathscores,serializedData);
        serializedData="";
        for(int x=0;x<10;x++){
                serializedData=serializedData+nameArray[x]+"\n";
            }
            File.WriteAllText(pathnames,serializedData);
    }

}

