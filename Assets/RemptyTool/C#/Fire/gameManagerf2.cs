using System.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class gameManagerf2 : MonoBehaviour
{
    static gameManagerf2 fire2GM;
    public GameObject GM;
    public joyStickf2 jsMovement;

    public int clear = 0;
    public float HP = 100;

    Transform playerTransform;
    GameObject HPobj;
    GameObject player;
    GameObject controller;
    GameObject enterButton;
    GameObject backButton;
    GameObject button;
    GameObject leftButton;
    GameObject rightButton;
    GameObject messanger;
    PointerEventData ped;

    int nowFloor = 7;
    GameObject[,,] doorsList = new GameObject[2, 17, 3];
    bool[,] doorsOpen = new bool[10, 17];
    GameObject whiteCigarette;
    GameObject blackCigarette;
    GameObject firePic;
    GameObject[] showFloor = new GameObject[10];

    string nowSceneName = " ";
    int messangerNum;
    bool start = false;
    bool checkDoor = false;
    bool nowCrawl = false;
    int lastInDoor = -1;
    bool wentRoom0 = false;
    bool wentUnder5 = false;

    void Awake()
    {//設定此管理物件，必須唯一
        if(fire2GM==null){
            fire2GM = this;
            DontDestroyOnLoad(this);
        }else if(fire2GM!=this){
            Destroy(gameObject);
        }
    }

    void Start()
    {// Start is called before the first frame update
        //抓通用物件
        HPobj = GameObject.Find("HP2");
        Debug.Log(HPobj.name);
        player = GameObject.Find("player");
        playerTransform = player.GetComponent<Transform>();
        controller = GameObject.Find("joyStick");
        messanger = GameObject.Find("messanger");
        enterButton = GameObject.Find("enterButton");
        backButton = GameObject.Find("backButton");
        button = GameObject.Find("Button");
        leftButton = GameObject.Find("leftButton");
        rightButton = GameObject.Find("rightButton");

        //繼承前關血量
        GM = GameObject.Find("遊戲控制器");
        if(GM!=null){
            HP = GM.GetComponent<gameManager>().HP;
            Destroy(GameObject.Find("遊戲控制器"));
            updateHP();
        }

        //buttons開監聽
        Button messangerBtn = messanger.transform.GetChild(1).gameObject.GetComponent<Button>();
        messangerBtn.onClick.AddListener(closeMessanger);
        messangerBtn = messanger.transform.GetChild(2).gameObject.GetComponent<Button>();
        messangerBtn.onClick.AddListener(messangerBtn2);
        enterButton.GetComponent<Button>().onClick.AddListener(enterButtonFunc);
        backButton.GetComponent<Button>().onClick.AddListener(goBackFunc);
        button.GetComponent<Button>().onClick.AddListener(buttonFunc);
        leftButton.GetComponent<Button>().onClick.AddListener(leftButtonClick);
        rightButton.GetComponent<Button>().onClick.AddListener(rightButtonClick);

        //隱藏UI
        button.SetActiveRecursively(false);
        messanger.SetActiveRecursively(false);
        enterButton.SetActiveRecursively(false);
        backButton.SetActiveRecursively(false);
        leftButton.SetActiveRecursively(false);
        rightButton.SetActiveRecursively(false);

        //顯示初始訊息
        messangerNum = 0;
        showMessanger();
        button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "call 119";
    }

    int getSceneIdex()
    {//用場景名稱回傳場景index 
        int index = -1;
        if(nowSceneName.Length==9){
            // Room 0 ~ 9
            index = 0 + nowSceneName[9-1] - 48;
        }
        else if(nowSceneName.Length==10){
            // Room 10 ~ 16
            index = 10 + nowSceneName[10-1] - 48;
        }
        else if(nowSceneName==" " || nowSceneName=="Firecorridor"){
            // other but in fire2
            index = -1;
        }
        else{
            // other what i dont want
            index = -5;
        }
        return index;
    }

    void GetSceneObject(string sceneName)
    {//抓取場景特定的物件，及場景的初次設定
        if(sceneName==null) return;
        else if(sceneName=="Firecorridor"){
            for(int i=0;i<17;i++){
                for(int j=1;j<=3;j++){
                    GameObject fatherObj = GameObject.Find("door"+i.ToString());
                    doorsList[0,i,j-1] = fatherObj.transform.GetChild(j).gameObject;
                }
            }
        }
        else if(sceneName=="Fireroom0"){
            GameObject floors = GameObject.Find("floors");
            for(int i=1;i<=9;i++){
                showFloor[i] = floors.transform.GetChild(i-1).gameObject;
                showFloor[i].SetActiveRecursively(false);
            }
            whiteCigarette = GameObject.Find("白煙");
            blackCigarette = GameObject.Find("黑煙");
            firePic = GameObject.Find("火");
            playerTransform.position = Vector2.zero;
            player.SetActiveRecursively(false);
            controller.GetComponent<joyStickf2>().OnPointerUp(ped);
            controller.SetActiveRecursively(false);
            leftButton.SetActiveRecursively(true);
            rightButton.SetActiveRecursively(true);
            backButton.SetActiveRecursively(true);
            for(int i=1;i<=9;i++){
                doorsOpen[i, 0] = true;
            }
        }
        else{
            int index = getSceneIdex();
            for(int i=1;i<=3;i++){
                GameObject fatherObj = GameObject.Find("door");
                doorsList[1,index,i-1] = fatherObj.transform.GetChild(i).gameObject;
            }
        }
    }

    void Update()
    {//持續呼叫
        //若不是火災相關場景，什麼都不做
        int tempSceneIndex = getSceneIdex();
        if(tempSceneIndex<-1 || tempSceneIndex>16 || SceneManager.GetActiveScene().name[0]!='F'){
            return;
        }

        //檢查要不要持續扣血
        punish(-1);

        //鏡頭永遠跟蹤
        Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        camera.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f);

        //一開場，及場景變換後觸發一次
        if(nowSceneName!=SceneManager.GetActiveScene().name){
            //if(nowSceneName=="parentsRoom" && went[0]==false)
            //    went[0] = true;
            nowSceneName = SceneManager.GetActiveScene().name;
            GetSceneObject(nowSceneName);
            if(nowSceneName!="Fireroom0"){
                nowCrawl = false;
                GameObject.Find("player").GetComponent<Playerf2>().crawl = nowCrawl;
                updateDoor();
                jsMovement.InputDirection = Vector3.zero;
            }
            else{
                updateFloor();
            }
            if(nowSceneName=="Firecorridor" || nowSceneName=="Fireroom0"){
                button.SetActiveRecursively(false);
            }
            else{
                button.SetActiveRecursively(true);
            }
        }

        //靠近門顯示開門按鈕
        int temp = -1;
        bool showButton = false;
        for(int i=0;i<2;i++){
            for(int j=0;j<17;j++){
                if(doorsList[i,j,2]==null) continue;
                else if(doorsList[i,j,2].GetComponent<doorTrigger>().playerIn){
                    temp = j;
                    showButton = true;
                    break;
                }
            }
        }
        enterButton.SetActiveRecursively(showButton);
        if(showButton){
            lastInDoor = temp;
            enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text
             = ((doorsOpen[nowFloor, temp])?"Close":"Open");
        }
        else if(lastInDoor!=-1){
            if(doorsOpen[nowFloor, lastInDoor]){
                punish(1);
            }
            lastInDoor = -1;
        }
        if(showButton==false && nowSceneName=="Firecorridor"){
            enterButton.SetActiveRecursively(true);
            enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Crawl";
        }
    }

    void punish(int i)
    {//扣血，根據不同情況扣不同血量
        if(i==0){
            //沒有先檢查門把
            HP -= 4;
        }
        else if(i==1){
            //離開門沒有關
            HP -= 8;
        }
        else if(i==2){
            //選錯房間
            HP -= 25;
        }
        else if(i==-1)
        {//控制持續扣血的
            if(nowSceneName=="Firecorridor")
            {//沒有使用正確移動方式
                if(nowFloor>=6 && nowCrawl==true || nowFloor<=5 && nowCrawl==false){
                    HP -= 2.5f * Time.deltaTime;
                }
            }
            if(nowFloor>7 || nowFloor==7 && wentRoom0==true)
            {//白煙往上或原層樓避難
                HP -= 8 * Time.deltaTime;
            }
            if(wentUnder5==true && nowFloor!=5)
            {//遇到黑煙後，還選擇往上或往下
                HP -= 25 * Time.deltaTime;
            }
        }
        updateHP();
        if(HP<=0){
            HPobj.SetActiveRecursively(false);
            player.SetActiveRecursively(false);
            controller.SetActiveRecursively(false);
            button.SetActiveRecursively(false);
            messanger.SetActiveRecursively(false);
            enterButton.SetActiveRecursively(false);
            backButton.SetActiveRecursively(false);
            leftButton.SetActiveRecursively(false);
            rightButton.SetActiveRecursively(false);
            SceneManager.LoadScene("Selection4");
            Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
            camera.position = new Vector3(0f, 0f, -10f);
            Destroy(gameObject);
        }
    }

    void updateHP()
    {//根據血量變數，更新遊戲中愛心圖片
        float temp = 1-(float)HP/100;
        HPobj.GetComponent<RawImage>().uvRect = new Rect(temp, 0f, 1f, 1f);
        HPobj.GetComponent<RectTransform>().pivot = new Vector2(0.5f-temp, 0.5f);
    }

    void buttonFunc()
    {//按下呼救按鈕觸發
        //這裡接通關畫面
        bool temp = false;
        if(nowFloor==5){
            for(int i=9;i<=12;i++){
                if(nowSceneName=="Fireroom"+i.ToString()){
                    temp = true;
                    break;
                }
            }
        }
        if(temp==false){
            punish(2);
        }
        clear = (HP>0)?1:0;
        HPobj.SetActiveRecursively(false);
        player.SetActiveRecursively(false);
        controller.SetActiveRecursively(false);
        button.SetActiveRecursively(false);
        messanger.SetActiveRecursively(false);
        enterButton.SetActiveRecursively(false);
        backButton.SetActiveRecursively(false);
        leftButton.SetActiveRecursively(false);
        rightButton.SetActiveRecursively(false);
        SceneManager.LoadScene("Selection4");
        Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        camera.position = new Vector3(0f, 0f, -10f);
    }

    void leftButtonClick()
    {//按下左半邊螢幕觸發
        if(GameObject.Find("backGround")!=null){
            //進電梯
            messangerNum = 2;
            showMessanger();
        }
        else{
            //上一層樓
            nowFloor++;
            if(nowFloor>9){
                nowFloor = 9;
            }
            updateFloor();
        }
    }

    void rightButtonClick()
    {//按下右半邊螢幕觸發
        if(GameObject.Find("backGround")!=null){
            //走樓梯
            GameObject.Find("backGround").SetActiveRecursively(false);
        }
        else{
            //下樓
            nowFloor--;
            if(nowFloor<=5){
                wentUnder5 = true;
            }
            if(nowFloor<1){
                nowFloor = 1;
            }
            updateFloor();
        }
    }

    void updateFloor()
    {
        for(int i=1;i<=9;i++){
            showFloor[i].SetActiveRecursively(i==nowFloor?true:false);
        }
        whiteCigarette.SetActiveRecursively(nowFloor>5);
        blackCigarette.SetActiveRecursively(nowFloor<=5);
        firePic.SetActiveRecursively(nowFloor<=4);
    }

    void goBackFunc()
    {//按下 Back 觸發，離開樓梯間
        wentRoom0 = true;
        SceneManager.LoadScene("Firecorridor");
        player.SetActiveRecursively(true);
        playerTransform.position = new Vector2(-12f, 1.76f);
        backButton.SetActiveRecursively(false);
        leftButton.SetActiveRecursively(false);
        rightButton.SetActiveRecursively(false);
        controller.SetActiveRecursively(true);
    }

    void enterButtonFunc()
    {//點擊enter button按鈕後觸發
        int temp = -1;
        for(int i=0;i<2;i++){
            for(int j=0;j<17;j++){
                if(doorsList[i,j,2]==null) continue;
                else if(doorsList[i,j,2].GetComponent<doorTrigger>().playerIn){
                    temp = j;
                    break;
                }
            }
        }
        if(temp!=-1)
        {//在門內，開關門
            doorsOpen[nowFloor, temp] = !doorsOpen[nowFloor, temp];
            if(start==false){
                messangerNum = 1;
                showMessanger();
            }
            updateDoor();
        }
        else if(nowSceneName=="Firecorridor")
        {//在走廊，控制匍匐
            nowCrawl = !nowCrawl;
            GameObject.Find("player").GetComponent<Playerf2>().crawl = nowCrawl;
        }
    }

    void showMessanger()
    {//顯示訊息
        if(messangerNum==0){
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "你正在唱KTV，但發現透過門縫飄來陣陣白煙\n目前你待的這個房間沒有對外窗\n該怎麼做?\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Start";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.SetActiveRecursively(false);
        }
        if(messangerNum==1){
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "你確定嗎 ?\n是不是應該先用手背檢查一下門把的溫度\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "直接開";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "先檢查";
            start = true;
        }
        if(messangerNum==2){
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "緊急狀況中搭電梯很危險的阿\n乖乖走樓梯吧\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "瞭解";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.SetActiveRecursively(false);
        }
    }

    void closeMessanger()
    {//關閉訊息
        messanger.SetActiveRecursively(false);
        if(messangerNum==1){
            //沒有先檢查門把
            punish(0);
        }
    }

    void messangerBtn2()
    {// messanger 上的第二個按鈕，根據 messangerNum 而定，功能不同
        messanger.SetActiveRecursively(false);
        if(messangerNum==1){
            checkDoor = true;
            //手背動畫
        }
    }

    void updateDoor()
    {//更新門的狀態，開或關
        int index = getSceneIdex();
        if(index==-1){
            for(int i=0;i<17;i++){
                doorsList[0, i, 0].SetActiveRecursively(doorsOpen[nowFloor, i]==true);
                doorsList[0, i, 1].SetActiveRecursively(doorsOpen[nowFloor, i]==false);
            }
        }
        else{
            doorsList[1, index, 0].SetActiveRecursively(doorsOpen[nowFloor, index]==true);
            doorsList[1, index, 1].SetActiveRecursively(doorsOpen[nowFloor, index]==false);
        }
    }

    void FixedUpdate()
    {//控制角色移動(僅限鍵盤)
        if(Input.GetKey(KeyCode.UpArrow)){
            Vector2 p = playerTransform.position;
            playerTransform.position = new Vector3(p.x,p.y+0.1f,0f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            Vector2 p = playerTransform.position;
            playerTransform.position = new Vector3(p.x,p.y-0.1f,0f);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            Vector2 p = playerTransform.position;
            playerTransform.position = new Vector3(p.x+0.1f,p.y,0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            Vector2 p = playerTransform.position;
            playerTransform.position = new Vector3(p.x-0.1f,p.y,0f);
        }
    }
}
