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
    public List<int> projCardIDList;

    private const string cardPrefabPath = "Cards/ProjectileCard";
    
    private GameObject cardList;    // card list is the parent of every card on UI layer

    // Start is called before the first frame update
    private void Start()
    {
        cardList = GameObject.Find("CardList");

        GenProjCards();
    }

    private void GenProjCards()
    {
        foreach (int projCardID in projCardIDList)
        {
            // load projectile information
            ProjAttribute corrProjectileInfo = ProjectileData.instance.GetProjAttr(projCardID);

            // load basic projectile card prefab
            GameObject projectileCardPrefab = Resources.Load(cardPrefabPath) as GameObject;

            // create projectile card entity
            GameObject projectileCard = GameObject.Instantiate(projectileCardPrefab);

            // generate corresponding projectile card prefab
            // - projectile icon
            GameObject icon = projectileCard.transform.Find("Icon").gameObject;
            Sprite CardIconInConfig = Resources.Load(corrProjectileInfo.icon, typeof(Sprite)) as Sprite;
            icon.GetComponent<Image>().sprite = CardIconInConfig;

            // - projectile type
            GameObject typeIcon = projectileCard.transform.Find("TypeIcon").gameObject;
            string typeIconPathInConfig = ProjectileData.instance.GetTypeIconPath(corrProjectileInfo.type);
            Sprite typeIconInConfig = Resources.Load(typeIconPathInConfig, typeof(Sprite)) as Sprite;
            typeIcon.GetComponent<Image>().sprite = typeIconInConfig;

            // - projectile cost
            GameObject costText = projectileCard.transform.Find("Cost").gameObject;
            string costTextInConfig = corrProjectileInfo.cost.ToString();
            costText.GetComponent<Text>().text = costTextInConfig;

            // - set projectile card ID
            projectileCard.GetComponent<Card>().projCardID = projCardID;
            
            // set parent
            projectileCard.transform.SetParent(cardList.transform, false);
        }
    }
}