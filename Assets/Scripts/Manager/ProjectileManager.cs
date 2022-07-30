using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;   // singleton

    [Header("关卡投掷物卡牌列表")]
    public List<int> cardIDList;

    private GameObject cardList;    // card list is the parent of every card on UI layer


    private Card currCard;
    private Material highLight;  // edge lighting material
    private Material spriteDefault;  // default sprite material

    private GameObject currProj;    // current projectile
    private Transform anchorPos;    // where projectile generates

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        cardList = GameObject.Find("CardList");

        // get image material
        // highLight = new Material(Shader.Find("EdgeLighting"));
        highLight = null;
        // spriteDefault = new Material(Shader.Find("Sprites-Default"));
        spriteDefault = null;

        // get anchor position
        anchorPos = GameObject.Find("AnchorPoint").transform;

        GenCards();
    }

    // part of level manager, it will be removed later
    private void GenCards()
    {
        foreach (int cardID in cardIDList)
        {
            // load projectile information
            ProjAttribute corrProjectileInfo = ProjectileData.instance.GetProjAttr(cardID);

            // load basic projectile card prefab
            GameObject projCardPrefab = Resources.Load<GameObject>(PATH_PROJECTILECARD);

            // create projectile card entity
            GameObject projectileCard = GameObject.Instantiate(projCardPrefab);

            // generate corresponding projectile card prefab
            // - projectile icon
            GameObject icon = projectileCard.transform.Find("Icon").gameObject;
            Sprite CardIconInConfig = Resources.Load<Sprite>(corrProjectileInfo.iconPath);
            icon.GetComponent<Image>().sprite = CardIconInConfig;

            // - projectile type
            GameObject typeIcon = projectileCard.transform.Find("TypeIcon").gameObject;
            string typeIconPathInConfig = ProjectileData.instance.GetTypeIconPath(corrProjectileInfo.type);
            Sprite typeIconInConfig = Resources.Load<Sprite>(typeIconPathInConfig);
            typeIcon.GetComponent<Image>().sprite = typeIconInConfig;

            // - projectile cost
            GameObject costText = projectileCard.transform.Find("Cost").gameObject;
            string costTextInConfig = corrProjectileInfo.cost.ToString();
            costText.GetComponent<Text>().text = costTextInConfig;

            // - set projectile card ID
            projectileCard.GetComponent<Card>().cardID = cardID;

            // set parent
            projectileCard.transform.SetParent(cardList.transform, false);
        }
    }

    public void ClearCards()
    {
        SetCurrCard(null);
        foreach(Transform child in cardList.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetCurrCard(Card card)
    {
        // set current card as null
        if (card == null)
        {
            // chnage the icon image material to sprite default
            if(currCard)
            {
            currCard.ChangeIconImgMaterial(spriteDefault);
            currCard.IsSelected() = false;
            currCard = null;
            }
            
            // if current projectile is not null
            if (currProj)
            {
                // if current projectile is not projected, destroy it
                if (!currProj.GetComponent<Projectile>().IsProjectiled()) GameObject.Destroy(currProj);
                currProj = null;                
            }
            return;
        }

        // cancle the highlight of last card
        // and if there exists a projectile, destroy it
        if (currProj)
        {
            currCard.IsSelected() = false;
            currCard.ChangeIconImgMaterial(spriteDefault);

            GameObject.Destroy(currProj);
        }

        // set card as current card
        currCard = card;
        currCard.IsSelected() = true;

        // highlight current card
        currCard.ChangeIconImgMaterial(highLight);

        // create a specified projectile, and set it as current projectile
        GameObject projPrefabPath = (GameObject)Resources.Load(ProjectileData.instance.GetProjAttr(card.cardID).prefabPath);
        currProj = GameObject.Instantiate(projPrefabPath, anchorPos.position, Quaternion.identity);
    }

    public void SetCardsList(List<int> cardsList)
    {
        cardIDList = cardsList;
        ClearCards();
        GenCards();
    }
}