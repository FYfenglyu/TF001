using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct ProjAttribute
{
	public int cardID;
	public string icon;
	public string type;
	public string prefab;
	public int cost;
	public int attack;
}

public class ProjectileManager : MonoBehaviour
{
    [Header("关卡投掷物卡牌列表")]
    public List<int> projectileCardIDList;

    private const string projectileCardPrefabPath = "Cards/ProjectileCard";
    
    private GameObject CardList;    // card list is the parent of every card on UI layer

    // Start is called before the first frame update
    private void Start()
    {
        CardList = GameObject.Find("CardList");

        GenProjCards();
    }

    private void GenProjCards()
    {
        foreach (int projectileCardID in projectileCardIDList)
        {
            // load projectile information
            ProjAttribute corrProjectileInfo = ProjectileData.instance.GetProjectileInfoByID(projectileCardID);

            // load basic projectile card prefab
            GameObject projectileCardPrefab = Resources.Load(projectileCardPrefabPath) as GameObject;

            // create projectile card entity
            GameObject projectileCard = GameObject.Instantiate(projectileCardPrefab);

            // generate corresponding projectile card prefab
            // 1. projectile icon
            GameObject icon = projectileCard.transform.Find("Icon").gameObject;
            Sprite CardIconInConfig = Resources.Load(corrProjectileInfo.icon, typeof(Sprite)) as Sprite;
            icon.GetComponent<Image>().sprite = CardIconInConfig;

            // 2. projectile type
            GameObject typeIcon = projectileCard.transform.Find("TypeIcon").gameObject;
            string typeIconPathInConfig = ProjectileData.instance.GetTypeIconPathByType(corrProjectileInfo.type);
            Sprite typeIconInConfig = Resources.Load(typeIconPathInConfig, typeof(Sprite)) as Sprite;
            typeIcon.GetComponent<Image>().sprite = typeIconInConfig;

            // 3. projectile cost
            GameObject costText = projectileCard.transform.Find("Cost").gameObject;
            string costTextInConfig = corrProjectileInfo.cost.ToString();
            costText.GetComponent<Text>().text = costTextInConfig;

            // 4. set ID
            projectileCard.GetComponent<Card>().projectileCardID = projectileCardID;
            
            // set parent
            projectileCard.transform.SetParent(CardList.transform, false);
        }
    }
}