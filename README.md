# 八宝粥备份
正在开发中，未经严格的稳定性测试，对于重要数据请谨慎使用  
运行平台：  
| 运行环境 | 开发情况 | 怎么用 |
   |-------|-------|-------|
   | Windows7及以上 | 正在开发 | 运行安装程序安装完成后点击桌面图标，根据弹出提示下载安装运行库后即可使用 |
   | Linux | 完成Windows版后开始编写 | ？？？ |
   | MAC | ？？？ | ？？？ |
***
## 许可条款
   本项目基于 Apache License 2.0 发布。  
   修改或分发时，**必须保留所有原始版权声明**，并在显著位置标注改动。  
***
## 功能开发情况:
   | 功能 | 开发进度 |
|-------|-------|
| 使用RCON协议获取服务器在线人数（可选） | 80% |
| 使用RCON协议关闭MC服务端（可选） | ✔ |
| 备份完成后运行start.bat开启MC服务端（可选） | ✔ |
| 调用7-zip打包指定文件夹(文件),带黑名单 | 修bug中 |
| 调用7z增量备份(仅第一次运行后可用，可选)  | 修bug中 |
| 使用ftp/sftp协议将压缩包发送至ftp/sftp服务器 | 当前仅sftp |
| 定时运行 | ✔ |
| 作为系统服务自动运行 | 0% |
| 接管服务端shell环境，支持性能显示，多服同窗管理（与RCON二选一） | 0% |
| 自动识别服务端类型并提供配置文件快速编辑功能 | 0% |
| 接入各大模组/插件下载站，提供模组/插件下载功能 | 0% |
## 有什么用？
无需翻找令人疑惑的配置文件,直接在UI上编辑  
方便快捷定时备份MC服务端(还有你的各种资源文件),关闭后再备份有效避免了文件被锁定的问题  
快捷地查看/管理多个服务端（同一窗口上）  
快速地浏览/下载/安装插件模组  
快速编辑服务端配置文件  
## 初步配置
若使用RCON：  
在服务端根目录下找到server.properties  
修改enable-rcon=true  
修改rcon.password=你喜欢的密码  
修改rcon.port=你喜欢的端口（其实默认即可）  
在BBZBackup程序中的RCON(cli)设置窗口填写你刚刚设置的密码和端口并保存  
配置好所有可配置的（除非你不用）即可
