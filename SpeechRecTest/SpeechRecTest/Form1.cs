using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SpeechRecTest
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
      
        public static string ServerMessage="";
        bool first_time = true;
        private void ListenConnect()
        {
            while (true)
            {
                if (first_time)
                {
                    //SpeechChineseOrder();
                    BuildRecEngine();
                    first_time = false;
                }
                SpeechChineseOrder();

            }
        }
        //建立中文語音辨識器
        SpeechRecognitionEngine RecEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("zh-TW"));
        string[] original_choices = new string[] {   "暫停", "夾取", "鬆開","下降","移動至材料點","移動至目的點",
                                            "確認","取消","開始操作","結束操作" };
        List<string> choice_string = new List<string>();
        #region 語音辨識功能     
        private void BuildRecEngine()
        {         
            //設定接收來自預設音訊裝置的輸入
            RecEngine.SetInputToDefaultAudioDevice();

            //設定所有欲辨識指令
            Choices speechList = new Choices();
            speechList.Add(original_choices);
            
            //建立自訂語彙庫
            Grammar customGrammer = new Grammar(new GrammarBuilder(speechList));
            RecEngine.RequestRecognizerUpdate();//要求辨識器暫停以更新其狀態

            //卸載語音辨識器中預設Grammar
            RecEngine.UnloadAllGrammars();

            //載入自訂 Grammar 物件
            RecEngine.LoadGrammar(customGrammer);

            RecEngine.SpeechRecognized += ChineseSpeechRecognized;
            //SpeechRecognized事件:在 SpeechRecognitionEngine 收到的輸入符合任何其已載入且已啟用 Grammar 物件時引發

            RecEngine.SetInputToDefaultAudioDevice();//設定SpeechRecognitionEngine物件，以接收來自預設音訊裝置的輸入。
        }
        public void SpeechChineseOrder()
        {
            RecEngine.Recognize();//執行同步語音辨識作業。
        }
        bool start_send;
        private void btn_start_Click(object sender, EventArgs e)
        {
            //用於後續sent message的bool
            start_send = true;
            //對所設定的IP建立server
            SocketServer.BindAddress();
            ListenConnect();
            
        }

        public void ChineseSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech_rec_result = e.Result.Text;

            switch (speech_rec_result)
            {              
                default:
                    Console.WriteLine("辨識結果：{0}", speech_rec_result);
                    break;
            }
            ServerMessage = speech_rec_result;
            if (start_send == true)
            {
                SocketServer.SendResults();
            }
            
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ended");
            Form change_form = new TextChangeForm(original_choices,ref choice_string);
            change_form.ShowDialog(this);
            if (change_form.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                string[] new_choice = new string[choice_string.Count];
                int i = 0;
                foreach (string s in choice_string)
                {
                    new_choice[i] = s;
                    Console.WriteLine(s);
                    i++;
                }
                original_choices = new_choice;
                Choices speechList = new Choices();
                speechList.Add(original_choices);
                Grammar customGrammer = new Grammar(new GrammarBuilder(speechList));
                RecEngine.RequestRecognizerUpdate();
                RecEngine.UnloadAllGrammars();
                RecEngine.LoadGrammar(customGrammer);
                RecEngine.SpeechRecognized += ChineseSpeechRecognized;
                RecEngine.SetInputToDefaultAudioDevice();
            }
            
            
        }
    }
}
