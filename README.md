# QQbot-jinyanchehui
QQbot-禁言撤回群员消息  
基于Newbe.Mahua.Framework开发的QQ机器人，可以检测QQ群中的干话黑子行为并禁言相关的群成员  
Newbe.Mahua.Framework项目地址：https://github.com/newbe36524/Newbe.Mahua.Framework  
感谢Newbe编写的这个SDK和相应的教程！  

# 主要功能
顾名思义，禁言撤回群员消息是专门针对QQ群中的干话黑子现象开发的检测机器人，是各位群主治理干话黑子的辅助工具  

# 使用方法
运行build.bat可以生成用于不同机器人平台的插件，让相应的QQ机器人加载插件即可使用，详情参考Newbe的技术教程http://www.newbe.pro/docs/mahua/2018/06/10/Begin-First-Plugin-With-Mahua-In-v1.9.html  
建议一个机器人只接管一个QQ群，现在还没有添加同时管理多个群的功能。  

# 功能设置
为了满足各种不同的检测和禁言需求，本机器人允许调整一些参数  
添加运行有机器人的QQ为好友，向其发送特定消息即可改变这些参数  
addQQ=X：禁言目标的QQ号  
addLine=x； 禁言的词条  
delQQ=X：删除目标QQ号  
delLine=X：删除目标词条  
showQQ 展示QQ号列表  
showLine 暂时禁言词条列表  
clearQQ 清空QQ号列表  
clearLine 清空禁言词条  
banTime=X：实施禁言的时间，单位分钟  
modeSet=X：调整执行模式，可以只禁言指定QQ号的禁言词条，禁言所有人发出禁言词条和禁言随机概率禁言指定QQ的禁言词条

# TODO
尝试缩短处理消息接收事件的延迟  
探明消息撤回对复读计数的影响  
优化随机禁言功能  



