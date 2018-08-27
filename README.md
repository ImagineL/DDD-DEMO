# DDD-DEMO
> 一个简单的DDD领域驱动设计Demo.旨在解决一个经典的社会场景的编创化。场景：具体见下文图片。知识点：DDD设计实现，异步，定时器，事件总线，充血模型。


### 场景
![image](https://github.com/ImagineL/DDD-DEMO/blob/master/scence.png?raw=true)

### 设计初衷：
OO的编程思想应该于真实社会场景的生活思想是非常相似的。DDD的业务驱动设计，可以简单理解为：面向场景的设计。那么一个场景的组成：时间，地点，人物（人物描述，人物行为），与时刻发生的事实。人类社会有法律监听审判，编程社会有事件总线监听处理。因此：本DEMO虽精简，事件却必不可少。

### 项目结构：

```
Domain:领域层--正式项目请独立工程
Domain->Model:聚合跟--正式项目可配合ORM使用
Domain->Repository:仓储层--本项目无存储，正式项目请启用！
Domain->Service:服务层--多个聚合跟的参与的有边界的问题的服务；
Domian->Event:事件层--所有事件对象与事件处理器。正式项目如需溯源，请更改其中的EventBus代码。

```

### 最后一句
时间太晚，以后补上blog
Edit by LJJ