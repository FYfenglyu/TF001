public static class ConstantTable
{
    //种类
    public const string TYPE_MISSILE = "Missile";
    public const string TYPE_GUARDIAN = "Guardian";
    public const string TYPE_GUARDIANMISSILE = "GuardianMissile";
    public const string TYPE_EMITMISSILE = "EmitMissile";
    public const string TYPE_HUNTER = "Hunter";
    public const string TYPE_ROAD = "Road";

    //子弹名称
    public const string TYPE_MISSILE_STONE = "";
    public const string TYPE_MISSILE_BOMB = "";
    public const string TYPE_MISSILE_WOOD = "";

    //显示组件
    public const string DIS_CARDITEM = "r";
    public const string DIS_CARDLIST = "";
    public const string DIS_HPBAR = "HPbar";

    //持久性
    public const int PERS_VELOCITY = 2;
    public const int PERS_TIME = 1;
    public const int PERS_NO = 0;

    // 地址文件夹
    // paths of file load by function Rescource.Load() should not contain suffix "json"
    private const string _PREFIX_CONFIG = "Config/";

    //地址
    public const string PATH_PROJECTILECARD = "Prefabs/UI/ProjectileCard";
    public const string PATH_LEVELCONFIG_TEST = _PREFIX_CONFIG + "HunterSpawn_L1";
    public const string PATH_CONFIG_CARD = _PREFIX_CONFIG + "projectiles";
    public const string PATH_CONFIG_CARDTYPE = _PREFIX_CONFIG + "projectilesType";

    private const string _PREFIX_CONFIG_LEVEL = _PREFIX_CONFIG + "LevelConfig_L";
    private const string _PREFIX_CONFIG_LEVEL_HUNTERS = _PREFIX_CONFIG + "HunterSpawn_L";

    public static string GetLevelHuntersConfigPath(int i)
    {
        return new string(_PREFIX_CONFIG_LEVEL_HUNTERS + i.ToString());
    }
    public static string GetLevelConfigPath(int i)
    {
        return new string(_PREFIX_CONFIG_LEVEL + i.ToString());
    }

    //prefab地址-守护者
    private const string _PREFIX_PREFAB_GUARDIAN = "Prefabs/Guardian/";
    public const string PREFAB_MONKEY_PROJ = _PREFIX_PREFAB_GUARDIAN + "monkey_PROJ";
    public const string PREFAB_ELEPHANT_PROJ = _PREFIX_PREFAB_GUARDIAN + "elephant_PROJ";
    public const string PREFAB_FENCE_PROJ = _PREFIX_PREFAB_GUARDIAN + "fence_PROJ";
    public const string PREFAB_BAMBOO_PROJ = _PREFIX_PREFAB_GUARDIAN + "bamboo_PROJ";

    public const string PREFAB_ELEPHANT_GUA = _PREFIX_PREFAB_GUARDIAN + "elephant_GUA";
    public const string PREFAB_MONKEY_GUA = _PREFIX_PREFAB_GUARDIAN + "monkey_GUA";
    public const string PREFAB_FENCE_GUA = _PREFIX_PREFAB_GUARDIAN + "fence_GUA";
    public const string PREFAB_BAMBOO_GUA = _PREFIX_PREFAB_GUARDIAN + "bamboo_GUA";

    //prefab地址-猎人
    private const string _PREFIX_PREFAB_HUNTER = "Prefabs/Hunters/hunter_";
    public const string PREFAB_HUNTER_01 = _PREFIX_PREFAB_HUNTER + "01";
    public const string PREFAB_HUNTER_02 = _PREFIX_PREFAB_HUNTER + "02";
    public const string PREFAB_HUNTER_03 = _PREFIX_PREFAB_HUNTER + "03";

    //图片地址
    private const string _PREFIX_IMAGE_LEVELUI = "Image/UI/Level/";
    private const string _PREFIX_IMAGE_LEVELUI_NUMBER = _PREFIX_IMAGE_LEVELUI + "/Numbers/";
    private const string _PREFIX_IMAGE_LEVELUI_TRACK = _PREFIX_IMAGE_LEVELUI + "Track/track";


    public static string GetLevelUIButtonImagePath(string name)
    {
        string path = _PREFIX_IMAGE_LEVELUI;
        switch (name)
        {
            case "highlight":
                path += "gq_xz";
                break;
            case "on":
                path += "gq_ywc";
                break;
            case "off":
                path += "gq_wjs";
                break;
        }
        return path;
    }

    public static string GetLevelTrackImagePath(int level)
    {
        return _PREFIX_IMAGE_LEVELUI_TRACK + level.ToString();
    }

    //场景地址
    public const string SCENE_START = "Game@Start";
    public const string SCENE_LEVELSELECT = "Game@LevelSelect";

    //音频地址

    private const string _PREFIX_AUDIO = "Audio/";
    public const string AUDIO_BGM = _PREFIX_AUDIO + "1_bgm";
    public const string AUDIO_SELECTCARD = _PREFIX_AUDIO + "2_select_card";
    public const string AUDIO_PROJECT_MAGIC = _PREFIX_AUDIO + "3_project_magic";
    public const string AUDIO_PROJECT_LIGHT = _PREFIX_AUDIO + "3_project_light";
    public const string AUDIO_HITHUNTER = _PREFIX_AUDIO + "4_hit_hunter";
    public const string AUDIO_CLICKBUTTON = _PREFIX_AUDIO + "5_click_button";
    public const string AUDIO_HUNTERAPPER = _PREFIX_AUDIO + "6_hunter_appear";
    public const string AUDIO_EMIT = _PREFIX_AUDIO + "7_emit";
    public const string AUDIO_SUCCESS = _PREFIX_AUDIO + "8_success";
    public const string AUDIO_FAILED = _PREFIX_AUDIO + "8_failed";
    public const string AUDIO_START = _PREFIX_AUDIO + "10_start";

    //参数设置
    public const int NUM_MAXLEVEL = 16;

    // 游戏本地化数据文件路径
    public const string LOCAL_UNLOCKEDLEVELNUM_PATH = "UnlockedLevel.json";
}