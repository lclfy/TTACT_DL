using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
//2003
using NPOI.HSSF.UserModel;
//2007以后
using NPOI.XSSF.UserModel;
using System.IO;
using System.Text.RegularExpressions;
using NPOI.SS.Util;
using CCWin;
using System.Configuration;
using System.Globalization;
using System.Collections.Specialized;
using TimeTableAutoCompleteTool.Models;
using SiEncrypt;

namespace TimeTableAutoCompleteTool
{
    public partial class Main : Skin_Mac
    {
        private Boolean hasText = false;
        private Boolean hasFilePath = false;
        private List<CommandModel> commandModel;
        private List<CommandModel> detectedCModel;
        List<string> ExcelFile = new List<string>();
        //命令excel
        string cmdExcelFile = "";
        List<string> EMUGarageFile = new List<string>();
        private string startPath = "";
        private string wrongTrain = "";
        private string commandText = "";
        private int lastCommandLength = 0;
        //动车所的昨天命令框拉伸到274像素，综控为164
        private string yesterdayCommandText = "";
        int fontSize = 12;
        string filePath = "";
        string addedTrainText = "";
        float dpiX, dpiY;
        string developer = "反馈请联系运转车间（或技术科）\n*亦可联系黄楠/高雅雯";
        string build = "build 01 - v190415";
        string readMe = "build01更新内容:\n"+
            " 初版，使用Excel文件作为客调命令来源，可以识别普通车次和加开车次";

        public Main()
        {
            InitializeComponent();
        }

        //检查激活状态
        
        private void checkRegist()
        {
            SiEncryptForm _encryptForm = new SiEncryptForm();
            _encryptForm.Show();
            _encryptForm.Hide();
            if (!_encryptForm.isRegist)
            {
                _encryptForm.ShowDialog();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Hide();
            }
        }
        

        private void Main_Load(object sender, EventArgs e)
        {
            checkRegist();
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            this.Size = new Size((int)(1033*(dpiX/96)),(int)(595*(dpiY/96)));
            this.Text = "列车运行计划自动核对工具";
            buildLBL.Text = build;
            start_Btn.Enabled = false;
            //TrainEarlyCaculator_Btn.Enabled = false;
            load();
            checkedChanged();
            contentOfDeveloper.IsBalloon = true;
            updateReadMe.IsBalloon = false;
            updateReadMe.AutoPopDelay = 60000;
            updateReadMe.AutomaticDelay = 60000;
            updateReadMe.InitialDelay = 0;
            updateReadMe.ReshowDelay = 0;
            // Force the ToolTip text to be displayed whether or not the form is active.
            updateReadMe.ShowAlways = true;
            updateReadMe.SetToolTip(this.buildLBL, readMe);
            FontSize_tb.Text = fontSize.ToString();
        }

        private void checkedChanged()
        {
                label111.Visible = true;
                label222.Visible = true;
                rightGroupBox.Visible = true;
                FontSize_tb.Visible = true;
            cmdExcelFile = "";
                startPath = "时刻表";
                secondStepText_lbl.Text = "2.选择时刻表文件（----支持多选----）";
                developerLabel.Text = "©郑州局集团公司郑州东车站";
                start_Btn.Text = "处理时刻表";
                ExcelFile = new List<string>();
                start_Btn.Enabled = false;
                filePath = "";
                filePathLBL.Text = "已选择：";
                Size _size = new Size(Convert.ToInt32(210 * (dpiX/96)), Convert.ToInt32(340 * (dpiY/96)));
                outputTB.Size = _size;
                searchResult_tb.Size = _size;
                hint_label.Text = "绿色为开行，红色为停开，白色为调令未含车次，黄色为次日接入车次。高峰/临客/周末在车次前含有标注\n*每次调图更换新时刻表后，请检查“加开车次”部分是否有误。";
           
        }

        private void save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Save();
            if (config.AppSettings.Settings["fontSize"] == null)
            {
                KeyValueConfigurationElement _k = new KeyValueConfigurationElement("fontSize", fontSize.ToString());
                config.AppSettings.Settings.Add(_k);
            }
            else
            {
                config.AppSettings.Settings["fontSize"].Value = fontSize.ToString();
            }
            config.Save();
            ConfigurationManager.RefreshSection("fontSize");
            ConfigurationManager.RefreshSection("modeSelect");
        }

        private void load()
        {
            int _modeSelect = 0;
            int.TryParse(ConfigurationManager.AppSettings["modeSelect"], out _modeSelect);
            int _fontSize = 0;
            int.TryParse(ConfigurationManager.AppSettings["fontSize"], out _fontSize);
            if (_fontSize != 0)
            {
                fontSize = _fontSize;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            save();
            base.OnClosing(e);
        }

        private void command_rTb_TextChanged(object sender, EventArgs e)
        {
            commandText = command_rTb.Text;
            if (command_rTb.Text.Length != 0)
            {
                hasText = true;
                startBtnCheck();
                if (command_rTb.Text.Length != lastCommandLength)
                    analyseCommand();
            }
            else
            {
                hasText = false;
                startBtnCheck();
            }
            lastCommandLength = command_rTb.Text.Length;
        }

        private void importTimeTable_Btn_Click(object sender, EventArgs e)
        {
            SelectPath();
        }

        private void startBtnCheck()
        {
            if (hasFilePath && hasText)
            {
                start_Btn.Enabled = true;
                //TrainEarlyCaculator_Btn.Enabled = true;
            }
            else
            {
                start_Btn.Enabled = false;
                //TrainEarlyCaculator_Btn.Enabled = false;
            }
        }

        private void start_Btn_Click(object sender, EventArgs e)
        {
            if (commandModel.Count != 0)
            {
                if (FontSize_tb.Text.Length == 0)
                {
                    FontSize_tb.Text = "12";
                }
                updateTimeTable();
            }
            else
            {
                MessageBox.Show("未检测到任何车次信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //从excel中获取命令
        private void getCommand()
        {
            if (cmdExcelFile == null)
            {
                MessageBox.Show("请重新选择日计划命令文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmdExcelFile.Length == 0)
            {
                MessageBox.Show("请重新选择日计划命令文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string fileName = "";
            fileName = cmdExcelFile;
            IWorkbook workbook = null;  //新建IWorkbook对象  
            if (fileName.IndexOf(".xls") > 0) // 2003版本  
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
                }
                catch (Exception e)
                {
                    MessageBox.Show("命令文件出现损坏（或文件无效）\n错误内容：" + e.ToString().Split('在')[0], "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            ISheet sheet1 = workbook.GetSheetAt(0);
            int counter = 0;
            string commandText = "";
            for (int i = 0; i <= sheet1.LastRowNum; i++)
            {
                IRow currentRow = sheet1.GetRow(i);
                if(currentRow != null)
                {
                    for(int j = 0; j <= currentRow.LastCellNum; j++)
                    {
                        if(currentRow.GetCell(j) != null)
                        {
                            ICell currentCell = currentRow.GetCell(j);
                            if(currentCell.ToString().Length != 0)
                                if(currentCell.ToString().Contains("CRH") ||
                                    currentCell.ToString().Contains("CR")||
                                    currentCell.ToString().Contains("车体"))
                                {
                                    commandText = commandText + currentCell.ToString().Replace("\nCR", "。\n，CR").Replace("\n车体未配置", "。\n，CR未配置").Replace("车体未配置", "，CR未配置");
                                }
                        }
                    }
                }
            }
            //加行数和CRH的杠,先加条目数
            //commandText = commandText.Replace(" ", "-");
            int index = 0;
            index = commandText.IndexOf("，CR");
            string addedText = "";
            string leftText = "";
            int startPos = index;
            int nextIndex = 0;
            if(index == -1)
            {
                MessageBox.Show("未找到任何车次信息，请确认是否选择了正确的调令文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            addedText = commandText.Substring(0, index);
            leftText = commandText.Substring(index, commandText.Length - index);
            while (nextIndex != -1)
            {
                if (index == -1)
                {
                    break;
                }
                addedText = addedText + leftText.Substring(0, nextIndex);
                leftText = leftText.Substring(nextIndex, leftText.Length - nextIndex);
                //leftText = commandText.Substring(index, commandText.Length - index + "、CR".Length);
                //循环从这里开始
                counter++;
                leftText = counter.ToString() + leftText;
                //查找位置后移
                nextIndex = leftText.IndexOf("，CR", (counter - 1).ToString().Length + "，CR".Length);
                //nextIndex = leftText.Substring((counter - 1).ToString().Length + "、CR".Length, leftText.Length).IndexOf("、CR");

                index = nextIndex;

            }
            addedText = addedText.Replace(" ", "-").Replace("CR未配置", "null-null") + leftText;
            command_rTb.Text = addedText;
        }

        private void analyseCommand(bool isYesterday = false, string detectedTrainRow = "")
        {   //分析客调命令
            //删除不需要的标点符号-字符
            int addedTrainCount = 0;
            
            try
            {
                string wrongNumber = "";
                List<string> _commands = removeUnuseableWord(isYesterday);
                String[] AllCommand;
                if (detectedTrainRow.Length == 0)
                {//不是抽样调查
                    //所有\n前面加上句号
                    string testStr = _commands[0];
                    testStr = testStr.Replace('\n', '。').Replace("。。", "。"); ;
                    AllCommand = testStr.Split('。');
                }
                else
                {
                    //string[] mf3={"c","c++","c#"};
                    AllCommand = new string[1];
                    AllCommand[0] = detectedTrainRow;
                }
                List<CommandModel> AllModels = new List<CommandModel>();
                addedTrainText = "";
                for (int i = 0; i < AllCommand.Length; i++)
                {
                    if (AllCommand[i].Contains("站") &&
                        AllCommand[i].Contains("开") && (
                        AllCommand[i].Contains("001") ||
                        AllCommand[i].Contains("002") ||
                        AllCommand[i].Contains("003") ||
                        AllCommand[i].Contains("004") ||
                        AllCommand[i].Contains("005") ||
                        AllCommand[i].Contains("006") ||
                        AllCommand[i].Contains("007") ||
                        AllCommand[i].Contains("008") ||
                        AllCommand[i].Contains("009")))
                    {//加开车次，单独存储
                        string addedCommand = AllCommand[i];
                        if (addedCommand.Contains("月") && addedCommand.Contains("日"))
                        {
                            addedTrainCount++;
                            try
                            {
                                addedTrainText = addedTrainText + addedTrainCount + "、" + addedCommand.Split('：')[addedCommand.Split('：').Length - 1].Remove(0, 2) + "。\n";
                            }
                            catch (Exception e)
                            {
                                addedTrainText = addedTrainText + addedTrainCount + "、" + addedCommand.Split('：')[0] + "。\n";
                            }

                        }
                    }
                    //取行号，便于查找
                    string index = AllCommand[i].Split('、')[0].Trim().Replace("\n", "");
                    String[] command;
                    String[] AllTrainNumberInOneRaw;
                    string trainModel = "null";
                    int streamStatus = 1;
                    //用于某些情况下标记不正常车次避免重复添加
                    Boolean isNormal = true;
                    int trainType = 0;
                    command = AllCommand[i].Split('：');
                    if (command.Length > 1)
                    {//非常规情况找车次
                        if (!command[1].Contains("G") &&
                        !command[1].Contains("D") &&
                        !command[1].Contains("C") &&
                        !command[1].Contains("J"))
                        {                //特殊数据
                                         //304、2018年02月11日，null-G4326/7：18：50分出库11日当天请令：临客线-G4326/7。
                                         //305、2018年02月11日，null - G4328 / 5：18：50分出库11日当天请令：临客线-G4328/5。
                            for (int r = 0; r < command.Length; r++)
                            {//从后往前开始找车次
                                if (command[command.Length - r - 1].Contains("G") ||
                                    command[command.Length - r - 1].Contains("D") ||
                                    command[command.Length - r - 1].Contains("C") ||
                                    command[command.Length - r - 1].Contains("J"))
                                {//找到了就用该项作为车次
                                    command[1] = command[command.Length - r - 1];
                                    break;
                                }
                            }
                        }
                        if (command[1].Contains("，"))
                        {//有逗号-逗号换横杠
                            command[1] = command[1].Replace('，', '-');
                        }
                        if (command[1].Contains("高峰"))
                        {
                            trainType = 1;
                        }
                        else if (command[1].Contains("临客"))
                        {
                            trainType = 2;
                        }
                        else if (command[1].Contains("周末"))
                        {
                            trainType = 3;
                        }

                        for (int timeCount = 0; timeCount < command.Length; timeCount++)
                        {
                            if (command[timeCount].Contains("CR"))
                            {
                                for (int word = 0; word < command[timeCount].Split('，').Length; word++)
                                {
                                    if (command[timeCount].Split('，')[word].Contains("CR") ||
                                        command[timeCount].Split('，')[word].Contains("cr"))
                                    {
                                        trainModel = command[timeCount].Split('，')[word];
                                    }
                                }

                            }
                        }


                        //找停运标记-特殊标记则直接加入模型
                        for (int n = 0; n < command.Length; n++)
                        {//从后往前开始找停运状态
                            if ((command[command.Length - n - 1].Contains("停运") &&
                                !command[command.Length - n - 1].Contains("G") &&
                                !command[command.Length - n - 1].Contains("D") &&
                                !command[command.Length - n - 1].Contains("C") &&
                                !command[command.Length - n - 1].Contains("J") &&
                                !command[command.Length - n - 1].Contains("00")) ||
                                 (command.Length > 2 && command[command.Length - n - 1].Contains("停运）")))
                            {//如果有-则继续判断是否全部停运
                             //特殊情况-部分停运，但停运部分使用括号标记
                             //76、2018年02月15日，CRH380AL-2590：DJ5732-G2001-(G662-G669：停运)。
                             //221、2018年02月22日，CRH380AL-2600：【0J5901-DJ5902-G6718(石家庄～北京西):停运】，0G4909-G4910-G801/4-G6611-G1559/8-G807-0G808。
                                if (command[command.Length - n - 1].Contains("停运）"))
                                {
                                    if (command[command.Length - n - 1].Contains("G") ||
                                        command[command.Length - n - 1].Contains("D") ||
                                        command[command.Length - n - 1].Contains("C") ||
                                        command[command.Length - n - 1].Contains("J") ||
                                        command[command.Length - n - 1].Contains("0"))
                                    {//如果停运标记后面还有车的话
                                        List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(command[command.Length - n - 1], @"[\u4e00-\u9fa5]", "").Replace('）', ' ').Replace('，', ' ').Split('-'), 1, trainType, trainModel, index);
                                        foreach (CommandModel model in tempModels)
                                        {
                                            if (!model.trainNumber.Contains("未识别"))
                                            {
                                                AllModels.Add(model);
                                            }
                                            else
                                            {
                                                wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                            }
                                        }
                                    }
                                    isNormal = false;
                                    AllTrainNumberInOneRaw = command[1].Split('-');
                                    //寻找车次中的括号左半部分
                                    //从前往后找，找到标记后的车次为停开
                                    bool stopped = false;
                                    for (int m = 0; m < AllTrainNumberInOneRaw.Length; m++)
                                    {
                                        if (AllTrainNumberInOneRaw[m].Contains("（G") ||
                                            AllTrainNumberInOneRaw[m].Contains("（D") ||
                                            AllTrainNumberInOneRaw[m].Contains("（C") ||
                                            AllTrainNumberInOneRaw[m].Contains("（J") ||
                                            AllTrainNumberInOneRaw[m].Contains("（0"))
                                        {//找到标记
                                            stopped = true;
                                        }
                                        //停开与开行分开进行建模
                                        if (stopped == true)
                                        {//不开
                                            List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[m], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), 0, trainType, trainModel, index);
                                            foreach (CommandModel model in tempModels)
                                            {
                                                if (!model.trainNumber.Contains("未识别"))
                                                {
                                                    AllModels.Add(model);
                                                }
                                                else
                                                {
                                                    wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                                }
                                            }
                                        }
                                        else if (stopped == false)
                                        {//开
                                            List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[m], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), 1, trainType, trainModel, index);
                                            foreach (CommandModel model in tempModels)
                                            {
                                                if (!model.trainNumber.Contains("未识别"))
                                                {
                                                    AllModels.Add(model);
                                                }
                                                else
                                                {
                                                    wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //正常情况-则默认所有车次停开
                                    streamStatus = 0;
                                }
                            }
                            break;
                        }
                        //判断某车底中仅停运一部分，且停运标记在车次中的特殊停运车次
                        //示例：236、2018年02月12日，CRH380AL-2607：0D5699(停运)-D5700(停运)-0G75-G75(郑州东始发)。
                        if (command[1].Contains("停"))
                        {
                            AllTrainNumberInOneRaw = command[1].Split('-');
                            //如果部分停开-则停开与开行分开进行建模
                            for (int h = 0; h < AllTrainNumberInOneRaw.Length; h++)
                            {
                                if (AllTrainNumberInOneRaw[h].Contains("停"))
                                {//去中文添加-由于部分情况下无法辨认小括号-因此必须在此处去除小括号
                                    List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[h], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), 0, trainType, trainModel, index);
                                    foreach (CommandModel model in tempModels)
                                    {
                                        if (!model.trainNumber.Contains("未识别"))
                                        {
                                            AllModels.Add(model);
                                        }
                                        else
                                        {
                                            wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                        }
                                    }
                                }
                                else
                                {
                                    List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[h], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), 1, trainType, trainModel, index);
                                    foreach (CommandModel model in tempModels)
                                    {
                                        if (!model.trainNumber.Contains("未识别"))
                                        {
                                            AllModels.Add(model);
                                        }
                                        else
                                        {
                                            wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                        }
                                    }
                                }
                            }
                        }
                        else if (command[1].Contains("次日"))
                        {

                            AllTrainNumberInOneRaw = command[1].Split('-');
                            //同理-部分次日-则次日与当日分开进行建模
                            for (int h = 0; h < AllTrainNumberInOneRaw.Length; h++)
                            {
                                if (AllTrainNumberInOneRaw[h].Contains("次日"))
                                {//去中文添加-由于部分情况下无法辨认小括号-因此必须在此处去除小括号
                                    List<CommandModel> tempModels;
                                    if (streamStatus != 0)
                                    {
                                        tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[h], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), 2, trainType, trainModel, index);
                                    }
                                    else
                                    {
                                        tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[h], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), streamStatus, trainType, trainModel, index);
                                    }
                                    foreach (CommandModel model in tempModels)
                                    {
                                        if (!model.trainNumber.Contains("未识别"))
                                        {
                                            AllModels.Add(model);
                                        }
                                        else
                                        {
                                            wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                        }
                                    }
                                }
                                else
                                {
                                    List<CommandModel> tempModels = trainModelAddFunc(Regex.Replace(AllTrainNumberInOneRaw[h], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-'), streamStatus, trainType, trainModel, index);
                                    foreach (CommandModel model in tempModels)
                                    {
                                        if (!model.trainNumber.Contains("未识别"))
                                        {
                                            AllModels.Add(model);
                                        }
                                        else
                                        {
                                            wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                        }
                                    }
                                }
                            }
                        }
                        else if (command[1].Contains("站") ||
                            (command[1].Contains("道") ||
                            command[1].Contains("到") ||
                            command[1].Contains("开")))
                        {//221、2018年03月20日，CRH380AL-2619：0J5901-DJ5902-G6718(石家庄～北京西)-G801/4（商丘站变更为26道）-0093(商丘站14:25开，郑州东徐兰场15:20到)-0094(郑州东徐兰场16:05开，郑州东动车所16.25到)。
                         //101、2018年03月20日，CRH380B-3763+3758：G1922/19（商丘站变更为27道）。
                         //把车次单独分离-去中文-去横杠-去括号内数字-在此处去除小括号
                         //去括号内数字方法-把括号前半部分换成空格，会变成G801/4 26，G1922/19 27
                         //识别时取空格前数字即可
                         //对于命令中含有时间的，Regex.Replace(X:XX && XX:XX)即可去除
                            AllTrainNumberInOneRaw = Regex.Replace(command[1], @"[\u4e00-\u9fa5]", "").Replace("（", " ").Replace("）", "").Split('-');
                            //把车次添加模型
                            List<CommandModel> tempModels = trainModelAddFunc(AllTrainNumberInOneRaw, streamStatus, trainType, trainModel, index);
                            foreach (CommandModel model in tempModels)
                            {
                                if (!model.trainNumber.Contains("未识别"))
                                {
                                    AllModels.Add(model);
                                }
                                else
                                {
                                    wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                }
                            }
                        }
                        else if (isNormal)
                        {//如果一切正常 则
                         //把车次单独分离-去中文-去横杠-由于部分情况下无法辨认小括号-因此必须在此处去除小括号
                            AllTrainNumberInOneRaw = Regex.Replace(command[1], @"[\u4e00-\u9fa5]", "").Replace("（", "").Replace("）", "").Split('-');
                            //把车次添加模型
                            List<CommandModel> tempModels = trainModelAddFunc(AllTrainNumberInOneRaw, streamStatus, trainType, trainModel, index);
                            foreach (CommandModel model in tempModels)
                            {
                                if (!model.trainNumber.Contains("未识别"))
                                {
                                    AllModels.Add(model);
                                }
                                else
                                {
                                    wrongNumber = wrongNumber + "第" + index + "行" + "-" + model.trainNumber + "\r\n";
                                }
                            }
                        }
                    }
                }
                //右方显示框内容
                String commands = "";
                foreach (CommandModel model in AllModels)
                {
                    String streamStatus = "";
                    String trainType = "";
                    if (model.streamStatus == 1)
                    {
                        streamStatus = "√开";
                    }
                    else
                    {
                        streamStatus = "×停";
                    }
                    switch (model.trainType)
                    {
                        case 0:
                            trainType = "";
                            break;
                        case 1:
                            trainType = "-高峰";
                            break;
                        case 2:
                            trainType = "-临客";
                            break;
                        case 3:
                            trainType = "-周末";
                            break;
                    }
                    if (model.secondTrainNumber.Equals("null"))
                    {
                        commands = commands + "第" + model.trainIndex.Trim() + "条-" + model.trainNumber + "-"+model.trainModel+"-"+model.trainId+"-" + streamStatus + trainType + "\r\n";
                    }
                    else
                    {
                        commands = commands + "第" + model.trainIndex.Trim() + "条-" + model.trainNumber + "/" + model.secondTrainNumber + "-" + model.trainModel +"-"+ model.trainId + "-" + streamStatus  + trainType + "\r\n";
                    }
                }
                wrongTrain = wrongNumber;
                if (wrongTrain != null)
                {
                    if (wrongTrain.Length != 0)
                    {
                        searchResult_tb.Text = "可能是识别错误车辆（或加开）：" + "\r\n" + wrongTrain;
                    }
                }
                outputTB.Text = "共" + AllModels.Count.ToString() + "趟" + "\r\n" + commands;
                if(detectedTrainRow.Length == 0)
                {
                        commandModel = AllModels;
                }
                else
                {
                    detectedCModel = AllModels;
                    //analyseCommand();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("出现错误，请重试，若持续错误请联系大连站技术科。\n" + e.ToString().Split('。')[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        public bool IsTrainNumber(string input)
        {//判断是否是符合规范的车次 若不符合 则给予识别错误提示
            bool _isTrainNumber = false;
            if (input.Contains("CR"))
            {
                return false;
            }
            Regex regexOnlyNumAndAlphabeta = new Regex(@"^[A-Za-z0-9]+$");
            Regex regexOnlyAlphabeta = new Regex(@"^[A-Za-z]+$");
            if (regexOnlyNumAndAlphabeta.IsMatch(input) &&
                !regexOnlyAlphabeta.IsMatch(input) &&
                input.Length < 8 &&
                input.Length > 1)
            {
                _isTrainNumber = true;
            }
            return _isTrainNumber;
        }

        private List<string> removeUnuseableWord(bool isYesterday = false,string detectedCommand = "")
        {//字符转换
            String standardCommand = "";
            if(detectedCommand.Length  == 0)
            {
                if (!isYesterday)
                {
                    standardCommand = command_rTb.Text.ToString();
                }
                else
                {
                    standardCommand = yesterdayCommandText;
                }
            }
            else
            {
                standardCommand = detectedCommand;
            }
            List<string> commands = new List<string>();
            standardCommand = removing(standardCommand.Trim());
            commands.Add(standardCommand.Trim());
            return commands;
        }

        private string removing(string standardCommand)
        {
            if (standardCommand.Contains(":"))
            { standardCommand = standardCommand.Replace(":", "："); }
            //删除客调命令中的时间
            //standardCommand = Regex.Replace(standardCommand, @"\d+：\d", "");
            standardCommand = Regex.Replace(standardCommand,@"[0-9]{2}(：)[0-9]{2}","");
            standardCommand = Regex.Replace(standardCommand, @"[0-9]{1}(：)[0-9]{2}", "");
            if (standardCommand.Contains("1\t2"))
                standardCommand = standardCommand.Replace("1\t2", "1、2");
            if (standardCommand.Contains("2\t2"))
                standardCommand = standardCommand.Replace("2\t2", "2、2");
            if (standardCommand.Contains("3\t2"))
                standardCommand = standardCommand.Replace("3\t2", "3、2");
            if (standardCommand.Contains("4\t2"))
                standardCommand = standardCommand.Replace("4\t2", "4、2");
            if (standardCommand.Contains("5\t2"))
                standardCommand = standardCommand.Replace("5\t2", "5、2");
            if (standardCommand.Contains("6\t2"))
                standardCommand = standardCommand.Replace("6\t2", "6、2");
            if (standardCommand.Contains("7\t2"))
                standardCommand = standardCommand.Replace("7\t2", "7、2");
            if (standardCommand.Contains("8\t2"))
                standardCommand = standardCommand.Replace("8\t2", "8、2");
            if (standardCommand.Contains("9\t2"))
                standardCommand = standardCommand.Replace("9\t2", "9、2");
            if (standardCommand.Contains("0\t2"))
                standardCommand = standardCommand.Replace("0\t2", "0、2");
            if (standardCommand.Contains("1道"))
                standardCommand = standardCommand.Replace("1道", "");
            if (standardCommand.Contains("I道"))
                standardCommand = standardCommand.Replace("I道", "");
            if (standardCommand.Contains("2道"))
                standardCommand = standardCommand.Replace("2道", "");
            if (standardCommand.Contains("3道"))
                standardCommand = standardCommand.Replace("3道", "");
            if (standardCommand.Contains("4道"))
                standardCommand = standardCommand.Replace("4道", "");
            if (standardCommand.Contains("5道"))
                standardCommand = standardCommand.Replace("5道", "");
            if (standardCommand.Contains("6道"))
                standardCommand = standardCommand.Replace("6道", "");
            if (standardCommand.Contains("7道"))
                standardCommand = standardCommand.Replace("7道", "");
            if (standardCommand.Contains("8道"))
                standardCommand = standardCommand.Replace("8道", "");
            if (standardCommand.Contains("9道"))
                standardCommand = standardCommand.Replace("9道", "");
            if (standardCommand.Contains("0道"))
                standardCommand = standardCommand.Replace("0道", "");
            if (standardCommand.Contains("V道"))
                standardCommand = standardCommand.Replace("V道", "");
            if (standardCommand.Contains("X道"))
                standardCommand = standardCommand.Replace("X道", "");

            string s1 = string.Empty;
            foreach (char c in standardCommand)
            {
                if (c == '\t' )
                {
                    continue;
                }
                s1 += c;
            }
            standardCommand = s1;
            if (standardCommand.Contains(","))
                standardCommand = standardCommand.Replace(",", "");
            if (standardCommand.Contains("~"))
                standardCommand = standardCommand.Replace("~", "");
            if (standardCommand.Contains("～"))
                standardCommand = standardCommand.Replace("～", "");
            if (standardCommand.Contains("〜"))
                standardCommand = standardCommand.Replace("〜", "");
            if (standardCommand.Contains("－"))
                standardCommand = standardCommand.Replace("－", "-");
            if (standardCommand.Contains("签发："))
                standardCommand = standardCommand.Replace("签发：", "");
            if (standardCommand.Contains("会签："))
                standardCommand = standardCommand.Replace("会签：", "");
            if (standardCommand.Contains("("))
                standardCommand = standardCommand.Replace("(", "（");
            if (standardCommand.Contains(")"))
                standardCommand = standardCommand.Replace(")", "）");
            if (standardCommand.Contains("d"))
                standardCommand = standardCommand.Replace("d", "D");
            if (standardCommand.Contains("g"))
                standardCommand = standardCommand.Replace("g", "G");
            if (standardCommand.Contains("c"))
                standardCommand = standardCommand.Replace("c", "C");
            if (standardCommand.Contains("j"))
                standardCommand = standardCommand.Replace("j", "J");
            //if (standardCommand.Contains("CRH"))
            // standardCommand = standardCommand.Replace("CRH", "");
            //if (standardCommand.Contains("CR"))
            // standardCommand = standardCommand.Replace("CR", "");
            if (standardCommand.Contains("；"))
                standardCommand = standardCommand.Replace("；", "");
            //特殊情况添加 221、2018年02月22日，CRH380AL-2600：【0J5901-DJ5902-G6718(石家庄～北京西):停运】，0G4909-G4910-G801/4-G6611-G1559/8-G807-0G808。
            //中括号/大括号转小括号 减少后期识别代码数量
            if (standardCommand.Contains("["))
                standardCommand = standardCommand.Replace("[", "（");
            if (standardCommand.Contains("—"))
                standardCommand = standardCommand.Replace("—", "-");
            if (standardCommand.Contains("]"))
                standardCommand = standardCommand.Replace("]", "）");
            if (standardCommand.Contains("【"))
                standardCommand = standardCommand.Replace("【", "（");
            if (standardCommand.Contains("】"))
                standardCommand = standardCommand.Replace("】", "）");
            if (standardCommand.Contains("{"))
                standardCommand = standardCommand.Replace("{", "）");
            if (standardCommand.Contains("}"))
                standardCommand = standardCommand.Replace("}", "）");
            if (standardCommand.Contains(" "))
                standardCommand = standardCommand.Replace(" ", "");
            if (standardCommand.Contains("人："))
                standardCommand = standardCommand.Replace("人：", "");
            return standardCommand;
        }

        private List<CommandModel> trainModelAddFunc(String[] AllTrainNumberInOneRaw, int streamStatus, int trainType, string trainModel, string index)
        {//建立车次模型-通用方法
            //处理单程双车次车辆
            int trainConnectType = -1;
            string trainId = "";
            List<CommandModel> AllModels = new List<CommandModel>();
            if (!trainModel.Equals("null"))
            {//0短编 1长编 2重联
                if (trainModel.Contains("L") ||
                    trainModel.Contains("2B") ||
                    trainModel.Contains("2E") ||
                    trainModel.Contains("1E") ||
                    trainModel.Contains("AF-A") ||
                    trainModel.Contains("BF-A"))
                {
                    trainConnectType = 1;
                }
                else if (trainModel.Contains("+"))
                {
                    trainConnectType = 2;
                }
                else if(trainModel.Contains("AF-B")||
                    trainModel.Contains("BF-B"))
                {//新增的 17节
                    trainConnectType = 3;
                }
                else
                {
                    trainConnectType = 0;
                }
            }
            if (trainConnectType == 2)
            {//重联，考虑不同型号重联情况
                Regex _regexOnlyNum = new Regex(@"^[0-9]+$");
                string[] trainIds = trainModel.Split('+');
                for (int i = 0; i < trainIds.Length; i++)
                {
                    for (int j = 0; j < trainIds[i].Split('-').Length; j++)
                    {
                        if (_regexOnlyNum.IsMatch(trainIds[i].Split('-')[j]))
                        {
                            if (!trainId.Contains("/"))
                            {
                                trainId = trainIds[i].Split('-')[j] + "/";
                            }
                            else
                            {
                                trainId = trainId + trainIds[i].Split('-')[j];
                            }
                        }
                    }
                }
            }
            else if (trainConnectType == 1)
            {//长编
                if (trainModel.Split('-').Length == 2)
                {
                    trainId = trainModel.Split('-')[1] + "L";
                }
                else if (trainModel.Split('-').Length == 3)
                {
                    trainId = trainModel.Split('-')[2] + "L";
                }
            }
            else
            {
                if (trainModel.Split('-').Length == 2)
                {
                    trainId = trainModel.Split('-')[1];
                }
                else if (trainModel.Split('-').Length == 3)
                {
                    trainId = trainModel.Split('-')[2];
                }
            }
            if (!trainModel.Contains("+"))
            {
                if(trainModel.Contains("-A"))
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim() + "-A";
                }
                else if (trainModel.Contains("-B"))
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim() + "-B";
                }
                else
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim();
                }
            }
            else
            {
                if (trainModel.Contains("-A"))
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim() + "-A+";
                }
                else if (trainModel.Contains("-B"))
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim() + "-B+";
                }
                else
                {
                    trainModel = trainModel.Split('-')[0].Replace("CRH", "").Replace("CR", "").Trim() + "+";
                }

            }
            //判断index是否为纯数字
            Regex regexOnlyNum = new Regex(@"^[0-9]+$");
            if (!regexOnlyNum.IsMatch(index))
            {
                char[] _indexChar = index.ToCharArray();
                string _tempIndexString = "";
                for (int i = 0; i < _indexChar.Length; i++)
                {
                    if (regexOnlyNum.IsMatch(_indexChar[i].ToString()))
                    {
                        _tempIndexString = _tempIndexString + _indexChar[i];
                    }
                    else
                    {
                        if (i == 0)
                        {//如果第一个字符就不是数字
                            index = "?";
                        }
                        else
                        {
                            index = _tempIndexString;
                            break;
                        }
                    }
                }
            }
            for (int k = 0; k < AllTrainNumberInOneRaw.Length; k++)
            {
                if (AllTrainNumberInOneRaw[k].Contains("G") ||
                   AllTrainNumberInOneRaw[k].Contains("D") ||
                   AllTrainNumberInOneRaw[k].Contains("C") ||
                   AllTrainNumberInOneRaw[k].Contains("J") ||
                   AllTrainNumberInOneRaw[k].Contains("00"))
                {
                    if (AllTrainNumberInOneRaw[k].Contains("/"))
                    {
                        string _trainNumber = "";
                        if (AllTrainNumberInOneRaw[k].Contains(" "))
                        {
                            _trainNumber = AllTrainNumberInOneRaw[k].Split(' ')[0];
                        }
                        else
                        {
                            _trainNumber = AllTrainNumberInOneRaw[k];
                        }
                        String[] trainWithDoubleNumber = _trainNumber.Split('/');
                        //先添加第一个车次
                        CommandModel m1 = new CommandModel();
                        m1.trainNumber = trainWithDoubleNumber[0].Trim();
                        m1.streamStatus = streamStatus;
                        m1.trainType = trainType;
                        m1.trainModel = trainModel;
                        m1.trainConnectType = trainConnectType;
                        m1.trainIndex = index;
                        m1.trainId = trainId;
                        if (!IsTrainNumber(m1.trainNumber))
                        {
                            m1.trainNumber = "未识别-(" + m1.trainNumber + ")";
                        }
                        Char[] firstTrainWord = trainWithDoubleNumber[0].ToCharArray();
                        String secondTrainWord = "";
                        for (int q = 0; q < firstTrainWord.Length; q++)
                        {
                            if (q != firstTrainWord.Length - trainWithDoubleNumber[1].Length)
                            {
                                secondTrainWord = secondTrainWord + firstTrainWord[q];
                            }
                            else
                            {
                                secondTrainWord = secondTrainWord + trainWithDoubleNumber[1];
                                //添加第二个车次
                                m1.secondTrainNumber = secondTrainWord.Trim();
                                m1.upOrDown = -1;
                                AllModels.Add(m1);
                                break;
                            }
                        }
                    }
                    else if (AllTrainNumberInOneRaw[k].Length != 0)
                    {
                        string _trainNumber = "";
                        if (AllTrainNumberInOneRaw[k].Contains(" "))
                        {
                            _trainNumber = AllTrainNumberInOneRaw[k].Split(' ')[0];
                        }
                        else
                        {
                            _trainNumber = AllTrainNumberInOneRaw[k];
                        }
                        if (_trainNumber.Contains("D928"))
                        {
                            int ll = 0;
                        }
                        CommandModel model = new CommandModel();
                        model.trainNumber = _trainNumber;
                        if (!IsTrainNumber(model.trainNumber))
                        {
                            model.trainNumber = "未识别-(" + model.trainNumber + ")";
                        }
                        else
                        {
                            int outNum = 0;
                            int.TryParse(model.trainNumber.ToCharArray()[model.trainNumber.ToCharArray().Length - 1].ToString(), out outNum);
                            if (outNum % 2 == 0)
                            {//上行
                                model.upOrDown = 0;
                            }
                            else
                            {//下行
                                model.upOrDown = 1;
                            }
                        }
                        model.secondTrainNumber = "null";
                        model.streamStatus = streamStatus;
                        model.trainType = trainType;
                        model.trainModel = trainModel;
                        model.trainConnectType = trainConnectType;
                        model.trainIndex = index;
                        model.trainId = trainId;
                        
                        AllModels.Add(model);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return AllModels;
        }


        //使用NPOI进行Excel操作
        private void SelectPath(bool selectCommandFile = false)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();   //显示选择文件对话框 
            openFileDialog1.Filter = "Excel 文件 |*.xlsx;*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!selectCommandFile)
                {
                    openFileDialog1.InitialDirectory = Application.StartupPath + "\\" + startPath + "\\";
                    openFileDialog1.Multiselect = true;
                    ExcelFile = new List<string>();
                    int fileCount = 0;
                    String fileNames = "已选择：";
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        fileCount++;
                        ExcelFile.Add(fileName);
                    }
                    this.filePathLBL.Text = "已选择：" + fileCount + "个文件";
                    hasFilePath = true;
                }
                else
                {
                    cmdExcelFile = "";
                    openFileDialog1.Multiselect = false;
                    int fileCount = 0;
                    String fileNames = "已选择：";
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        fileCount++;
                        cmdExcelFile = fileName;
                    }
                    this.commandFile_lbl.Text = "已选择：" + cmdExcelFile;
                    hasFilePath = true;
                }
                startBtnCheck();
            }
        }

        private void updateTimeTable()
        {
            if (ExcelFile == null)
            {
                MessageBox.Show("请重新选择时刻表文件~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (string fileName in ExcelFile)
            {
                IWorkbook workbook = null;  //新建IWorkbook对象 
                                            //车次统计
                int allTrainsCount = 0;
                int allPsngerTrainsCount = 0;
                int stoppedTrainsCount = 0;
                int allTrainsInTimeTable = 0;
                string checkedText = "";
                try
                {
                    FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    if (fileName.IndexOf(".xlsx") > 0) // 2007版本  
                    {
                        try
                        {
                            workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook  
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("时刻表文件出现损坏（或时刻表无效）\n错误内容：" + e.ToString().Split('在')[0], "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                    }
                    else if (fileName.IndexOf(".xls") > 0) // 2003版本  
                    {
                        try
                        {
                            workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("时刻表文件出现损坏\n错误内容：" + e.ToString().Split('在')[0], "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //表格样式
                    ICellStyle stoppedTrainStyle = workbook.CreateCellStyle();
                    stoppedTrainStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                    stoppedTrainStyle.FillPattern = FillPattern.SolidForeground;
                    stoppedTrainStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                    stoppedTrainStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    stoppedTrainStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    stoppedTrainStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    stoppedTrainStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    HSSFFont font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";//字体  
                    font.FontHeightInPoints = short.Parse(fontSize.ToString());//字号  
                    font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                    stoppedTrainStyle.SetFont(font);

                    ICellStyle normalTrainStyle = workbook.CreateCellStyle();
                    normalTrainStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                    normalTrainStyle.FillPattern = FillPattern.SolidForeground;
                    normalTrainStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                    normalTrainStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    normalTrainStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    normalTrainStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    normalTrainStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                    normalFont.FontName = "宋体";//字体  
                    normalFont.FontHeightInPoints = short.Parse(fontSize.ToString());//字号  
                    normalFont.IsBold = true;
                    normalTrainStyle.SetFont(normalFont);

                    ICellStyle tomorrowlTrainStyle = workbook.CreateCellStyle();
                    tomorrowlTrainStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightYellow.Index;
                    tomorrowlTrainStyle.FillPattern = FillPattern.SolidForeground;
                    tomorrowlTrainStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightYellow.Index;
                    tomorrowlTrainStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    tomorrowlTrainStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    tomorrowlTrainStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    tomorrowlTrainStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    tomorrowlTrainStyle.SetFont(normalFont);

                    ICellStyle removeColors = workbook.CreateCellStyle();
                    removeColors.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                    removeColors.FillPattern = FillPattern.SolidForeground;
                    removeColors.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                    removeColors.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    removeColors.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    removeColors.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    removeColors.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    ICellStyle addedTrainStyle = workbook.CreateCellStyle();
                    addedTrainStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                    addedTrainStyle.FillPattern = FillPattern.SolidForeground;
                    addedTrainStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                    addedTrainStyle.WrapText = true;
                    addedTrainStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直

                    HSSFFont addFont = (HSSFFont)workbook.CreateFont();
                    addFont.FontName = "宋体";//字体  
                    addFont.FontHeightInPoints = 12;//字号  
                    addFont.IsBold = false;
                    addedTrainStyle.SetFont(addFont);

                    ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表  
                    IRow row;// = sheet.GetRow(0);            //新建当前工作表行数据  
                    if (sheet.GetRow(0) == null)
                    {
                        sheet.CreateRow(0);
                    }
                    if (sheet.GetRow(0).GetCell(0) == null)
                    {
                        sheet.GetRow(0).CreateCell(0);
                    }
                    string title = sheet.GetRow(0).GetCell(0).ToString().Trim();
                    if (title.Contains("-"))
                    {
                        title = title.Split('-')[1];
                    }
                    int hour = -1;
                    int.TryParse(DateTime.Now.ToString("HH"), out hour);
                    if (hour >= 0 && hour <= 16)
                    {
                        title = DateTime.Now.ToString("yyyy年MM月dd日-") + title;
                    }
                    else
                    {
                        title = DateTime.Now.AddDays(1).ToString("yyyy年MM月dd日-") + title;
                    }
                    sheet.GetRow(0).GetCell(0).SetCellValue(title);
                    //寻找加开车次字样，没有的创建
                    bool hasGotIt = false;
                    int lastCell = 0;
                    for(int searchRow = 0; searchRow <= sheet.LastRowNum; searchRow++)
                    {
                        /*
                        if(!title.Contains("京广") && !title.Contains("徐兰"))
                        {
                            break;
                        }
                        */
                        IRow _searchRow = sheet.GetRow(searchRow);
                        if(_searchRow == null)
                        {
                            sheet.CreateRow(searchRow);
                            _searchRow = sheet.GetRow(searchRow);
                        }
                        if(_searchRow.LastCellNum > lastCell)
                        {
                            if(_searchRow.GetCell(_searchRow.LastCellNum) != null &&_searchRow.GetCell(_searchRow.LastCellNum).ToString().Trim().Length != 0)
                            {
                                    lastCell = _searchRow.LastCellNum;
                            }
                            else
                            {//找最后一列有字的
                                for(int reverise = _searchRow.LastCellNum; reverise > 0; reverise--)
                                {
                                    if (_searchRow.GetCell(reverise) != null && _searchRow.GetCell(reverise).ToString().Trim().Length != 0)
                                    {
                                        if(reverise > lastCell)
                                        {
                                            lastCell = reverise;
                                        }
                                        break;
                                    }
                                }
                            }

                        }
                        for(int searchColumn = 0; searchColumn <= _searchRow.LastCellNum; searchColumn++)
                        {
                            if (_searchRow.GetCell(searchColumn) != null)
                            {
                                if (_searchRow.GetCell(searchColumn).ToString().Contains("加开车次"))
                                {
                                    hasGotIt = true;
                                }
                            }
                            else
                            {
                                continue;
                            }
                            if (hasGotIt)
                            {
                                break;
                            }
                        }
                    }
                    if (!hasGotIt)
                    {
                        int currentLast = sheet.LastRowNum;
                        for(int createRow = 1; createRow < 8; createRow++)
                        {
                            IRow _createRow = sheet.CreateRow(createRow + currentLast);
                            switch (createRow)
                            {
                                case 1:
                                    for (int cell = 0; cell < lastCell; cell++)
                                    {
                                        if(cell == 0)
                                        {
                                            _createRow.CreateCell(cell).SetCellValue("加开车次");
                                        }
                                        else
                                        {
                                            _createRow.CreateCell(cell);
                                        }
                                    }
                                    break;
                                default:
                                    for (int cell = 0; cell < lastCell; cell++)
                                    {
                                            _createRow.CreateCell(cell);
                                    }
                                    break;
                            }
                        }
                        //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
                        sheet.AddMergedRegion(new CellRangeAddress(currentLast + 1, currentLast + 1, 0, lastCell ));
                        sheet.AddMergedRegion(new CellRangeAddress(currentLast + 2, sheet.LastRowNum, 0, lastCell));
                    }
                    for (int i = 0; i <= sheet.LastRowNum; i++)  //对工作表每一行  
                    {
                        row = sheet.GetRow(i);   //row读入第i行数据  
                        if (row != null)
                        {
                            if (row.GetCell(0) != null)
                            {
                                if (row.GetCell(0).ToString().Contains("加开车次") && !sheet.GetRow(0).GetCell(0).ToString().Contains("城际"))
                                {
                                    IRow addedRow;
                                    if (sheet.GetRow(i + 1) == null)
                                    {
                                        sheet.CreateRow(i + 1);
                                    }
                                    addedRow = sheet.GetRow(i + 1);
                                    if (addedRow.GetCell(0) == null)
                                    {
                                        addedRow.CreateCell(0);
                                    }
                                    addedRow.GetCell(0).CellStyle = addedTrainStyle;
                                    addedRow.GetCell(0).SetCellValue(addedTrainText);
                                }
                            }
                            for (int j = 0; j <= row.LastCellNum; j++)  //对工作表每一列  
                            {
                                if (row.GetCell(j) != null)
                                {
                                    if (row.GetCell(j).ToString().Contains("G") ||
                                        row.GetCell(j).ToString().Contains("D") ||
                                        row.GetCell(j).ToString().Contains("C") ||
                                        row.GetCell(j).ToString().Contains("J"))
                                    {//把车次表格先刷白去字
                                        if (!row.GetCell(j).ToString().Contains("由") &&
                                            !row.GetCell(j).ToString().Contains("续") &&
                                            !row.GetCell(j).ToString().Contains("开行")&&
                                            !row.GetCell(j).ToString().Contains("折")&&
                                            row.GetCell(j).ToString().Length < 15)
                                        {
                                            //时刻表中车次+1
                                            allTrainsInTimeTable++;
                                            //去中文后再找-去掉高峰-周末-临客等字
                                            row.GetCell(j).CellStyle = removeColors;
                                            row.GetCell(j).SetCellValue(Regex.Replace(row.GetCell(j).ToString().Replace("√", "").Replace("×", "").Replace("(", "").Replace(")", ""), @"[\u4e00-\u9fa5]", ""));
                                        }
                                        else
                                        {
                                            //这个格子不是要找的
                                            continue;
                                        }
                                        //若遍历后都没有找到 停运+1
                                        bool ContainsTrainNumber = false;
                                        foreach (CommandModel model in commandModel)
                                        {//根据客调命令刷单元格颜色
                                            if (row.GetCell(j).ToString().Trim().Replace("GF","").Replace("ZM","").Equals(model.trainNumber) ||
                                                row.GetCell(j).ToString().Trim().Replace("GF", "").Replace("ZM", "").Equals(model.secondTrainNumber))
                                            {
                                                ContainsTrainNumber = true;
                                                //车次统计+1
                                                allTrainsCount++;
                                                if (!row.GetCell(j).ToString().Trim().Contains("0G") &&
                                                    !row.GetCell(j).ToString().Trim().Contains("0D") &&
                                                    !row.GetCell(j).ToString().Trim().Contains("0J") &&
                                                    !row.GetCell(j).ToString().Trim().Contains("0C") &&
                                                    !row.GetCell(j).ToString().Trim().Contains("00") &&
                                                    !row.GetCell(j).ToString().Trim().Contains("DJ"))
                                                {
                                                    allPsngerTrainsCount++;
                                                }
                                                if (model.trainType == 1)
                                                {
                                                    row.GetCell(j).SetCellValue("高峰" + row.GetCell(j).ToString().Trim());
                                                }
                                                else if (model.trainType == 2)
                                                {
                                                    row.GetCell(j).SetCellValue("临客" + row.GetCell(j).ToString().Trim());
                                                }
                                                else if (model.trainType == 3)
                                                {
                                                    row.GetCell(j).SetCellValue("周末" + row.GetCell(j).ToString().Trim());
                                                }
                                                if (model.streamStatus == 1)
                                                {
                                                    row.GetCell(j).SetCellValue("√" + row.GetCell(j).ToString().Trim());
                                                    row.GetCell(j).CellStyle = normalTrainStyle;
                                                }
                                                else if (model.streamStatus == 0)
                                                {
                                                    row.GetCell(j).SetCellValue("×" + row.GetCell(j).ToString().Trim());
                                                    stoppedTrainsCount++;
                                                    row.GetCell(j).CellStyle = stoppedTrainStyle;
                                                }
                                                else if (model.streamStatus == 2)
                                                {
                                                    row.GetCell(j).SetCellValue("明√" + row.GetCell(j).ToString().Trim());
                                                    row.GetCell(j).CellStyle = tomorrowlTrainStyle;
                                                }

                                            }
                                        }
                                        if (!ContainsTrainNumber)
                                        {//查错
                                            string trainNum = row.GetCell(j).ToString().Trim();
                                            //单车号
                                            bool gotIt = false;
                                            if (commandText.Contains(trainNum))
                                            {
                                                //智能纠错
                                                checkedText = checkedText + " " + trainNum;
                                                int status = searchAndHightlightUnresolvedTrains(trainNum,0);
                                                if (status == 1)
                                                {
                                                    row.GetCell(j).SetCellValue("√" + row.GetCell(j).ToString().Trim());
                                                    row.GetCell(j).CellStyle = normalTrainStyle;
                                                }
                                                else if(status == 0)
                                                {
                                                    row.GetCell(j).SetCellValue("×" + row.GetCell(j).ToString().Trim());
                                                    stoppedTrainsCount++;
                                                    row.GetCell(j).CellStyle = stoppedTrainStyle;
                                                }
                                                gotIt = true;
                                                if (status == -1)
                                                {//如果选择发现找到的都不是这个车
                                                    gotIt = false;
                                                }

                                            }
                                            //双车号
                                            if (!gotIt)
                                            {
                                                string splitedNumber = "";
                                                int originalTrainNumber = 0;
                                                string trainType = "";
                                                string targetString = "";
                                                if (trainNum.Contains("G"))
                                                {
                                                    trainType = "G";
                                                }
                                                else if (trainNum.Contains("D"))
                                                {
                                                    trainType = "D";
                                                }
                                                else if (trainNum.Contains("C"))
                                                {
                                                    trainType = "C";
                                                }

                                                foreach (char item in trainNum)
                                                {
                                                    if (item >= 48 && item <= 58)
                                                    {
                                                        splitedNumber += item;
                                                    }
                                                }
                                                int.TryParse(splitedNumber, out originalTrainNumber);
                                                string targetTrainNum = "";
                                                if (originalTrainNumber != 0)
                                                {
                                                    hasGotIt = false;
                                                    for (int ij = 0; ij < 4; ij++)
                                                    {//+1 -1 +3 -3分别试一遍(试该车次的第二个车号)
                                                        if (hasGotIt)
                                                        {
                                                            break;
                                                        }
                                                        switch (ij)
                                                        {
                                                            case 0:
                                                                targetTrainNum = trainType + (originalTrainNumber + 1).ToString() + "/";
                                                                break;
                                                            case 1:
                                                                targetTrainNum = trainType + (originalTrainNumber - 1).ToString() + "/";
                                                                break;
                                                            case 2:
                                                                targetTrainNum = trainType + (originalTrainNumber + 3).ToString() + "/";
                                                                break;
                                                            case 3:
                                                                targetTrainNum = trainType + (originalTrainNumber - 3).ToString() + "/";
                                                                break;
                                                        }
                                                        for (int index = 0; index < trainNum.Length; index++)
                                                        {
                                                            if (trainNum[index] != targetTrainNum[index])
                                                            {
                                                                targetTrainNum = targetTrainNum + trainNum[index];
                                                            }
                                                        }
                                                        if (commandText.Contains(targetTrainNum))
                                                        {
                                                            //智能纠错
                                                            checkedText = checkedText + " " + targetTrainNum;
                                                            int status = searchAndHightlightUnresolvedTrains(targetTrainNum,0);
                                                            if (status == 1)
                                                            {
                                                                row.GetCell(j).SetCellValue("√" + row.GetCell(j).ToString().Trim());
                                                                row.GetCell(j).CellStyle = normalTrainStyle;
                                                            }
                                                            else
                                                            {
                                                                row.GetCell(j).SetCellValue("×" + row.GetCell(j).ToString().Trim());
                                                                stoppedTrainsCount++;
                                                                row.GetCell(j).CellStyle = stoppedTrainStyle;
                                                            }
                                                            gotIt = true;
                                                            hasGotIt = true;
                                                        }
                                                    }
                                                }
                                            }
                                            if (!gotIt)
                                            {
                                                row.GetCell(j).SetCellValue("×" + row.GetCell(j).ToString().Trim());
                                                row.GetCell(j).CellStyle = stoppedTrainStyle;
                                                stoppedTrainsCount++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    /*重新修改文件指定单元格样式*/
                    FileStream fs1 = File.OpenWrite(fileName);
                    workbook.Write(fs1);
                    fs1.Close();
                    fileStream.Close();
                    workbook.Close();
                    //显示车次总数
                    AllTrainsCountLBL.Text = allTrainsCount.ToString();
                    AllPsngerTrainsCountLBL.Text = allPsngerTrainsCount.ToString();
                    stoppedTrainsCountLBL.Text = stoppedTrainsCount.ToString();
                    AllTrainsInTimeTableLBL.Text = allTrainsInTimeTable.ToString();
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    //info.WorkingDirectory = Application.StartupPath;
                    info.FileName = fileName;
                    info.Arguments = "";
                    if (checkedText.Length != 0)
                    {
                        //MessageBox.Show("请人工核对以下车次（时刻表内有标注）：\n" + checkedText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        try
                        {
                            FileStream file = new FileStream(Application.StartupPath + "\\" + "ErrorLog-" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                            StreamWriter writer = new StreamWriter(file);
                            writer.WriteLine("车次：" + checkedText + "\n\n" + command_rTb.Text);
                            writer.Close();
                            file.Close();
                        }
                        catch (Exception _e)
                        {

                        }
                    }
                    try
                    {
                        System.Diagnostics.Process.Start(info);
                    }
                    catch (System.ComponentModel.Win32Exception we)
                    {
                        MessageBox.Show(this, we.Message);
                        return;
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("选中的部分时刻表文件正在使用中，请关闭后重试\n" + fileName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkedChanged();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkedChanged();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkedChanged();
        }


        //下面三个方法合并起来是查错用的
        private int searchAndHightlightUnresolvedTrains(string find, int type,int isYesterDay = 0,string secondTrainNumber = "")
        {//找到未识别车并高亮显示(返回0-停开，1-开行，-1-未找到，2-综控-一整行车都没有23333)-行车，东所
            //isYesterday : 0今天 1综控昨天 2动车所昨天
            //在模型内添加新车-综控
            //type 0 1 2行车综控东所
            int index = 0;
            if (isYesterDay == 0)
            {//不是昨天
                index = command_rTb.Find(find, RichTextBoxFinds.WholeWord);//调用find方法，并设置区分全字匹配
            }
            int startPos = index;
            int nextIndex = 0;
            while (nextIndex != startPos)//循环查找字符串，并用红色加粗12号Times New Roman标记之
            {
                if (isYesterDay == 0)
                {
                    if (index == -1)
                    {
                        break;
                    }
                    command_rTb.SelectionStart = index;
                    command_rTb.SelectionLength = find.Length;
                    command_rTb.SelectionColor = Color.Red;
                    command_rTb.SelectionFont = new Font("Times New Roman", (float)12, FontStyle.Bold);
                    command_rTb.Focus();
                    DialogResult result = MessageBox.Show("请人工核对\n" + find + "次是否为当前标红内容？\n(*请注意核查同一条命令内其他车次是否正确)", "人工核对", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (type == 0)
                        {//行车
                            DialogResult resultTrainStatus = MessageBox.Show(find + "次在客调命令中是否开行？（开行选择“是”，停运/待定等选择“否”）", "人工核对", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (resultTrainStatus == DialogResult.Yes)
                            {
                                return 1;
                            }
                            else if (resultTrainStatus == DialogResult.No)
                            {
                                return 0;
                            }
                        }
                        else if (type == 1)
                        {//把命令分行，找车次所在行有没有其他车次，找对应车次车号赋给新车，然后再选择停运情况
                            string currentRow = "";
                            string[] _aCommands = removeUnuseableWord(false)[0].Split('。');
                            for(int i = 0; i < _aCommands.Length; i++)
                            {//笨方法
                                if(_aCommands[i].Contains(find)&&
                                    !_aCommands[i].Contains(find + "0") &&
                                    !_aCommands[i].Contains(find + "1") &&
                                    !_aCommands[i].Contains(find + "2") &&
                                    !_aCommands[i].Contains(find + "3") &&
                                    !_aCommands[i].Contains(find + "4") &&
                                    !_aCommands[i].Contains(find + "5") &&
                                    !_aCommands[i].Contains(find + "6") &&
                                    !_aCommands[i].Contains(find + "7") &&
                                    !_aCommands[i].Contains(find + "8") &&
                                    !_aCommands[i].Contains(find + "9") &&
                                    (_aCommands[i].Contains("CR")|| _aCommands[i].Contains("null")))
                                {
                                    currentRow = _aCommands[i];
                                    break;
                                }
                            }
                            if(currentRow.Length != 0)
                            {
                                analyseCommand(false,currentRow);
                            }
                            if(detectedCModel.Count != 0)
                            {
                                CommandModel _tempCM = new CommandModel();
                                _tempCM.trainNumber = find.Split('/')[0];
                                _tempCM.secondTrainNumber = secondTrainNumber;
                               // _tempCM.secondTrainNumber = "null";
                                foreach(CommandModel _cm in detectedCModel)
                                {
                                    _tempCM.trainIndex = _cm.trainIndex;
                                    _tempCM.trainModel = _cm.trainModel;
                                    _tempCM.trainId = _cm.trainId;
                                    _tempCM.trainConnectType = _cm.trainConnectType;
                                }
                                DialogResult resultTrainStatus = MessageBox.Show(find + "次在客调命令中是否开行？（开行选择“是”，停运/待定等选择“否”）", "人工核对", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (resultTrainStatus == DialogResult.Yes)
                                {
                                    _tempCM.streamStatus = 1;
                                }
                                else if (resultTrainStatus == DialogResult.No)
                                {
                                    _tempCM.streamStatus = 0;
                                }
                                commandModel.Add(_tempCM);
                            }
                            else
                            {//一整行车都没有，自己去核对吧
                                return 2;
                            }
                            detectedCModel = new List<CommandModel>();
                        }
                    }
                    nextIndex = command_rTb.Find(find, index + find.Length, RichTextBoxFinds.WholeWord);
                    if (nextIndex == -1)//若查到文件末尾，则重置nextIndex为初始位置的值，使其达到初始位置，顺利结束循环，否则会有异常。
                        nextIndex = startPos;
                    index = nextIndex;
                }
            }
            return -1;
        }

        private string checkingError(string rawTrainNumber,List<CommandModel> cModel, string cmdText, bool isYesterday = false)
        {
            string firstTrainNumber = "";
            string secondTrainNumber = "";
            if(rawTrainNumber == null)
            {
                return "";
            }
            if (!rawTrainNumber.Contains("/"))
            {
                firstTrainNumber = rawTrainNumber;
            }
            else
            {
                string[] trainWithDoubleNumber = rawTrainNumber.Split('/');
                firstTrainNumber = trainWithDoubleNumber[0];
                Char[] firstTrainWord = trainWithDoubleNumber[0].ToCharArray();
                for (int q = 0; q < firstTrainWord.Length; q++)
                {
                    if (q != firstTrainWord.Length - trainWithDoubleNumber[1].Length)
                    {
                        secondTrainNumber = secondTrainNumber + firstTrainWord[q];
                    }
                    else
                    {
                        secondTrainNumber = secondTrainNumber + trainWithDoubleNumber[1];
                        break;
                    }
                }
            }
            bool hasGotIt = false;
            foreach (CommandModel _cm in cModel)
            {
                if (_cm.trainNumber.Equals(firstTrainNumber) || (_cm.trainNumber.Length != 0 && _cm.trainNumber.Equals(secondTrainNumber)))
                {//是同一趟车
                    hasGotIt = true;
                    break;
                }
            }
            if (hasGotIt)
            {//找到了说明没错
                return "";
            }
            else
            {//如果已识别车次里没有，就从客调里找找
                if (cmdText.Contains(firstTrainNumber) || secondTrainNumber.Length != 0 && cmdText.Contains(secondTrainNumber))
                {
                    //先尝试找一个车次
                    int intIsYesterday = 0;
                    if (isYesterday)
                    {
                        intIsYesterday = 1;
                    }
                    else
                    {
                        intIsYesterday = 0;
                    }
                    int result = searchAndHightlightUnresolvedTrains(firstTrainNumber, 1, intIsYesterday, secondTrainNumber);
                    if (result == -1 || result == 2)
                    {//再找第二个车次
                        int secondResult = searchAndHightlightUnresolvedTrains(secondTrainNumber, 1, intIsYesterday, firstTrainNumber);
                        if (secondResult == -1 || secondResult == 2)
                        {//加入未识别车次豪华套餐
                            return " " + rawTrainNumber;
                        }
                    }
                }
            }
            return "";
        }


        //车次一拆为二
        private List<string> splitTrainNumber(string trainNumber)
        {
            if(!trainNumber.Contains("/"))
            {
                return null;
            }
            string[] trainWithDoubleNumber = trainNumber.Split('/');
            bool _hasGotIt = false;
            string firstTrainWord = trainNumber.Split('/')[0];
            string secondTrainWord = "";
            for (int q = 0; q < firstTrainWord.Length; q++)
            {
                if (q < firstTrainWord.Length - trainWithDoubleNumber[1].Length)
                {
                    secondTrainWord = secondTrainWord + firstTrainWord[q];
                }
                else
                {
                    if (_hasGotIt != true)
                    {
                        secondTrainWord = secondTrainWord + trainWithDoubleNumber[1];
                        _hasGotIt = true;
                    }
                }
                if (_hasGotIt)
                {
                    break;
                }
            }
            List<string> _values = new List<string>();
            _values.Add(firstTrainWord);
            _values.Add(secondTrainWord);
            return _values;
        }


        private void contextMenuForTextBox_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                粘贴ToolStripMenuItem.Enabled = true;
            }
            else
                粘贴ToolStripMenuItem.Enabled = false;

            ((RichTextBox)contextMenuStrip1.SourceControl).Paste();
            //command_rTb.Paste(); //粘贴
        }



        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((RichTextBox)contextMenuStrip1.SourceControl).Clear();
            //command_rTb.Clear(); //清空
        }

        private void 复制toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string selectText = ((RichTextBox)contextMenuStrip1.SourceControl).SelectedText;
            if (selectText != "")
            {
                Clipboard.SetText(selectText);
            }
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            //右方显示框内容
            String commands = "";
            List<CommandModel> _allModels = new List<CommandModel>();
            string searchText = search_tb.Text.ToString().Trim();
            searchText = searchText.ToUpper();
            if (commandModel == null)
            {
                return;
            }
            if (searchText.Length == 0)
            {
                if (wrongTrain != null)
                {
                    if (wrongTrain.Length != 0)
                    {
                        searchResult_tb.Text = "识别错误车辆：" + "\r\n" + wrongTrain;
                        return;
                    }
                }
            }
            for (int i = 0; i < commandModel.Count; i++)
            {
                CommandModel model = commandModel[i];
                if (model.trainNumber.Contains(searchText) ||
                    model.secondTrainNumber.Contains(searchText))
                {
                    String streamStatus = "";
                    String trainType = "";
                    if (model.streamStatus != 0)
                    {
                        streamStatus = "√开";
                    }
                    else
                    {
                        streamStatus = "×停";
                    }
                    switch (model.trainType)
                    {
                        case 0:
                            trainType = "";
                            break;
                        case 1:
                            trainType = "-高峰";
                            break;
                        case 2:
                            trainType = "-临客";
                            break;
                        case 3:
                            trainType = "-周末";
                            break;
                    }
                    if (model.secondTrainNumber.Equals("null"))
                    {
                        commands = commands + "第" + model.trainIndex + "条-" + model.trainNumber + "-"+model.trainModel+"-"+model.trainId+"-" + streamStatus +  trainType + "\r\n";
                    }
                    else
                    {
                        commands = commands + "第" + model.trainIndex + "条-" + model.trainNumber + "-" + model.secondTrainNumber + "-" + model.trainModel + "-" + model.trainId + "-" + streamStatus +  trainType + "\r\n";
                    }
                    _allModels.Add(model);
                }
            }
            searchResult_tb.Text = "共" + _allModels.Count.ToString() + "趟" + "\r\n" + commands;
        }

        private void FontSize_tb_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FontSize_tb_TextChanged(object sender, EventArgs e)
        {
            int _fontSize = 0;
            int.TryParse(FontSize_tb.Text, out _fontSize);
            if (_fontSize != 0)
            {
                fontSize = _fontSize;
            }
        }

        private void compare_btn_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void importCommand_btn_Click(object sender, EventArgs e)
        {
            SelectPath(true);
            getCommand();
        }

        private void trainProjectBtnCheck()
        {//判断是否启用调车作业辅助(测试版)

        }

    }
}
