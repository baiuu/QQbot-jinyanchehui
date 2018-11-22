using Newbe.Mahua.MahuaEvents;
using System;
using System.Text.RegularExpressions;

namespace Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents
{
    /// <summary>
    /// 来自好友的私聊消息接收事件
    /// </summary>
    public class PrivateMessageFromFriendReceivedMahuaEvent1
        : IPrivateMessageFromFriendReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        //getDigit()函数从字符串中截取出数字并转换成整型
        public int getDigit(string str)
        {
            Regex r = new Regex("\\d+\\.?\\d*");    //设置匹配用的正则表达式
            bool isMatch = r.IsMatch(str);
            MatchCollection mc = r.Matches(str);
            string result = string.Empty;

            //生成处理后的字符串，应该只有数字部分
            for (int i = 0; i < mc.Count; i++)
            {
                result += mc[i];
            }

            return int.Parse(result);   //数字字符串转换为整型数
        }
        public string getDigit1(string str)
        {
            string result = str.Substring(str.IndexOf("=") + 1, (str.Length - str.IndexOf("=") - 1));
            return result;   //字符串保存
        }

        public PrivateMessageFromFriendReceivedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessFriendMessage(PrivateMessageFromFriendReceivedContext context)
        {
            // todo 填充处理逻辑
            //throw new NotImplementedException();
            //功能介绍
            _mahuaApi.SendPrivateMessage(context.FromQq)
                .Text("通过和机器人好友聊天，可以设置机器人的运行模式，禁言词条以及禁言QQ列表")
                .Newline()
                .Text("使用以下命令，可以更改相应的运行特性")
                .Newline()
                .Text("添加QQ号到禁言列表 addQQ=xxxxxxxx X是QQ号")
                .Newline()
                .Text("从QQ号列表删除QQ号 delQQ=xxxxxxxx X是QQ号")
                .Newline()
                .Text("删除所有QQ号 clearQQ")
                .Newline()
                .Text("查看所有Q0Q号 showQQ")
                .Newline()
                .Text("设置禁言时间 banTime=X X代表禁言时间，单位分钟")
                .Newline()
                .Text("添加禁言词条 addLine=X X代表禁言词条")
                .Newline()
                .Text("删除禁言词条 delLine=X X代表禁言词条")
                .Newline()
                .Text("删除所有禁言词条 clearLine")
                .Newline()
                .Text("查看所有禁言词条 showLine")
                .Newline()
                .Text("调整执行模式 modeSet=X X取1、2、3，分别代表只禁言指定QQ号的禁言词条，禁言所有人发出禁言词条和禁言随机概率禁言指定QQ的禁言词条")
                .Done();

            //匹配命令类型的正则表达式
            Regex addQQ = new Regex("addQQ");
            Regex ban = new Regex("banTime");
            Regex delQQ = new Regex("delQQ");
            Regex addLine = new Regex("addLine");
            Regex delLine = new Regex("delLine");
            Regex clearLine = new Regex("clearLine");
            Regex clearQQ = new Regex("clearQQ");
            Regex showQQ = new Regex("showQQ");
            Regex showLine = new Regex("showLine");
            Regex mode = new Regex("modeSet");

            //根据不同的输入命令调整相应的参数值
            if (addQQ.IsMatch(context.Message) == true)
            {
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Text("进入添加QQ模式 ")
                    .Done();
                string result = getDigit1(context.Message);
                int kongzhi = 0;
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Count; k++)
                {
                    if (result != Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[k])
                    {
                        kongzhi = 1;
                    }
                    else
                    {
                        kongzhi = 2;
                    }
                }
                if (kongzhi == 1 || kongzhi==0)
                {
                    Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Add(result);
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("该QQ已经添加进列表 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
                if(kongzhi==2)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("QQ号列表中已存在 ")
                        .Text(Convert.ToString(result))
                        .Done();

                }
            }

            if (ban.IsMatch(context.Message) == true)
            {
                int result = getDigit(context.Message);
                Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateTime = result;
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Text("禁言时间已调整为 ")
                    .Text(Convert.ToString(result))
                    .Done();
            }

            if (delQQ.IsMatch(context.Message) == true)
            {
                int test = 0;
                string result = getDigit1(context.Message);
                for (int i = Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Count - 1; i >= 0; i--)
                {
                    if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[i] == result)
                    {
                        Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Remove(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[i]);
                        test = 1;
                    }
                    else
                    {
                        test = 2;
                    }
                }
                if (test==1)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("该QQ已从列表删除 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
                if(test==2||test==0)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("QQ号列表中不存在 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
            }

            if (addLine.IsMatch(context.Message) == true)
            {
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Text("进入添加词条模式 ")
                    .Done();
                string result = getDigit1(context.Message);
                int kongzhi = 0;
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count; k++)
                {
                    if (result != Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[k])
                    {
                        kongzhi = 1;
                    }
                    else
                    {
                        kongzhi = 2;
                    }
                }
                if (kongzhi == 1 || kongzhi == 0)
                {
                    Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Add(result);
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("该词条已经添加进列表 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
                if (kongzhi==2)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                       .Text("词条列表中已存在 ")
                       .Text(Convert.ToString(result))
                       .Done();
                }
            }

            if (delLine.IsMatch(context.Message) == true)
            {
                int test = 0;
                string result = getDigit1(context.Message);
                for (int i = Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count - 1; i >= 0; i--)
                {
                    if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[i] == result)
                    {
                        Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Remove(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[i]);
                        test = 1;
                    }
                    else
                    {
                        test = 2;
                    }
                }
                if (test == 1)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("该词条已从列表删除 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
                if (test == 2 || test == 0)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("词条列表中不存在 ")
                        .Text(Convert.ToString(result))
                        .Done();
                }
            }

            if (clearLine.IsMatch(context.Message) == true)
            {
                Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Clear();
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Text("词条列表已清空 ")
                    .Done();
            }
            if (clearQQ.IsMatch(context.Message) == true)
            {
                Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Clear();
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Text("QQ号列表已清空 ")
                    .Done();
            }

            if (showQQ.IsMatch(context.Message) == true)
            {
                string list = "";
                int kongzhi = 0;
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Count; k++)
                {
                    list = list + Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[k] + ",";
                    kongzhi = 1;
                }
                if (kongzhi == 1)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("QQ号列表：")
                        .Newline()
                        .Text(list)
                        .Done();
                }
                if (kongzhi == 0)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("QQ号列表为空")
                        .Done();
                }
            }

            if (showLine.IsMatch(context.Message) == true)
            {
                string list="";
                int kongzhi = 0;
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count; k++)
                {
                    list = list+ Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[k] + ",";
                    kongzhi = 1;
                }
                if (kongzhi==1)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("禁言词条列表：")
                        .Newline()
                        .Text(list)
                        .Done();
                }
                if (kongzhi == 0)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("禁言词条列表为空")
                        .Done();
                }
            }

            if (mode.IsMatch(context.Message) == true)
            {
                int result = getDigit(context.Message);
                if (result < 1 || result > 3)
                {
                    _mahuaApi.SendPrivateMessage(context.FromQq)
                        .Text("设定执行模式错误：模式值只能为1，1，3中的一个！")
                        .Done();
                }
                else
                {
                    Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateMode = result;
                    switch (result)
                    {
                        case 1:
                            _mahuaApi.SendPrivateMessage(context.FromQq)
                                .Text("执行模式已设置为 常规模式，只禁言指定QQ号的禁言词条")
                                .Done(); break;
                        case 2:
                            _mahuaApi.SendPrivateMessage(context.FromQq)
                                .Text("执行模式已设置为 强力模式，禁言所有人发出禁言词条")
                                .Done(); break;
                        case 3:
                            _mahuaApi.SendPrivateMessage(context.FromQq)
                                .Text("执行模式已设置为 随机模式，随机禁言指定QQ号的禁言词条")
                                .Done(); break;
                    }
                }
            }

            // 不要忘记在MahuaModule中注册
        }
    }
}
