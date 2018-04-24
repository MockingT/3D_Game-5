# 3D_Game-5
### 改进飞碟（Hit UFO）游戏  
- 游戏内容要求：  
按 adapter模式 设计图修改飞碟游戏  
使它同时支持物理运动与运动学（变换）运动  
- 游戏效果：  
![avatar](https://github.com/MockingT/3D_Game-5/blob/master/pictures/3d3.png)  
- 修改过后的文件结构：  
Prefab：Disk  
DiskData：上周的作业中DiskData用于随机生成一个Disk（随机位置，随机颜色）并且负责Disk的发射，回收，以及飞行过程，  本周将Disk的回收和飞行放入到ActionManager中  
DiskFactory：和上周没有区别，都是管理每一round中disk的出现落地被点击等动作以及创建Disk的List  
RoundController：负责每一Round的启动终止重置等，与上周相同  
ScoreRecorder：负责分数的记录，与上周相同  
ActionManager：从原DiskData中分理出负责Disk的运行，回收
![avatar](https://github.com/MockingT/3D_Game-5/blob/master/pictures/3d2.png)  

- 改动：  
![avatar](https://github.com/MockingT/3D_Game-5/blob/master/pictures/3d1.png)
