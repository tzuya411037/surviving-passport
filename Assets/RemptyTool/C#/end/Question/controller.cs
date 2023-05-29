using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Threading;

public class controller : MonoBehaviour
{
    public const int AllQuestion = 3;
    int[] questionNumber = new int[AllQuestion];
    string[,] QandA = new string[AllQuestion, 5];
    int questionCount;
    int choose = 0;
    int wrongAnswer = 0;
    
    Text QNum;
    Text QText;
    Text C1;
    Text C2;
    Text C3;
    Text goN;
    Button btn1;
    Button btn2;
    Button btn3;
    Button btnNext;
    Button btnNext_2;
    RectTransform mask;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset txt = (TextAsset)Resources.Load("Q",typeof(TextAsset));
        //TextAsset txt = Resources.Load("Q") as TextAsset;
        string Qall = txt.text;
        txt = (TextAsset)Resources.Load("A", typeof(TextAsset));
        string Aall = txt.text;
        string[] QaS = Qall.Split('\n');
        string[] AaS = Aall.Split('\n');
        // FileStream fs = new FileStream("Q", FileMode.Open, FileAccess.Read, FileShare.None);
        // StreamReader Qsr = new StreamReader(fs, System.Text.Encoding.Default);
        // FileStream fs2 = new FileStream("A", FileMode.Open, FileAccess.Read, FileShare.None);
        // StreamReader Asr = new StreamReader(fs2, System.Text.Encoding.Default);

        System.Random ranNumObject = new System.Random();
        for(int i=0;i<AllQuestion;i++){
            questionNumber[i] = ranNumObject.Next(1, 46);
            bool redo = false;
            for(int j=0;j<i;j++){
                if(questionNumber[i]==questionNumber[j]){
                    redo = true;
                    break;
                }
            }
            if(redo) i--;
        }
        Array.Sort(questionNumber); 

        string str = "";
        int lineC = 45;
        string s = lineC.ToString();
        questionCount = 0;
        for (int id1=0;id1<45;id1++){    
            string[] xu = QaS[id1].Split(',');
            if(xu[0]==questionNumber[questionCount].ToString()){
                for(int i=0;i<4;i++){    
                    if(xu[i]==null) 
                        break;
                    else
                        QandA[questionCount, i] = xu[i+1];
                }
                for(int id2=0;;id2++){
                    string[] block = new String[2];
                    block = AaS[id2].Split(',');
                    if(block[0]==questionNumber[questionCount].ToString()){
                        QandA[questionCount, 4] = block[1];
                        break;
                    }
                }
                questionCount++;
            }
            if(questionCount==AllQuestion) break;
            if(xu[0]==s) break;
        }   

        questionCount = 1;
        QNum = GameObject.Find("第幾題").GetComponent<Text>();
        QText = GameObject.Find("題目").GetComponent<Text>();
        C1 = GameObject.Find("選項1").GetComponent<Text>();
        C2 = GameObject.Find("選項2").GetComponent<Text>();
        C3 = GameObject.Find("選項3").GetComponent<Text>();
        goN = GameObject.Find("Text").GetComponent<Text>();
        btn1 = GameObject.Find("Button_1").GetComponent<Button>();
        btn2 = GameObject.Find("Button_2").GetComponent<Button>();
        btn3 = GameObject.Find("Button_3").GetComponent<Button>();
        btnNext = GameObject.Find("Button_next").GetComponent<Button>();
        btnNext_2 = GameObject.Find("Button_next_2").GetComponent<Button>();
        mask = GameObject.Find("遮罩").GetComponent<RectTransform>();
        btn1.onClick.AddListener(Click1);
        btn2.onClick.AddListener(Click2);
        btn3.onClick.AddListener(Click3);
        btnNext.onClick.AddListener(ClickNext);
        btnNext_2.onClick.AddListener(ClickNext_2);
        show();
    }

    void show(){
        int index = questionCount-1;
        QNum.text = "Q"+questionCount.ToString()+":";
        QText.text = QandA[index, 0];
        C1.text = QandA[index, 1];
        C2.text = QandA[index, 2];
        Debug.Log(QandA[index, 3]);
        RectTransform t = GameObject.Find("選項3").GetComponent<RectTransform>();
        RectTransform te = GameObject.Find("Button_3").GetComponent<RectTransform>();
        if(QandA[index, 3]=="n"){
            t.anchoredPosition = new Vector2(-2000f, -2000f);
            te.anchoredPosition = new Vector2(-2000f, -2000f);
        }else{
            t.anchoredPosition = new Vector2(197.8f, -334.38f);
            te.anchoredPosition = new Vector2(-887f, -334.38f);
            C3.text = QandA[index, 3];
        }
    }
    void Click1(){
        mask.anchoredPosition = new Vector2(-887.0f, -35.0f);
        choose = 1;
    }
    void Click2(){
        mask.anchoredPosition = new Vector2(-887.0f, -184.69f);
        choose = 2;
    }
    void Click3(){
        mask.anchoredPosition = new Vector2(-887.0f, -334.38f);
        choose = 3;
    }
    void ClickNext_2(){
        RectTransform Cmask = GameObject.Find("正確遮罩").GetComponent<RectTransform>();
        RectTransform Wmask = GameObject.Find("錯誤遮罩").GetComponent<RectTransform>();
        Cmask.anchoredPosition = new Vector2(2000f, 2000f);
        Wmask.anchoredPosition = new Vector2(2000f, 2000f);
        RectTransform t = GameObject.Find("Button_next").GetComponent<RectTransform>();
        RectTransform te = GameObject.Find("Button_next_2").GetComponent<RectTransform>();
        Vector2 temp = te.anchoredPosition;
        te.anchoredPosition = t.anchoredPosition;
        t.anchoredPosition = temp;

        questionCount++;
        mask.anchoredPosition = new Vector2(-2000f, -2000f);
        choose = 0;
        if(questionCount>3){
            if(wrongAnswer>=2)
                SceneManager.LoadScene("FlunkE");
            else
                SceneManager.LoadScene("EndE");
        }else{
            if(questionCount==3){
                goN.text = "Submit";
            }
            show();
        }
        btn1.enabled = true;
        btn2.enabled = true;
        btn3.enabled = true;
    }
    Vector2 Pos(int i){
        if     (i==1) return new Vector2(197.8f, -35.0f);
        else if(i==2) return new Vector2(197.8f, -184.69f);
        else if(i==3) return new Vector2(197.8f, -334.38f);
        return new Vector2(2000f, 2000f);
    }
    void ClickNext(){
        if(choose==0) return;
        if(choose.ToString()!=QandA[questionCount-1, 4]){
            wrongAnswer++;
        }
        RectTransform Cmask = GameObject.Find("正確遮罩").GetComponent<RectTransform>();
        RectTransform Wmask = GameObject.Find("錯誤遮罩").GetComponent<RectTransform>();
        Cmask.anchoredPosition = Pos(Convert.ToInt32(QandA[questionCount-1, 4]));
        Wmask.anchoredPosition = Pos(choose);
        RectTransform t = GameObject.Find("Button_next").GetComponent<RectTransform>();
        RectTransform te = GameObject.Find("Button_next_2").GetComponent<RectTransform>();
        Vector2 temp = te.anchoredPosition;
        te.anchoredPosition = t.anchoredPosition;
        t.anchoredPosition = temp;
        btn1.enabled = false;
        btn2.enabled = false;
        btn3.enabled = false;
    }
}