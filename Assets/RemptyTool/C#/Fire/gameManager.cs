using System.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    static gameManager GM;
    public Animator playerAni;
    public joyStickf2 jsMovement;
    Transform player;
    GameObject controller;
    GameObject enterButton;
    GameObject button;
    GameObject messanger;

    GameObject doorMask;
    GameObject[] doorMaskList = new GameObject[5];
    GameObject doorOpen;
    GameObject[] doorOpenList = new GameObject[5];
    GameObject doorClose;
    GameObject[] doorCloseList = new GameObject[5];
    GameObject doorTrigger;
    GameObject[,] doorsList = new GameObject[6, 4];
    GameObject goOutObj;
    GameObject outside;
    GameObject backBtn;
    bool lastPlayerOut;
    GameObject bathTrigger;
    GameObject bathTrigger2;
    GameObject bedTrigger;

    PointerEventData ped;

    //紀錄哪個門是開是關
    bool parentsToLiving;
    bool bathToLiving;
    bool childrensToLiving;
    bool bedToLiving;
    bool studyToLiving;
    bool livingToParents;
    bool livingToBath;
    bool livingToChildren;
    bool livingToBed;
    bool livingToStudy;
    bool livingToOut;
    bool windowsOpen;

    bool gotTowl = false;
    bool wentOut = false;
    bool checkDoor = false;
    bool moveSlowly = false;
    bool nowCrawl = false;
    int lastDoor = -1;

    public float HP = 100;
    string nowSceneName;
    bool[] went = new bool[7];
    bool outPunish = false;

    void Awake()
    {//設定此管理物件，必須唯一
        if(GM==null){
            GM = this;
            DontDestroyOnLoad(this);
        }else if(GM!=this){
            Destroy(gameObject);
        }
    }

    void updateCrawl()
    {//更新是否匍匐前進
        GameObject playerObj = GameObject.Find("player");
        playerObj.GetComponent<Playerf1>().crawl = nowCrawl;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        controller = GameObject.Find("joyStick");
        messanger = GameObject.Find("messanger");
        Button messangerBtn = messanger.transform.GetChild(1).gameObject.GetComponent<Button>();
        messangerBtn.onClick.AddListener(closeMessanger);
        messangerBtn = messanger.transform.GetChild(2).gameObject.GetComponent<Button>();
        messangerBtn.onClick.AddListener(messangerBtn2);
        messanger.SetActiveRecursively(false);
        enterButton = GameObject.Find("enterButton");
        enterButton.GetComponent<Button>().onClick.AddListener(OpenDoor);
        enterButton.SetActiveRecursively(false);
        button = GameObject.Find("Button");
        button.GetComponent<Button>().onClick.AddListener(buttonFunc);
        button.SetActiveRecursively(false);
        nowSceneName = " ";
        showMessanger();
    }
    void GetSceneObject(string sceneName)
    {
        int index = 0;
        if(sceneName==null) return;
        else if(sceneName== "FireslivingRoom")
        {
            string[] objName = new string[6] {
                "doorToParents",
                "doorToBath",
                "doorToChildren",
                "doorToBed",
                "doorToStudy",
                "doorToOut"
            };
            for(int i=0;i<6;i++){
                for(int j=1;j<=4;j++){
                    GameObject fatherObj = GameObject.Find(objName[i]);
                    doorsList[i,j-1] = fatherObj.transform.GetChild(j).gameObject;
                }
            }
            goOutObj = GameObject.Find("livingGoOut");
            outside = GameObject.Find("outside");
            backBtn = outside.transform.GetChild(3).transform.GetChild(0).gameObject;
            outside.SetActiveRecursively(false);
            backBtn.GetComponent<Button>().onClick.AddListener(goBackFunc);
            backBtn.SetActiveRecursively(false);
        }
        else{
            if     (sceneName== "FiresparentsRoom")   index = 0;
            else if(sceneName== "FiresbathRoom")      index = 1;
            else if(sceneName== "FireschildrensRoom") index = 2;
            else if(sceneName== "FiresbedRoom")       index = 3;
            else if(sceneName== "FiresstudyRoom")     index = 4;
            else if(sceneName== "Fireskichen")        return;

            if(doorMaskList[index]==null)
                doorMaskList[index] = GameObject.Find("blackMask");
            if(doorOpenList[index]==null)
                doorOpenList[index] = GameObject.Find("doorOpen");
            if(doorCloseList[index]==null)
                doorCloseList[index] = GameObject.Find("doorClose");
            if(doorTrigger==null)  
                doorTrigger = GameObject.Find("doorTrigger");
            if(index==1){
                bathTrigger = GameObject.Find("bathTrigger");
                bathTrigger2 = GameObject.Find("bathTrigger2");
            }
            if(index==3){
                bedTrigger = GameObject.Find("bedTrigger");
            }

            doorMask = doorMaskList[index];
            doorOpen = doorOpenList[index];
            doorClose = doorCloseList[index];
        }
    }

    void punish(int i)
    {//扣血，根據不同情況扣不同血量
            Debug.Log(outPunish);
        if(i==1){
            //沒關門
            HP -= 8;
        }
        else if(i==2){
            // go out
            HP -= 100;
        }
        else if(i==3){
            //沒有先檢查門把
            HP -= 4;
        }
        if(i==-1 && nowSceneName=="FireslivingRoom" && nowCrawl==false){
            HP -= (2.5f * Time.deltaTime);
        }
        if(i==-1 && outPunish){
            HP -= 70 * Time.deltaTime;
        }
    }

    void updateHP()
    {//根據血量變數，更新遊戲中愛心圖片
        GameObject HPobj = GameObject.Find("HP");
        float temp = 1-(float)HP/100;
        HPobj.GetComponent<RawImage>().uvRect = new Rect(temp, 0f, 1f, 1f);
        HPobj.GetComponent<RectTransform>().pivot = new Vector2(0.5f-temp, 0.5f);
        if(HP<=0){
            Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
            camera.position = new Vector3(0f, 0f, -10f);
            GameObject GMf2 = GameObject.Find("遊戲控制器f2");
            Destroy(GMf2);
            Destroy(gameObject);
            SceneManager.LoadScene("Selection4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //鏡頭永遠跟蹤
        Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        camera.position = new Vector3(player.position.x, player.position.y, -10f);

        punish(-1);
        updateHP();

        if(nowSceneName!=SceneManager.GetActiveScene().name)
        {//一開場，及場景變換後觸發一次
            nowCrawl = false;
            updateCrawl();
            lastDoor = -1;
            nowSceneName = SceneManager.GetActiveScene().name;
            if(nowSceneName!="end"){
                GetSceneObject(nowSceneName);
                updateDoor();
                GameObject playerObj = GameObject.Find("player");
                playerObj.GetComponent<Playerf1>().stop = true;
                controller.GetComponent<joyStickf2>().OnPointerUp(ped);
            }
        }
        if(nowSceneName== "FireslivingRoom")
        {
            //靠近門顯示開門按鈕
            bool showEnterButton = false;
            bool[] open = new bool[6] {
                livingToParents,
                livingToBath,
                livingToChildren,
                livingToBed,
                livingToStudy,
                livingToOut
            };
            int temp = -1;
            for(int i=0;i<6;i++){
                if(doorsList[i, 3].GetComponent<doorTrigger>().playerIn){
                    showEnterButton = true;
                    temp = i;
                    lastDoor = i;
                    break;
                }
            }
            enterButton.SetActiveRecursively(showEnterButton);
            if(showEnterButton){
                enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((open[temp])?"Close":"Open");
            }
            else if(lastDoor!=-1){
                if(open[lastDoor]){
                    punish(1);
                    lastDoor = -1;
                }
            }

            //go out
            if(goOutObj.GetComponent<ScenesChanger>().playerOut==true && lastPlayerOut==false){
                lastPlayerOut = true;
                goOutFunc();
            }
            if(goOutObj.GetComponent<ScenesChanger>().playerOut==false && lastPlayerOut==true){
                if(doorsList[5, 3].GetComponent<doorTrigger>().playerIn==false){
                    if(livingToOut==true){
                        showMessanger();
                    }
                    lastPlayerOut = false;
                }
            }
            button.SetActiveRecursively(true);
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Crawl";
        }
        else if(nowSceneName!="end"){
            button.SetActiveRecursively(false);
            if(doorTrigger.GetComponent<doorTrigger>().playerIn){
                enterButton.SetActiveRecursively(true);
                if(nowSceneName== "FiresparentsRoom"  )
                    enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((livingToParents)?"Close":"Open");
                else if(nowSceneName== "FiresbathRoom"  )      
                    enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((livingToBath)?"Close":"Open");
                else if(nowSceneName== "FireschildrensRoom"  ) 
                    enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((livingToChildren)?"Close":"Open");
                else if(nowSceneName== "FiresbedRoom"  )       
                    enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((livingToBed)?"Close":"Open");
                else if(nowSceneName== "FiresstudyRoom"  )     
                    enterButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((livingToStudy)?"Close":"Open");
                lastDoor = 100;
            }
            else{
                enterButton.SetActiveRecursively(false);
                if(lastDoor!=-1){
                    if(nowSceneName== "FiresparentsRoom" && livingToParents)
                        punish(1);
                    else if(nowSceneName== "FiresbathRoom" && livingToBath)      
                        punish(1);
                    else if(nowSceneName== "FireschildrensRoom" && livingToChildren) 
                        punish(1);
                    else if(nowSceneName== "FiresbedRoom" && livingToBed)       
                        punish(1);
                    else if(nowSceneName== "FiresstudyRoom" && livingToStudy)     
                        punish(1);
                    lastDoor = -1;
                }
            }
            if(nowSceneName== "FiresbedRoom")
            {
                bool showButton = false;
                if(bedTrigger.GetComponent<doorTrigger>().playerIn){
                    showButton = true;
                }
                button.SetActiveRecursively(showButton);
                button.transform.GetChild(0).gameObject.GetComponent<Text>().text = (windowsOpen)?"call 119":"Open";
            }
            else if(nowSceneName== "FiresbathRoom")
            {
                bool showButton = false;
                if(bathTrigger.GetComponent<doorTrigger>().playerIn){
                    showButton = true;
                }
                if(bathTrigger2.GetComponent<doorTrigger>().playerIn){
                    showButton = true;
                }
                button.SetActiveRecursively(showButton);
                button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Check";
            }
        }
    }
    void goOutFunc()
    {
        wentOut = true;
        outside.SetActiveRecursively(true);
        outPunish = true;
        Debug.Log(outPunish);
        backBtn.SetActiveRecursively(true);
        controller.GetComponent<joyStickf2>().OnPointerUp(ped);
        controller.SetActiveRecursively(false);
    }
    void goBackFunc()
    {
        goOutObj.GetComponent<ScenesChanger>().playerOut = false;
        player.position = new Vector2(17.8f, -8f);
        outside.SetActiveRecursively(false);
        outPunish = false;
        Debug.Log(outPunish);
        backBtn.SetActiveRecursively(false);
        controller.SetActiveRecursively(true);
    }
    void buttonFunc()
    {
        if(nowSceneName=="FireslivingRoom"){
            nowCrawl = !nowCrawl;
            updateCrawl();
        }
        else if(nowSceneName== "FiresbathRoom")
        {
            if(bathTrigger.GetComponent<doorTrigger>().playerIn){
                showMessanger();
            }
            if(bathTrigger2.GetComponent<doorTrigger>().playerIn){
                showMessanger();
            }
        }
        else if(nowSceneName== "FiresbedRoom")
        {
            if(bedTrigger.GetComponent<doorTrigger>().playerIn && windowsOpen==false){
                GameObject backGround = GameObject.Find("backGround");
                backGround.SetActiveRecursively(false);
                windowsOpen = true;
            }
            else if(bedTrigger.GetComponent<doorTrigger>().playerIn){
                showMessanger();
            }
        }
    }
    void OpenDoor()
    {//點擊開門按鈕後觸發
        if(nowSceneName== "FireslivingRoom")
        {
            int temp = -1;
            for(int i=0;i<6;i++){
                if(doorsList[i, 3].GetComponent<doorTrigger>().playerIn){
                    temp = i;
                    break;
                }
            }
            if(temp==0)
                parentsToLiving   = livingToParents  = !parentsToLiving;
            else if(temp==1)
                bathToLiving      = livingToBath     = !bathToLiving;
            else if(temp==2)
                childrensToLiving = livingToChildren = !childrensToLiving;
            else if(temp==3)
                bedToLiving       = livingToBed      = !bedToLiving;
            else if(temp==4)
                studyToLiving     = livingToStudy    = !studyToLiving;
            else if(temp==5)
                livingToOut       = !livingToOut;
        }
        else{
            if(nowSceneName== "FiresparentsRoom")
            { 
                if(went[0]==false) showMessanger();
                parentsToLiving   = livingToParents  = !parentsToLiving;
            }
            else if(nowSceneName== "FiresbathRoom")      
                bathToLiving      = livingToBath     = !bathToLiving;
            else if(nowSceneName== "FireschildrensRoom") 
                childrensToLiving = livingToChildren = !childrensToLiving;
            else if(nowSceneName== "FiresbedRoom")       
                bedToLiving       = livingToBed      = !bedToLiving;
            else if(nowSceneName== "FiresstudyRoom")     
                studyToLiving     = livingToStudy    = !studyToLiving;
            else if(nowSceneName== "Fireskichen")        
                return;
        }
        updateDoor();
    }
    void showMessanger()
    {
        if(nowSceneName=="FiresparentsRoom"){
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "你確定嗎 ?\n是不是應該先用手背檢查一下門把的溫度\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "直接開";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "先檢查";
            went[0] = true;
        }
        else if(nowSceneName== "FiresbedRoom")
        {
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "撥打119等待救援\n並在窗外揮舞鮮豔衣物讓消防人員知曉位置\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "OK!";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.SetActiveRecursively(false);
        }
        else if(nowSceneName== "FireslivingRoom")
        {
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "你確定嗎?\n不關門的話，外面的濃煙會跑進來喔\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "OK!";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.SetActiveRecursively(false);
        }
        else if(nowSceneName== "FiresbathRoom")
        {
            if(bathTrigger.GetComponent<doorTrigger>().playerIn){
                messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "這個門是塑膠的\n躲在這裡好像不是很安全\n";
                messanger.SetActiveRecursively(true);
                GameObject messangerBtnObj;
                messangerBtnObj = messanger.transform.GetChild(1).gameObject;
                messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Close";
                messangerBtnObj = messanger.transform.GetChild(2).gameObject;
                messangerBtnObj.SetActiveRecursively(false);
            }
            else if(bathTrigger2.GetComponent<doorTrigger>().playerIn){
                messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "是不是應該拿個濕毛巾?\n";
                messanger.SetActiveRecursively(true);
                GameObject messangerBtnObj;
                messangerBtnObj = messanger.transform.GetChild(1).gameObject;
                messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "拿";
                messangerBtnObj = messanger.transform.GetChild(2).gameObject;
                messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "不用";
            }
        }
        else if(nowSceneName==" "){
            messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = "你在房間內聞到了異味，並且發現透過門縫飄來陣陣濃煙\n目前你待的這個房間沒有對外窗\n該怎麼做?\n";
            messanger.SetActiveRecursively(true);
            GameObject messangerBtnObj;
            messangerBtnObj = messanger.transform.GetChild(1).gameObject;
            messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Start";
            messangerBtnObj = messanger.transform.GetChild(2).gameObject;
            messangerBtnObj.SetActiveRecursively(false);
        }
    }
    void closeMessanger()
    {
        messanger.SetActiveRecursively(false);
        if(nowSceneName== "FiresbedRoom")
        {
            endOfFire1();
        }
        if(nowSceneName=="FiresparentsRoom"){
            if(doorTrigger.GetComponent<doorTrigger>().playerIn){
                punish(3);
            }
        }
        if(nowSceneName=="FiresbathRoom"){
            if(bathTrigger2.GetComponent<doorTrigger>().playerIn){
                GameObject playerObj = GameObject.Find("player");
                playerObj.GetComponent<Playerf1>().towl = true;
            }
        }
    }
    void messangerBtn2()
    {
        messanger.SetActiveRecursively(false);
        if(nowSceneName== "FiresbathRoom" && bathTrigger2.GetComponent<doorTrigger>().playerIn)
        {
            gotTowl = true;
        }
        else if(nowSceneName== "FiresparentsRoom")
        {
            checkDoor = true;
            //手背動畫
            playerAni.SetInteger("Status", 70);
        }
    }
    void endOfFire1()
    {
        //player.position = new Vector3(0f, 0f, -10f);
        gameObject.transform.GetChild(0).gameObject.SetActiveRecursively(false);
        GameObject Canvas = gameObject.transform.GetChild(1).gameObject;
        Canvas.transform.GetChild(0).gameObject.SetActiveRecursively(false);
        SceneManager.LoadScene("Fireroom6");
        //player.position = new Vector3(5.88f,0.96f,0f);
        //Button endBtn;
        //endBtn = GameObject.Find("endButton").GetComponent<Button>();
        //endBtn.onClick.AddListener(endShowMessanger);
        //Debug.Log("iii");
    }
    void endShowMessanger()
    {
        bool doorOpen = true;
        bool[] temp = new bool[6] {
            livingToParents,
            livingToBath,
            livingToChildren,
            livingToBed,
            livingToStudy,
            livingToOut
        };
        for(int i=0;i<6;i++){
            if(temp[i]) doorOpen = false; 
        }
        string showtext = "";
        if(gotTowl) showtext += "不用拿毛巾\n";
        if(wentOut) showtext += "不要往外逃生\n";
        if(doorOpen) showtext += "要隨手關門\n";
        if(checkDoor==false) showtext += "開門前要用手背檢查\n";
        if(moveSlowly==false) showtext += "匍匐前進\n";

        messanger.transform.GetChild(0).gameObject.GetComponent<Text>().text = showtext;
        messanger.SetActiveRecursively(true);
        GameObject messangerBtnObj;
        messangerBtnObj = messanger.transform.GetChild(1).gameObject;
        messangerBtnObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Close";
        messangerBtnObj = messanger.transform.GetChild(2).gameObject;
        messangerBtnObj.SetActiveRecursively(false);
        
    }
    void updateDoor()
    {//更新門的狀態，開或關
        if(nowSceneName== "FireslivingRoom")
        {
            bool[] open = new bool[6] {
                livingToParents,
                livingToBath,
                livingToChildren,
                livingToBed,
                livingToStudy,
                livingToOut
            };
            for(int i=0;i<6;i++){
                doorsList[i,0].SetActiveRecursively(open[i]);
                doorsList[i,1].SetActiveRecursively(open[i]);
                doorsList[i,2].SetActiveRecursively(!open[i]);
            }
        }
        else{
            bool temp = false;
            if(nowSceneName== "FiresparentsRoom") temp = parentsToLiving;
            else if(nowSceneName== "FiresbathRoom") temp = bathToLiving;
            else if(nowSceneName== "FireschildrensRoom") temp = childrensToLiving;
            else if(nowSceneName== "FiresbedRoom") temp = bedToLiving;
            else if(nowSceneName== "FiresstudyRoom") temp = studyToLiving;
            else if(nowSceneName== "Fireskichen") return;
            doorMask.SetActiveRecursively(temp);
            doorOpen.SetActiveRecursively(temp);
            doorClose.SetActiveRecursively(!temp);
        }
    }
  /*  void FixedUpdate()
    {//控制角色移動
        if(Input.GetKey(KeyCode.UpArrow)){
            Vector2 p = player.position;
            player.position = new Vector3(p.x,p.y+0.1f,0f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            Vector2 p = player.position;
            player.position = new Vector3(p.x,p.y-0.1f,0f);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            Vector2 p = player.position;
            player.position = new Vector3(p.x+0.1f,p.y,0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            Vector2 p = player.position;
            player.position = new Vector3(p.x-0.1f,p.y,0f);
        }
    } */
}
