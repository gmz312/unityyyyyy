using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController 
{
    public void MoveToBoat(Role role, int i)
    {
        role.setPos(2);
        if (i == 1){
            role.setBoatPos(0);
            role.obj.transform.position = new Vector3(0, -3, 4);}
        else if(i == 2){
            role.setBoatPos(1);
            role.obj.transform.position = new Vector3(0, -3, 6);}
        else if(i == 3){
            role.setBoatPos(1);
            role.obj.transform.position = new Vector3(0, -3, -4);}
        else{
            role.setBoatPos(0);
            role.obj.transform.position = new Vector3(0, -3, -6);}
    }
    public void MoveGroundFrom(Role role)
    {
        role.obj.transform.position = role.getGroundPos(0);
        role.setPos(0);
    }

    public void MoveGroundTo(Role role)
    {
        role.obj.transform.position = role.getGroundPos(1);
        role.setPos(1);
    }
    public void MoveBoat(Boat boat, Role []Priests, Role []Devils)
    {
        Vector3 currentPos = boat.boat_obj.transform.position;
        Vector3[] boat_park = { new Vector3(0, -4, -5), new Vector3(0, -4, 5) };
        Vector3 park_now = boat_park[boat.movestate - 1];
        int boat_pos = boat.movestate - 1;
        if (currentPos == park_now){
            boat.movestate = 0;
        }
        boat.boat_obj.transform.position = Vector3.MoveTowards(currentPos, park_now, 7f * Time.deltaTime);
        Vector3[,] seats = { 
            { new Vector3(0, -3, -6), new Vector3(0, -3, -5) },
            { new Vector3(0, -3, 5), new Vector3(0, -3, 6) }
        };
        for (int i = 0;i < 2;i++){
            int seat_pos = i;
            Role role_t = MapNumToRole(boat.BoatState[i], Priests, Devils);
            if (role_t != null)
            {
                Vector3 cur = role_t.obj.transform.position;
                role_t.obj.transform.position = Vector3.MoveTowards(cur, seats[boat_pos,seat_pos], 7f * Time.deltaTime);
            }
        }
    }

    Role MapNumToRole(int num, Role []Priests, Role []Devils)
    {
        Role role_temp = null;
        if(num < 4 && num > 0){
            role_temp = Priests[num - 1];
        }
        else if(num >= 4 && num <= 6){
            role_temp = Devils[num - 4];
        }
        if(role_temp == null){
        }
        return role_temp;
    }
}