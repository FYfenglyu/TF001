using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using LitJson;
using static ConstantTable;

public struct ProjAttribute
{
    public int cardID;
    public string iconPath;
    public string type;
    public string prefabPath;
    public int cost;
}

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

        LoadProjAttriFromJson("Config/Projectiles");
        LoadTypeIconInfoFromJson("Config/projectilesType");
    }

    // load projectile information from json file
    private void LoadProjAttriFromJson(string jsonFilePath)
    {
        string jsonFileContent = TextResourceReader.Read(jsonFilePath);
        List<ProjAttribute> projectileInfoList = JsonMapper.ToObject<List<ProjAttribute>>(jsonFileContent);

        // build dictionary 
        // key : projectile card ID
        // value : projectile information
        foreach (ProjAttribute projectileInfo_i in projectileInfoList)
        {
            projAttrDict.Add(projectileInfo_i.cardID, projectileInfo_i);
        }
    }

    // load projectile type icon file from json file
    private void LoadTypeIconInfoFromJson(string jsonFilePath)
    {
        string jsonFileContent = TextResourceReader.Read(jsonFilePath);
        projTypeIconDict = JsonMapper.ToObject<Dictionary<string, string>>(jsonFileContent);
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