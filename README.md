# Minigame 

## Folders
- Assets:
	- Animation : 存放动画
	- Image : 存放图片，图片过多则分子文件夹存放
	- Plugin : 存放C#拓展库，目前存放了一个LitJson库
	- Prefabs : 预制体
	- Resources : 可动态加载的资源
		- Prefabs : 可动态加载的预制体
	- Scenes : 存放场景，后续加入关卡和开始场景
	- Scripts : C#脚本
- Config : json格式的策划配置文件
- Tools : python脚本，用于生成上述json格式的配置文件（投掷物和猎人）

## Scripts
- CardSelectedHandler : 响应卡牌点击事件
- GameManager
- HPBarController : 自制血条脚本
- ProjectileInfo : 结构体(struct)，存放投射物信息
- ProjectileInfoManager : 本来想做享元模式的信息管理器，但是不知道C#引用咋写，开摆
- UIManager : 控制UI，目前只预留了“控制卡牌选择器关闭”的接口

## ...