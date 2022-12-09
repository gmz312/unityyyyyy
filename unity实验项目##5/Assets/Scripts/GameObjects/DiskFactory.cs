using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*DiskFactory 飞碟工厂类*/
public class DiskFactory {
    public static DiskFactory DiskF;
    private List<Disk> busyDisks = new List<Disk>();
    private List<Disk> freeDisks = new List<Disk>();

    //
    private DiskFactory(){}
   
    public static DiskFactory GetInstance(){//huoqu
        
        if(DiskF == null)
        {
            DiskF = new DiskFactory();
            }
            
        return DiskF;
    }

    public GameObject GetDisk(int type) {
       
        GameObject disk_prefab = null;
        
        if (freeDisks.Count > 0) {
            
            for(int i = 0; i < freeDisks.Count; i++) {
                
                if (freeDisks[i].type == type) {
                    disk_prefab = freeDisks[i].gameObject;
                    freeDisks.Remove(freeDisks[i]);
                    break;
                }
            }     
        }
        
        //预制的三种不同的disk
        if(disk_prefab == null) {
            if(type == 1) {
                
                disk_prefab = GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/disk1"),
                
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            else if (type == 2) {
                
                
                disk_prefab = GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/disk2"),
                
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            else {
                
                disk_prefab = GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/disk3"),
                
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            disk_prefab.GetComponent<Renderer>().material.color = disk_prefab.GetComponent<Disk>().color;
        }

        busyDisks.Add(disk_prefab.GetComponent<Disk>());
        disk_prefab.SetActive(true);
        return disk_prefab;
    }

    public void FreeUsedDisks() {
        
        for(int i = 0; i < busyDisks.Count; i++) {
            
            if (busyDisks[i].gameObject.transform.position.y <= -10f) {
                
                freeDisks.Add(busyDisks[i]);
                
                busyDisks.Remove(busyDisks[i]);
            }
        
        }          
    }

    public void Reset() { FreeUsedDisks();}
       

}
