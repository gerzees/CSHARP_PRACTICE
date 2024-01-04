using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private Random randomizer = new Random();
        private int addend1;
        private int addend2;
        private int minuend;
        private int subtrahend;
        private int multiplicand;
        private int multiplier;
        private int dividend;
        private int divisor;
        private int timeLeft;
        private SoundPlayer correctAnswerRing = new SoundPlayer(@"correctAnswerRing.wav");

        /// <summary>
        /// 모든 문제를 만들고
        /// 타이머를 켠다.
        /// </summary>
        public void StartTheQuiz()
        {
            // 덧셈
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // 뺄셈
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // 곱셈
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // 나눗셈
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // 타이머 켜기
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        /// <summary>
        /// 사용자가 모든 문제의 정답을 맞췄는지 검사한다.
        /// </summary>
        /// <returns> 정답을 맞추면 true, 아니면 false를 반환한다.</returns>
        private bool checkTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                return true;
            }

            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("모든 문제의 정답을 맞췄습니다!", "축하합니다!");
                startButton.Enabled = true;
                timeLeft = 0;
            }
            else if (timeLeft > 0)
            {
                --timeLeft;
                timeLabel.Text = $"{timeLeft} seconds";

                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("시간 안에 못 풀었습니다.", "아쉽습니다!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnser = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnser);
            }
        }

        private void startButton_EnabledChanged(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Enabled == true)
            {
                timeLabel.BackColor = Control.DefaultBackColor;
            }
        }

        private void eachAnswerCheck(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox == null || timeLeft == 0)
            {
                return;
            }

            bool bCorrect = false;
            switch (answerBox.Name)
            {
                case "sum":
                    bCorrect = answerBox.Value == addend1 + addend2;
                    break;
                case "difference":
                    bCorrect = answerBox.Value == minuend - subtrahend;
                    break;
                case "product":
                    bCorrect = answerBox.Value == multiplicand * multiplier;
                    break;
                case "quotient":
                    bCorrect = answerBox.Value == dividend / divisor;
                    break;
                default:
                    Debug.Assert(false, "Unknown answer box(NumericUpDown)");
                    break;
            }

            if(bCorrect)
            {
                correctAnswerRing.Play();
            }
        }
    }
}
