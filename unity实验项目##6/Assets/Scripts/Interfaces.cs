using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneController {
    void LoadResources();                                  
}

public interface IUserAction {
    void Hit(Vector3 pos);
    float GetScore();
    int GetRound();
    int GetTrial();
    bool isEnd();
    void GameOver();
    void Restart();
    void setPhysic(bool obj);
}
public enum SSActionEventType : int { Started, Competeted }