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

## Architect of Program

- Data
    - *LevelData(need to rewrite)
    - ProjectileData
- Entity
    - Lifebody
        - Hunter
        - Guardian
    - MissileBase
        - Missile
        - ?GuardianMissile (yet not write)
    - BirthDoor
    - DeadDoor
- EntityControl
    - BuffBase
        - ScheduledBuff
            - ScheduleTagedBuff
                - HitHealBuff
                - SpeedUpBuff
                - AttackSpeedUpBuff
            - GameBuff
    - CircleRangeAttack
        - BuffAttack
        - BoomAttack
    - *RangeAttack (should be combined with CircleRangeAttack)
    - *Projectile (need to change name to project)
    - *Emit (should combine with Projectile to a Move class)
- Manager
    - GameManager
    - PlayManager
        - *TimeController (TimeManager, name should be changed, The same as below)
        - *ProjectileController
        - *HunterController
        - *GuardianController
- Tools
- UI
    - StartUI
    - PlayUI
        - Card
        - CardScrollView
        - ContinueButton
        - HPBar
        - CostDisplayer
        - ProgressBar
        - *InteractableUI (yet no use)
    - HelpUI
    - LevelSelectUI
    - ScrollCamera
- Test
ConstantTable
CommonFunction


