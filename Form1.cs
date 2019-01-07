using Cocaro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANCUOIKI
{
    public partial class Form1 : Form
    {
        #region properties
        clsBanCo ChessBoard;
        SocketManager socket;
        #endregion
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new clsBanCo(pnlBanCo,tbName,picConCo);
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;
            ChessBoard.EndCRGame += ChessBoard_EndedGame1;
            proTime.Step = coso.step_time;
            proTime.Maximum = coso.end_time;
            proTime.Value = 0;
            timer1.Interval = coso.tang_time;
            socket = new SocketManager();
            NewGameCR();
        }
        #region Methods
        void EndGame()
        {
            timer1.Stop();
            undoToolStripMenuItem.Enabled = false;
            pnlBanCo.Enabled = false;
            //MessageBox.Show("Kết thúc");
        }
        void NewGameCR()
        {
            proTime.Value = 0;
            timer1.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.VeBanCo();
        }
        void UnDoCR()
        {
            ChessBoard.Undo();
            proTime.Value = 0;

        }
        void Exit()
        {
            
            Application.Exit();
        }


        private void ChessBoard_PlayerMarked(object sender, ButtonlickEvent e)
        {
            timer1.Start();
            pnlBanCo.Enabled = false;
            proTime.Value = 0;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.Clickpoint));
            Listen();
            undoToolStripMenuItem.Enabled = false;
        }

        private void ChessBoard_EndedGame1(object sender, EventArgs e)
        {

            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            proTime.PerformStep();
            if (proTime.Value >= proTime.Maximum)
            {
                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
            }
        }
        private void newgameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewGameCR();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            pnlBanCo.Enabled = true;
        }
        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
            UnDoCR();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch {  };
            }
        }
        private void btLAN_Click(object sender, EventArgs e)
        {
            socket.IP = tbIP.Text;

            if (!socket.ConnectServer())
            {
                socket.Isserver = true;
                pnlBanCo.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.Isserver = false;
                pnlBanCo.Enabled = false;
                Listen();
        
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    processData(data);
                }
                catch{ }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void  processData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGameCR();
                        pnlBanCo.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        proTime.Value = 0;
                        pnlBanCo.Enabled = true;
                        timer1.Start();
                        ChessBoard.OtherplayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    UnDoCR();
                    proTime.Value = 0;
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Đã 5 con trên 1 hàng");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Hết giờ");
                    break;
                case (int)SocketCommand.QUIT:
                    timer1.Stop();
                    MessageBox.Show("Người chơi đã thoát");
                    break;
                default:
                    break;
            }

            Listen();
        }
        #endregion
    }
}
