using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*SSActionManager 动作管理基类*/
public class SSActionManager : MonoBehaviour {
    private Dictionary<int, SSAction> actionsRunning = new Dictionary<int, SSAction>();    //执行队列
    private List<SSAction> actionToRun = new List<SSAction>();                       //等待执行的动作
    private List<int> actionToDel = new List<int>();                              //等待删除的动作的key列表     

    protected void Update() {
        //加载等待中的动作进入执行队列
        foreach (SSAction action in actionToRun) {
            actionsRunning[action.GetInstanceID()] = action;
        }
        actionToRun.Clear();

        //对于执行队列中每一个动作，检测执行还是删除
        foreach (KeyValuePair<int, SSAction> actionKV in actionsRunning) {
            SSAction action = actionKV.Value;
            if (action.enable) {
                action.Update();
                action.FixedUpdate();
            } 
            else {
                actionToDel.Add(action.GetInstanceID());
            }
        }

        //删除已完成的动作
        foreach (int key in actionToDel) {
            SSAction action = actionsRunning[key];
            actionsRunning.Remove(key);
            Object.Destroy(action);
        }
        actionToDel.Clear();
    }

    public void StartAction(GameObject gameobject, SSAction action) {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        actionToRun.Add(action);
        action.Start();
    }

}