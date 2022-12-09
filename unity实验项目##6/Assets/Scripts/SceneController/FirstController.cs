using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
    
    public DiskFactory disk_factory;
    public FlyActionManager action_manager;
    public ScoreRecorder score_recorder;
    public UserGUI user_gui;
    private int round = 1;                                                  
    private int trial = 0;                                         
    private bool running = false;
    private bool isPhysic = true;

    void Start () {  
        SSDirector.GetInstance().CurrentScenceController = this;
        disk_factory = DiskFactory.GetInstance();
        score_recorder = ScoreRecorder.GetInstance();
        action_manager = gameObject.AddComponent<FlyActionManager>() as FlyActionManager;
        user_gui = gameObject.AddComponent<UserGUI>() as UserGUI;
    }
//
    int count = 0;
	void Update () {
        if(running) {
            count++;
            if (Input.GetButtonDown("Fire1")) {
                Vector3 pos = Input.mousePosition;
                Hit(pos);
            }
            switch (round) {
                case 1: {
                        if (count >= 900) {
                            count = 0;
                            SendDisk(1);
                            trial += 1;
                            if (trial == 10) {
                                round += 1;
                                trial = 0;
                            }
                        }
                        break;
                    }
                case 2: {
                        if (count >= 800) {
                            count = 0;
                            SendDisk(trial % 2 + 1);
                            if(Random.Range(1,3) == 1)
                                SendDisk(1);
                            trial += 1;
                            if (trial == 10) {
                                round += 1;
                                trial = 0;
                            }
                        }
                        break;
                    }
                case 3: {
                        if (count >= 800) {
                            if (trial == 11) {
                                running = false;
                            }
                            count = 0;
                            if(trial <= 9)
                                SendDisk(trial % 3 + 1);
                            if(Random.Range(1,3) == 1)
                                SendDisk(Random.Range(1,3));
                            trial += 1;
                        }
                        break;
                    }
                default:
                        break;
            } 
            disk_factory.FreeUsedDisks();
        }
    }

    public void LoadResources() {}

    private void SendDisk(int type) {

        //Get a disk
        GameObject disk = disk_factory.GetDisk(type);

        //飞碟位置
        float disk_y = 0;
        float disk_x = Random.Range(-1f, 1f) < 0 ? -1 : 1;
        float speed = 0;
        float angle = 0;//初速度
        if (type == 1) {
            disk_y = Random.Range(1f, 3f);
            speed = Random.Range(0.5f, 1f);
            angle = Random.Range(40f, 50f);
        }
        else if (type == 2) {
            disk_y = Random.Range(2f, 3f);
            speed = Random.Range(0.8f, 1.2f);
            angle = Random.Range(35f, 40f);
        }
        else {
            disk_y = Random.Range(3f, 4f);
            speed = Random.Range(1.0f, 1.2f);
            angle = Random.Range(28f, 35f);
        }
        speed = speed * 1.5f;
        disk.transform.position = new Vector3(disk_x * 14f, disk_y, 0);

        if(isPhysic)
            action_manager.DiskFly(disk, speed);
        else
            action_manager.DiskFly(disk, angle, speed);
    }

    public void Hit(Vector3 pos) {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++) {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<Disk>() != null) {
                score_recorder.RecordScore(hit.collider.gameObject);
                hit.collider.gameObject.transform.position = new Vector3(0, -10, 0);
            }
        }
    }

    public void Restart() {
        running = true;
        score_recorder.Reset();
        disk_factory.Reset();
        round = 1;
        trial = 1;
    }

    public void GameOver() {
        running = false;
    }

    public float GetScore() {
        return score_recorder.GetScore();
    }
    public int GetRound() {
        return round;
    }
    public int GetTrial() {
        return trial;
    }
    public bool isEnd(){
        return (round == 3 && trial == 11);
    }
    public void setPhysic(bool obj){
        isPhysic = obj;
    }
}

    
