using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        private Label mFirstClicked;
        private Label mSecondClicked;
        private uint mClearTime;
        private SoundPlayer mCorrectSound = new SoundPlayer(@"..\Sound\correct.wav");
        private SoundPlayer mWrongSound = new SoundPlayer(@"..\Sound\wrong.wav");
        private SoundPlayer mBellSound = new SoundPlayer(@"..\Sound\bell.wav");
        private Random mRandom = new Random();
        private readonly List<string> ICONS = new List<string>()
        {
            "!", "&&", "q", "~", "%", ",", "e", "Y", "L", "b", "o", "v", "d", "w", "z",
            "!", "&&", "q", "~", "%", ",", "e", "Y", "L", "b", "o", "v", "d", "w", "z"
        };
        public Form1()
        {
            InitializeComponent();
            assignIconsToSquares();
        }
        /// <summary>
        /// 리스트에 저장된 아이콘을 임의의 사각형에 할당한다.
        /// </summary>
        private void assignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = mRandom.Next(ICONS.Count);
                    iconLabel.Text = ICONS[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    ICONS.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// 모든 아이콘의 클릭 이벤트를 처리한다.
        /// </summary>
        /// <param name="sender">클릭된 라벨</param>
        /// <param name="e"></param>
        private void icon_Click(object sender, EventArgs e)
        {
            if (clearTimer.Enabled == false)
            {
                clearTimer.Start();
            }

            if (timer1.Enabled)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
            {
                return;
            }

            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }

            if (mFirstClicked == null)
            {
                mFirstClicked = clickedLabel;
                mFirstClicked.ForeColor = Color.Lavender;
                intervalTimer.Start();

                return;
            }

            mSecondClicked = clickedLabel;
            mSecondClicked.ForeColor = Color.Lavender;

            intervalTimer.Stop();

            checkForWinner();

            if (mFirstClicked.Text == mSecondClicked.Text)
            {
                mCorrectSound.Play();
                mFirstClicked.ForeColor = Color.Black;
                mSecondClicked.ForeColor = Color.Black;

                mFirstClicked = null;
                mSecondClicked = null;

                return;
            }

            mWrongSound.Play();
            timer1.Start();
        }

        /// <summary>
        /// 플레이어가 클릭한 두 아이콘이 다를 때 켜지는 타이머.
        /// 0.75초 후에 두 아이콘을 숨기고 꺼진다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            mBellSound.Play();

            mFirstClicked.ForeColor = mFirstClicked.BackColor;
            mSecondClicked.ForeColor = mSecondClicked.BackColor;

            mFirstClicked = null;
            mSecondClicked = null;
        }

        /// <summary>
        /// 플레이어의 승리 여부 검사. 모든 아이콘이 앞면이면 플레이어 승리.
        /// </summary>
        private void checkForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel == null)
                {
                    continue;
                }

                if (iconLabel.ForeColor == iconLabel.BackColor)
                {
                    return;
                }
            }

            mCorrectSound.Play();
            clearTimer.Stop();
            MessageBox.Show("모두 맞췄습니다!", "축하합니다");
            Close();
        }

        /// <summary>
        /// 게임 시작(첫 아이콘 클릭)부터 매초 호출되어,
        /// 플레이어가 모든 아이콘 맞출 때 몇 초 걸리는지 헤아린다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTimer_Tick(object sender, EventArgs e)
        {
            clearTimeLabel.Text = $"Time: {++mClearTime,4} sec";

            if (mClearTime == 9999)
            {
                //time up
            }
        }

        /// <summary>
        /// 매 차례 첫 번째 선택 후 두 번째 선택까지 interval을 초과할 수 없도록 감시하는 타이머.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTimer_Tick(object sender, EventArgs e)
        {
            intervalTimer.Stop();

            mBellSound.Play();

            mFirstClicked.ForeColor = mFirstClicked.BackColor;
            mFirstClicked = null;

            if (mSecondClicked != null)
            {
                mSecondClicked.ForeColor = mSecondClicked.BackColor;
                mSecondClicked = null;
            }
        }
    }
}
