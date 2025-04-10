# 八宝粥备份
正在开发中，未经严格的稳定性测试，对于重要数据请谨慎使用  
运行平台：  
Windows7+ 安装完成后运行按照指示下载安装运行库  
Linux：完成Windows版后开始编写
MAC：？？？
## 许可条款
   本项目基于 Apache License 2.0 发布。  
   修改或分发时，**必须保留所有原始版权声明**，并在显著位置标注改动。  
## 功能:
1、使用RCON协议关闭MC服务端（可选）  
2、调用7-zip打包指定文件夹(文件),带黑名单  
3、增量备份(仅第一次运行后可用，可选)  
4、使用ftp/sftp协议将压缩包发送至ftp/sftp远程服务器  
5、定时运行  
———————————————————————  
1～5实现后才考虑支持的功能：  
6、运行为系统服务  
7、接管服务端shell环境，支持性能显示，多服同窗管理  
8、接入各大插件下载站，提供插件下载功能  
## 有什么用？
方便快捷定时备份MC服务端(还有你的各种资源文件),关闭后再备份有效避免了文件被锁定的问题  
无需翻找令人疑惑的配置文件,直接在UI上编辑  
## 怎么用  
在服务端根目录下找到server.properties  
修改enable-rcon=true  
修改rcon.password=你喜欢的密码  
修改rcon.port=你喜欢的端口（其实默认即可）  
在BBZBackup程序中的RCON(cli)设置窗口填写你刚刚设置的密码和端口并保存  
配置好所有可配置的（除非你不用）即可
