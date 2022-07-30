public class ConstantTable
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

    //地址
    public const string PATH_PROJECTILECARD = "Prefabs/UI/ProjectileCard";
    public const string PATH_LEVELCONFIG_TEST = "/../../Config/HunterSpawn_L1.json";



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

}