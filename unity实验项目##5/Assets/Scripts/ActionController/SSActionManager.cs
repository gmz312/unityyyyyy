using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SSActionManager : MonoBehaviour {
    private Dictionary<int, SSAction> actionsRunning = new Dictionary<int, SSAction>(); //queue create
    private List<SSAction> actionToRun = new List<SSAction>();//wait
    private List<int> acDel = new List<int>();    

    protected void Update() {//动作入队
        foreach (SSAction action in actionToRun) {
            actionsRunning[action.GetInstanceID()] = action;
        }
        actionToRun.Clear();
        foreach (KeyValuePair<int, SSAction> actionKV in actionsRunning) {//判断是否执行
            
            SSAction action = actionKV.Value;
            
            if (action.enable) {
                action.Update();
            } 
                
            
            else {
                acDel.Add(action.GetInstanceID());
            }
        }
        
        
        foreach (int key in acDel) {
           
            SSAction action = actionsRunning[key];
            actionsRunning.Remove(key);
           
            Object.Destroy(action);
        }
        
        acDel.Clear();
    }

    public void StartAction(GameObject gameobject, SSAction action) {
        
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        actionToRun.Add(action);
        
        action.Start();
    
    }

}