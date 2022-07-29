using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class GuardianManager : MonoBehaviour
{
    public static GuardianManager instance;


    void Awake()
    {
        instance = this;
    }

    void Start() {
    }

    public Guardian GetGuardian(int gid)
    {
        Guardian aG = null;
        switch(gid)
        {
            case 101:
                aG = Resources.Load<Guardian>(PREFAB_MONKEY_GUA);
                break;
            case 102:
                aG = Resources.Load<Guardian>(PREFAB_FENCE_GUA);
                break;
            case 103:
                aG = Resources.Load<Guardian>(PREFAB_ELEPHANT_GUA);
                break;
            case 104:
                aG = Resources.Load<Guardian>(PREFAB_BAMBOO_GUA);
                break;
        }
        return aG;
    }

    public void GenerateGuardian(int id, Vector3 position, Quaternion rotation)
    {
        Guardian aG = GetGuardian(id);
        Debug.Log("生成守卫者"+ id.ToString());

        if(aG)
            GameObject.Instantiate(aG , position, rotation);       
    }
}