using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Patrol :MonoBehaviour
{
    public enum PatrolState { PATROL,FOLLOW};
    public int sign;       
    public bool isFollowPlayer = false;
    public GameObject player=null;      
    public Vector3 startPos,nextPos;
    private float minPosX,minPosZ; 
    private bool isMoving = false;
    private float distance;
    private float speed = 1.2f;
    PatrolState state = PatrolState.PATROL;
    private void Start()
    {//初始化
        minPosX = startPos.x - 2.5f;
        minPosZ = startPos.z - 2.5f;
        isMoving = false;
        AreaCollide.canFollow += changeStateToFollow;
    }

    public void FixedUpdate()
    {//每一帧更新时调用
        if((SSDirector.getInstance().currentScenceController as FirstController).gameState == GameState.END)
        {
            return;
        }
        //它根据当前的状态调用 GoPatrol 或 Follow 方法。
        if(state == PatrolState.PATROL)
        {
            GoPatrol();
        }
        else if(state == PatrolState.FOLLOW)
        {
            Follow();
        }
    }
    public void GoPatrol()
    {//方法使游戏对象在一个随机的目标位置周本身移动。
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, nextPos, speed * Time.deltaTime);
            distance = Vector3.Distance(this.transform.position, nextPos);
            if(distance < 0.5)
            {
                isMoving = false;
            }
            return;
        }
        float posX = Random.Range(0f, 5f);
        float posZ = Random.Range(0f, 5f);
        nextPos = new Vector3(minPosX+posX, 0, minPosZ+posZ);
        isMoving = true;    
    }

    public void Follow()
    {//方法使游戏对象向玩家移动。
        if(player != null)
        {
            nextPos = player.transform.position;
            transform.position = Vector3.MoveTowards(this.transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    public void changeStateToFollow(int sign_,bool isEnter)
    {//收到一个消息时调用
    
    //改变游戏对象的状态并设置相关的变量。
        if(sign == sign_ )
        {
            if (isEnter)
            {
                state = PatrolState.FOLLOW;
                player = (SSDirector.getInstance().currentScenceController as FirstController).player;
                isFollowPlayer = true;
            }           
            else
            {
                isFollowPlayer = false;
                state = PatrolState.PATROL;
                player = null;
                isMoving = false;
            }
        }
        
    }
}

