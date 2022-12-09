using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ScoreRecorder 记分员类*/
public class ScoreRecorder {
    public static ScoreRecorder scoreR;
    private float score;

    // Singleton
    private ScoreRecorder(){}
    public static ScoreRecorder GetInstance(){
        if(scoreR == null){
            scoreR = new ScoreRecorder();
        }
        return scoreR;
    }
    void Start () {
        score = 0;
    }
    public void RecordScore(GameObject disk) {
        score += disk.GetComponent<Disk>().score;
    }
    public float GetScore() {
        return score;
    }
    public void Reset() {
        score = 0;
    }
}
