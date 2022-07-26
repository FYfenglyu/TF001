using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardGenerator : MonoBehaviour
{
    [Header("关卡投掷物卡牌列表")]
    public List<int> projectileCardIDList;

    private const string projectileCardPrefabPath = "Prefabs/ProjectileCard";

    // Start is called before the first frame update
    private void Start()
    {
        foreach (int projectileCardID in projectileCardIDList)
        {
            // load projectile information
            ProjectileInfo corrProjectileInfo = ProjectileInfoManager.instance.GetProjectileInfoByID(projectileCardID);

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
            string typeIconPathInConfig = ProjectileInfoManager.instance.GetTypeIconPathByType(corrProjectileInfo.type);
            Sprite typeIconInConfig = Resources.Load(typeIconPathInConfig, typeof(Sprite)) as Sprite;
            typeIcon.GetComponent<Image>().sprite = typeIconInConfig;

            // 3. projectile cost
            GameObject costText = projectileCard.transform.Find("Cost").gameObject;
            string costTextInConfig = corrProjectileInfo.cost.ToString();
            costText.GetComponent<Text>().text = costTextInConfig;

            // 4. set ID
            projectileCard.GetComponent<CardSelectedHandler>().projectileCardID = projectileCardID;
            
            // set parent
            projectileCard.transform.SetParent(transform, false);
        }
    }
}
