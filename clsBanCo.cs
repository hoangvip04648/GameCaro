using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cocaro
{
    public class clsBanCo
    {
        #region Properties
        private Panel chessBoard;
        public Panel ChesBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<Player> nguoichoi;
        public List<Player> Nguoichoi
        {
            get { return nguoichoi; }
            set { nguoichoi = value; }
        }
        private int currentPlayer;
        public int CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
            }
        }
        private TextBox playerName;
        public TextBox PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }
        private PictureBox playerMark;
        public PictureBox PlayerMark
        {
            get
            {
                return playerMark;
            }

            set
            {
               playerMark = value;
            }
        }
        private Stack<Play> toadodanh;
        internal Stack<Play> Toadodanh
        {
            get
            {
                return toadodanh;
            }

            set
            {
                toadodanh = value;
            }
        }
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler<ButtonlickEvent> playerMarked;
        public event EventHandler<ButtonlickEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }
        private event EventHandler endCRGame;
        public event EventHandler EndCRGame
        {
            add
            {
                endCRGame += value;
            }
            remove
            {
                endCRGame -= value;
            }
        }
       
        #endregion
        #region Initialize
        public clsBanCo(Panel chessBoard,TextBox playerName,PictureBox mark)
        {
            this.ChesBoard = chessBoard;
            this.PlayerName= playerName;
            this.PlayerMark = mark;
            this.Nguoichoi= new List<Player>()
            {
                new Player("Player 1",Image.FromFile(Application.StartupPath +"\\Resources\\2.png")),
                new Player("Player 2",Image.FromFile(Application.StartupPath +"\\Resources\\3.png"))
            };
  
        }

        #endregion
        #region Methods
        public void VeBanCo()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
            Toadodanh = new Stack<Play>();
            CurrentPlayer = 0;
            ChangePlayer();
           Matrix = new List<List<Button>>();
            Button btflag = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < coso.doc; i++)
            {
                for (int j = 0; j < coso.ngang; j++)
                {
                    matrix.Add(new List<Button>());
                    Button bt = new Button()
                    {
                        Width = coso.dai,
                        Height = coso.rong,
                        Location = new Point(btflag.Location.X + btflag.Width, btflag.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()

                    };

                    bt.Click += Bt_Click;
                    chessBoard.Controls.Add(bt);
                    matrix[i].Add(bt);
                    btflag = bt;
                }
                btflag.Location = new Point(0, btflag.Location.Y + coso.rong);
                btflag.Width = 0;
                btflag.Height = 0;
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt.BackgroundImage != null) return;

            Mark(bt);
           Toadodanh.Push(new Play(GetConCo(bt),CurrentPlayer));
           CurrentPlayer =CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();
            if (playerMarked != null)
                playerMarked(this, new ButtonlickEvent(GetConCo(bt)));

            if (IsEndgame(bt))
            {
                EndGame();
            }
        }
        public void OtherplayerMark(Point point)
        {
           
            Button bt = Matrix[point.Y][point.X];
            if (bt.BackgroundImage != null) return;
            
            Mark(bt);
            Toadodanh.Push(new Play(GetConCo(bt), CurrentPlayer));
            currentPlayer = currentPlayer == 1 ? 0 : 1;
            ChangePlayer();
            

            if (IsEndgame(bt))
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            if (endCRGame!= null)
               endCRGame(this, new EventArgs());
        }
        public bool Undo()
        {
            if (Toadodanh.Count <= 0)
                return false;

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            Play oldPoint = Toadodanh.Peek();
            CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;
        }
        public bool UndoAStep()
        {
            if (Toadodanh.Count <= 0)
                return false;
            Play oldpoint = Toadodanh.Pop();  
            Button bt = matrix[oldpoint.Point.Y][oldpoint.Point.X];
            bt.BackgroundImage = null;
            if (Toadodanh.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldpoint = Toadodanh.Peek();
                CurrentPlayer = oldpoint.CurrentPlayer == 1 ? 0 : 1;
            }
            ChangePlayer();
            return true;
        }
        private  bool IsEndgame(Button bt)
        {
            return Ngang(bt) ||Doc(bt) ||Chinh(bt) ||Phu(bt);
        }
        private Point GetConCo(Button bt)
        {
            
            int Vertical =Convert.ToInt32( bt.Tag);
            int horizontal = matrix[Vertical].IndexOf(bt);
            Point point = new Point(horizontal,Vertical);
            return point;
        }
        private bool Ngang(Button bt)
        {
            Point point = GetConCo(bt);
            int demtrai = 0;
            for(int i=point.X; i >=0  ; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == bt.BackgroundImage)
                    demtrai++;
                else
                    break;
            }
            int demphai = 0;
            for (int i = point.X+1; i < coso.ngang; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == bt.BackgroundImage)
                    demphai++;
                else
                    break;
            }
            return demphai+demtrai==5;
        }
        private bool Doc(Button bt)
        {
            Point point = GetConCo(bt);
            int demtren = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[i][point.X].BackgroundImage == bt.BackgroundImage)
                    demtren++;
                else
                    break;
            }
            int demduoi = 0;

            for (int i = point.Y + 1; i < coso.doc; i++)
            {
                if (matrix[i][point.X].BackgroundImage == bt.BackgroundImage)
                    demduoi++;
                else
                    break;
            }
            return demtren + demduoi == 5;
        }
        private bool Chinh(Button bt)
        {
            Point point = GetConCo(bt);
            
            int demtren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y -i< 0) break;
                if (matrix[point.Y - i][point.X - i].BackgroundImage == bt.BackgroundImage)
                    demtren++;
                else
                    break;
            }
            int demduoi = 0;

            for (int i =1; i <= coso.ngang-point.X; i++)
            {
                if (point.X + i >= coso.ngang || point.Y + i >= coso.doc) break;
                if (matrix[point.Y + i][point.X + i].BackgroundImage == bt.BackgroundImage)
                    demduoi++;
                else
                    break;
            }
            return demtren + demduoi == 5;
        }
        private bool Phu(Button bt)
        {
            Point point = GetConCo(bt);

            int demtren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= coso.ngang|| point.Y - i < 0) break;
                if (matrix[point.Y - i][point.X + i].BackgroundImage == bt.BackgroundImage)
                    demtren++;
                else
                    break;
            }
            int demduoi = 0;

            for (int i = 1; i <= coso.ngang - point.X; i++)
            {
                if (point.Y + i >= coso.doc || point.X -i <0 )break;
                if (matrix[point.Y + i][point.X - i].BackgroundImage == bt.BackgroundImage)
                    demduoi++;
                else
                    break;
            }
            return demtren + demduoi == 5;
        }
        private void Mark(Button bt)
        {
            bt.BackgroundImage = Nguoichoi[currentPlayer].Mark;
            
        }
        private void ChangePlayer()
        {
            PlayerName.Text = Nguoichoi[currentPlayer].Name;
            PlayerMark.Image = Nguoichoi[currentPlayer].Mark;
        }
        #endregion

    }
    public class ButtonlickEvent : EventArgs
    {
        private Point clickpoint;

        public Point Clickpoint
        {
            get
            {
                return clickpoint;
            }

            set
            {
                clickpoint = value;
            }
        }
        public ButtonlickEvent(Point point)
        {
            this.clickpoint = point;
        }
    }

}
