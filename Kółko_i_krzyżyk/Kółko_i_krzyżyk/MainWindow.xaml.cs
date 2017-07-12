using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kółko_i_krzyżyk
{
    public enum MarkType
    {
        Free,
        Nought,
        Cross
    }

    public partial class MainWindow : Window
    {
        private MarkType[] mResults;
        private bool mPlayer1Turn;
        private bool mWinner;

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(f =>
            {
                f.Content = string.Empty;
                f.Background = Brushes.White; 
                f.Foreground = Brushes.Yellow;
            }
            );

            mWinner = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mWinner)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);
            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "☆" : "★";

            if (!mPlayer1Turn)
                button.Foreground = Brushes.OrangeRed;


            mPlayer1Turn ^= true;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mWinner = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.DodgerBlue;
            }
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mWinner = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.DodgerBlue;
            }
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mWinner = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.DodgerBlue;
            }

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mWinner = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.DodgerBlue;
            }
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mWinner = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.DodgerBlue;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mWinner = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.DodgerBlue;
            }

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mWinner = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.DodgerBlue;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mWinner = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.DodgerBlue;
            }






            if (!mResults.Any(f => f == MarkType.Free))
            {
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
                {
                    mWinner = true;
                    Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.DodgerBlue;
                }
                else
                {
                    if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
                    {
                        mWinner = true;
                        Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.DodgerBlue;
                    }
                    else
                    {
                        if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
                        {
                            mWinner = true;
                            Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.DodgerBlue;
                        }
                        else
                        {
                            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
                            {
                                mWinner = true;
                                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.DodgerBlue;
                            }
                            else
                            {
                                if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
                                {
                                    mWinner = true;
                                    Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.DodgerBlue;
                                }
                                else
                                {
                                    if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
                                    {
                                        mWinner = true;
                                        Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.DodgerBlue;
                                    }
                                    else
                                    {
                                        if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
                                        {
                                            mWinner = true;
                                            Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.DodgerBlue;
                                        }
                                        else
                                        {
                                            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
                                            {
                                                mWinner = true;
                                                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.DodgerBlue;
                                            }
                                            else
                                            {
                                                Container.Children.Cast<Button>().ToList().ForEach(f => f.Background = Brushes.MidnightBlue);
                                                mWinner = true;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
