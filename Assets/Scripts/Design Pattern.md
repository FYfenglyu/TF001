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

- Execute (allocate once do once)

    - Command

        Convey different commant to an operator.

        `[<Command>] + <Executor>.execute(<Command>)`

    - State

        Convey context to different operator.

        `<Context> + [<State>{doAction(<Context>)}]`

    - Strategy

        Create strategy with different operation and execute with different params.

        `[<Operation>] + <Strategy>(<Operation>){execucte(param)}`

    - Mediator

        `<Mediator>; <>{<Meiator>.x()}`

- Execute (allocate once do a set)

    - Chain of Responsibiliy

        `<A>{if return else next->B} + <B>{if return else next->C} + <C>{}`

    - Iterator

        `<>{[]}; <Iterator>{hasNext() + Next(){return <>.[].next}}`

    - Template

        Define some abstract methods with a fixed progress. Execute fixed progress with overrided abstract methods.

        ```
        DEF := <T>{<A> + <B> + <C> + execute(){<A>;<B>;<C>}} + <R>:<T>{<A>' + <B>' + <C>'}
        USE := <R>.execute()
        ``` 

    - Observer

        Relation for one to multiple. Observee master and Observer slaves. 

        `<Obeservee>:<Obeservable>{L[<Observer>] + A(){foreach O in L O.do() }} + <RealObserver>:<Observer>(<Obeservable>.L.add(self)){do()}`

    - Visitor

        Relation for one to multiple. Visitor will go through all visitee.

        `<AVisitee>:<Visitee>{<Visitor>.visit(self)} + <AVisitor>:<Visitor>{visit(<Visitee>)}`

- Behavoir

    - Interpreter

        Recursive call.

        `<Expression>{if <Expression>.interpret() return else return + interpret(){return}};`

    - Memento

        Game save.

        `<Memento> + <CareTaker> + <>{save(return <Memento>) + getfromMemento(<Memento>)}`

    - NullObject

        Do default action for special cases.

        `<Null>:<Base>`


## J2EE DB

- MVC

    Model for data, View for display, Controller for logics.

    `<C>(<M> + <V>){} + <V>(<M>){} + <M>`

- Bussiness Delegate

    Delegate service for a client.

    `<Clinet>{askservice(<Delegate>)} + <Delegate>:<Service>{<ServiceLookup>.LookupService()} + <ServiceLookup>{[<Service>]} + <Service>{...}`

- Composite Entity

    `<>{<A> + <B>} + <A>{ <AA>+ <BB>} + <B>{...} + ...`

- Data Access Object

    `<struct> +<structDAOImpl>:<structDAO>{[<struct>] + op()}`

- Front Controller

    `[<Page>] + <Dispatcher>{} + <Controller>{<Dispatcher>.request()}`

- Intercepting Filter

    `<FilterManager>{<FilterChain>} + <FilterChain>(Msg){ foreach Filter(Msg)} + [<Filter>]`

- Service Locator

    `[<Service>] + [ServiceLocator]{<ServicePool> + <InitialContext>} + <ServicePool>{} + <InitialContext>`
    
- Transfer Object

    `<BO>{[<VO>]} + <VO>`