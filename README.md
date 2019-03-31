# 阿里巴巴nacos配置中心-C#客户端

[Nacos配置中心](https://github.com/alibaba/nacos)的C#客户端，更多关于Nacos配置中心的介绍，可以查看[Nacos配置中心Wiki](https://github.com/alibaba/nacos/wiki)。

### 特性

1. 容错兜底
2. 容易上手
3. 技术支持，有问题可加作者微信: suxiaolinKing

### 开发计划

- [ ] 增强容错机制
- [ ] 实现服务发现

## nuget安装

``` bash
Install-Package Nacos -Version 1.0.0
```

## 在App.config配置文件里配置nacos服务器连接参数

```xml
  <appSettings>
    <!-- Nacos配置中心启动配置 -->
    <add key="Nacos.Host" value="http://127.0.0.1:8848" />
    <add key="Nacos.Env" value="dev" />
    <add key="Nacos.DataId" value="LARAVEL" />
    <add key="Nacos.Group" value="DEFAULT_GROUP" />
    <add key="Nacos.Tenant" value="" />
  </appSettings>
```

## 拉取配置文件

```C#
string config = Nacos.init().runOnce();
```

拉取到的配置文件路径：当前工作目录/nacos/config/dev_nacos/snapshot/LARAVEL

配置文件保存的工作目录可以通过下面命令修改

## 长轮询拉取配置文件

```C#
Nacos.init().listener();
```

可放在线程池里后台运行

## 配置兜底方案

将兜底的配置文件放入下面的路径里

如果有给$tenant设置值，文件路径这样计算

工作目录/nacos/config/{$env}_nacos/config-data-{$tenant}/{$dataId}

否则

工作目录/nacos/config/{$env}_nacos/config-data/{$dataId}

nacos会在无法从配置中心查询配置文件时将读取上面的配置文件