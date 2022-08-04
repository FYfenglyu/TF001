# Design Pattern

In order to improve the ability of code, Here I list some DPs and present some examples in project to better illustrate the usage of DP.

4 types of DP (from runoob)
- Creatational
- Structural
- Behavioral
- J2EE 

sample language explaination
```
<class>(param){content}
<sonClass>:<fatherClass>
if then else
for then
foreach
fun(), var, obj-<>, [list]
DEF, USE
parts + parts
```

## creational DP

4 sub-types of CDP

- Singleton
    Only one **instance** in the whole project which states with 'static'. Get it through function GetInstance.
    `var gameManager = GameManager.GetInstance();`
- Factory
    Get one exact object with **name** or **ID**.
    `var Hunter = hunterFactory.GetHunter("hunter01");`
    HunterFactory above is a factory which could produce any kind of hunter as name indicated.  
    Futhermore, one could make a factory over factories.
    `var hunterFactory = FactoryFactory.GetHunterFactory(); // GetHunterFactory is a static method.`
- Builder
    Get a set of objects by **method**. The Builder will generate a object through a fixed pipeline.
    `var banana = missileBuilder.GetBanana(); // Banana will be addComponent with missile and emit.`
    Builder will have its own pipleline to combine stuff with fixed progress. Every step has abstract base class.
    e.g. 
    ```
    [<Missile>, <GuardianMissile>]:<missileBase>;
    [<Emit>, <Projectile>]:<actionMethon>;
    <MissileBuilder>{<missileBase> + <actionMethon>};
    ```
- Prototype
    Cache one prototype in Hashtable, return a **copy** while getting object.
    `var Hunter = hunterManager.GetHunter(1); // this method returned a copy of loaded hunter1 .`

## Structural DP

8 types of SDP

- Composite
    Treat as components.
    `<>{<> + <> + ...};`
- Decorator
    Get one more layer for a base class and change the content of it.
    `<DecoratorA>:<DecoratorAbase>:<Abase>(<A>:<ABase>);`
- Facade
    Packing all classes and provide an easy method to facade complex processes. 
    ```
    DEF := <>{a(<A>.x)+b(<B>.x)+c(<C>.x)}
    USE := <>.a();
    ```
- Adapter 
    For adapting other features, create an adapter insides which uses the same interface. 
    ```
    <newGen>:<Fatherclass>{
        if then oldpart;
        else <Adapter>:<Fatherclass>{<Other>};
    }
    ```
- Bridge
    The params of a brigde contain one indicated object and some vars. It will use two different classes inside.
    ```
    DEF := <Bridge>(vars, obj-<Another>):<BrigdeBase>{}
    USE := <BrigdeBase> a = Brigde(vars, new <Another>);
    ``` 
- Filter
    Filter will scan the objects who meet the criteria
    ```
    <FilterA>:<Filter>{filt(){ return foreach true};}
    [] = obj<Filter>-<FilterA>.filt([]);
    ```
- Flyweight
    A Factory with a hashtable to store the same objects without creating and destroying.
    ```
    <>{
        {} +
        Get(a){
            if a in {} return a
            else return create(a)
        }
    }
    ```
- Proxy
    Give some params to proxy and control proxy without redundancy params.
    ```
    DEF := <B>(vars):<X>{<A>:<X> + <A>.z(vars)};
    USE := <B>.z();
    ```

## Behavioral DB

- Chain of Responsibiliy
    `<A>{if return else next->B} <B>{if return else next->C} <C>{}`
- Command
    `<Order>.execute();`
- Interpreter
    recursive call
    `<Expression>{if <Expression>.interpret() return else return + interpret(){return}};`
- Iterator
    `<>{[]}; <Iterator>{hasNext() + Next(){return <>.[].next}}`
- Mediator
    `<Mediator>; <>{<Meiator>.x()}`
- Memento
    game save
    `<Memento> + <>{save(return <Memento>) + getfromMemento(<Memento>)}`
