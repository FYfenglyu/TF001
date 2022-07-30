using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using LitJson;

// Flyweight Pattern
public class ProjectileData : MonoBehaviour
{
    public static ProjectileData instance;   // singleton

    private Dictionary<int, ProjAttribute> projAttrDict = new Dictionary<int, ProjAttribute>();    // match projectile card id with corresponding information

    private Dictionary<string, string> projTypeIconDict;  // match projectile type with corresponding icon


    private void Awake()
    {
        // singleton
        instance = this;

        LoadProjAttriFromJson();
        LoadTypeIconInfoFromJson();
    }

    // load projectile information from json file
    private void LoadProjAttriFromJson()
    {
#if UNITY_EDITOR
        string jsonFilePath = Application.streamingAssetsPath + "/Config/Projectiles.json";
#else
        string jsonFilePath = Application.streamingAssetsPath + "/Config/Projectiles.json";
#endif
        List<ProjAttribute> projectileInfoList = JsonMapper.ToObject<List<ProjAttribute>>(File.ReadAllText(jsonFilePath));

        // build dictionary 
        // key : projectile card ID
        // value : projectile information
        foreach (ProjAttribute projectileInfo_i in projectileInfoList)
        {
            projAttrDict.Add(projectileInfo_i.cardID, projectileInfo_i);
        }
    }

    // load projectile type icon file from json file
    private void LoadTypeIconInfoFromJson()
    {
#if UNITY_EDITOR
        string jsonFilePath = Application.streamingAssetsPath + "/Config/projectilesType.json";
#else
        string jsonFilePath = Application.streamingAssetsPath + "/Config/projectilesType.json";
#endif
        projTypeIconDict = JsonMapper.ToObject<Dictionary<string, string>>(File.ReadAllText(jsonFilePath));
    }

    // get projectile information by card id
    public ProjAttribute GetProjAttr(int projectileCardID)
    {
        return projAttrDict[projectileCardID];
    }

    // get projectile type icon path by projectile type
    public string GetTypeIconPath(string type)
    {
        return projTypeIconDict[type];
    }
}