using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWP_project
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();



            Random dmg = new Random();

            surrent_mana = max_mana;
            ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

            
            PlayerPB.Maximum = 500;
            PlayerPB.Value = PlayerPB.Maximum;
            PlayerTB.Text = "REVENGE - HP: " + PlayerPB.Value + "/" + PlayerPB.Maximum;
          

            EnemyPB1.Maximum = 100;
            EnemyPB1.Value = EnemyPB1.Maximum;
            EnemyTB1.Text = "Enemy1 - HP: " + EnemyPB1.Value + "/" + EnemyPB1.Maximum;
            EnemyStatusTB1.Text = dmg.Next(0,50)+ " Damage";

            EnemyPB2.Maximum = 100;
            EnemyPB2.Value = EnemyPB2.Maximum;
            EnemyTB2.Text = "Enemy2 - HP: " + EnemyPB2.Value + "/" + EnemyPB2.Maximum;
            EnemyStatusTB2.Text = dmg.Next(0, 50) + " Damage";

            EnemyPB3.Maximum = 100;
            EnemyPB3.Value = EnemyPB3.Maximum;
            EnemyTB3.Text = "Enemy3 - HP: " + EnemyPB3.Value + "/" + EnemyPB3.Maximum;
            EnemyStatusTB3.Text = dmg.Next(0, 50) + " Damage";

            GamePrepare(); //Функция присваивания источников картинок для карт и противников

            GameStart(); //Функция начала игры
        }

        int max_mana = 5;
        int surrent_mana = 0;
        int player_dmg = 0;
        int enemy_dmg = 0;

        string[] cards_name = new string[12];
        string[] cards = new string[34];
        string[] enemy = new string[14];

        void enemy_turn()
        {
            enemy_dmg = Convert.ToInt32(EnemyStatusTB1.Text.Replace(" Damage", ""))
                + Convert.ToInt32(EnemyStatusTB2.Text.Replace(" Damage", "")) 
                +  Convert.ToInt32(EnemyStatusTB3.Text.Replace(" Damage", ""));


            if (PlayerPB.Value - enemy_dmg <= 0)
            {
                GameField.Opacity = 0;
                GameField.Width = 1;
                GameField.Height = 1;
            }
            else
            {
                PlayerPB.Value -= enemy_dmg;
                PlayerTB.Text = "REVENGE - HP: " + PlayerPB.Value + "/" + PlayerPB.Maximum;
            }
            
        }

        void next_cards()
        {
            Random ran = new Random();
            CardImg1.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg2.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg3.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg4.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg5.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));

            Random ran2 = new Random();
            CardTB1.Text = cards_name[ran2.Next(0, 11)];
            CardTB2.Text = cards_name[ran2.Next(0, 11)];
            CardTB3.Text = cards_name[ran2.Next(0, 11)];
            CardTB4.Text = cards_name[ran2.Next(0, 11)];
            CardTB5.Text = cards_name[ran2.Next(0, 11)];

            CardTB1.Text += " | " + Convert.ToInt32(Convert.ToInt32(CardTB1.Text.Replace(" Damage", "")) * Convert.ToDouble("0," + CardTB1.Text.Replace(" Damage", ""))) + " Mana";
            CardTB2.Text += " | " + Convert.ToInt32(Convert.ToInt32(CardTB2.Text.Replace(" Damage", "")) * Convert.ToDouble("0," + CardTB2.Text.Replace(" Damage", ""))) + " Mana";
            CardTB3.Text += " | " + Convert.ToInt32(Convert.ToInt32(CardTB3.Text.Replace(" Damage", "")) * Convert.ToDouble("0," + CardTB3.Text.Replace(" Damage", ""))) + " Mana";
            CardTB4.Text += " | " + Convert.ToInt32(Convert.ToInt32(CardTB4.Text.Replace(" Damage", "")) * Convert.ToDouble("0," + CardTB4.Text.Replace(" Damage", ""))) + " Mana";
            CardTB5.Text += " | " + Convert.ToInt32(Convert.ToInt32(CardTB5.Text.Replace(" Damage", "")) * Convert.ToDouble("0," + CardTB5.Text.Replace(" Damage", ""))) + " Mana";
        }

        public void GameStart() //Функция начала игры
        {
            


            //___________________Ранжобные карты______________________________
            Random ran = new Random();
            CardImg1.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg2.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg3.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg4.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));
            CardImg5.Source = new BitmapImage(new Uri("ms-appx:///Assets/C" + ran.Next(1, 34).ToString() + ".png"));

            //__________________Рандомные противники___________________________
            Random ran1 = new Random();
            EnemyImg1.Source = new BitmapImage(new Uri("ms-appx:///Assets/E" + ran1.Next(1, 15).ToString() + ".png"));
            EnemyImg2.Source = new BitmapImage(new Uri("ms-appx:///Assets/E" + ran1.Next(1, 15).ToString() + ".png"));
            EnemyImg3.Source = new BitmapImage(new Uri("ms-appx:///Assets/E" + ran1.Next(1, 15).ToString() + ".png"));


            //_________________Рандомный урон + мана___________________________
            Random ran2 = new Random();
            CardTB1.Text = cards_name[ran2.Next(0, 11)];
            CardTB2.Text = cards_name[ran2.Next(0, 11)];
            CardTB3.Text = cards_name[ran2.Next(0, 11)];
            CardTB4.Text = cards_name[ran2.Next(0, 11)];
            CardTB5.Text = cards_name[ran2.Next(0, 11)];

            CardTB1.Text += " | " + Convert.ToInt32( Convert.ToInt32( CardTB1.Text.Replace(" Damage", "")) * Convert.ToDouble( "0," + CardTB1.Text.Replace(" Damage", "") )) + " Mana"; 
            CardTB2.Text += " | " + Convert.ToInt32( Convert.ToInt32( CardTB2.Text.Replace(" Damage", "")) * Convert.ToDouble( "0," + CardTB2.Text.Replace(" Damage", "") )) + " Mana";
            CardTB3.Text += " | " + Convert.ToInt32( Convert.ToInt32( CardTB3.Text.Replace(" Damage", "")) * Convert.ToDouble( "0," + CardTB3.Text.Replace(" Damage", "") )) + " Mana";
            CardTB4.Text += " | " + Convert.ToInt32( Convert.ToInt32( CardTB4.Text.Replace(" Damage", "")) * Convert.ToDouble( "0," + CardTB4.Text.Replace(" Damage", "") )) + " Mana";
            CardTB5.Text += " | " + Convert.ToInt32( Convert.ToInt32( CardTB5.Text.Replace(" Damage", "")) * Convert.ToDouble( "0," + CardTB5.Text.Replace(" Damage", "") )) + " Mana";
        }


       

        void GamePrepare() //Функция присваивания источников картинок для карт и противников
        {
            for (int i = 0; i <= 33; i++)
            {
                cards[i] = "C" + i + 1 + ".png";
            }

            for (int i = 0; i <= 13 ; i++)
            {
                enemy[i] = "E" + i + 1 + ".png";
            }

            for (int i = 0; i <= 11; i++)
            {
                cards_name[i] = i + 10 + " Damage";
            }
        }

        void card_click(object sender, RoutedEventArgs e)
        {
            Image I = sender as Image;
            int card_manacost=0;

            if ( I.Name.Replace("CardImg", "") == CardTB1.Name.Replace("CardTB", "") )
            {
                card_manacost = Convert.ToInt32(CardTB1.Text.Substring(11, 2));
             
                if (surrent_mana - card_manacost >= 0)
                {
                    surrent_mana -= card_manacost;
                    ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

                    player_dmg += Convert.ToInt32(CardTB1.Text.Substring(0, 2));
                    I.Opacity = 0;
                    CardTB1.Opacity = 0;
                }
            }

            if ( I.Name.Replace("CardImg", "") == CardTB2.Name.Replace("CardTB", "") ) 
            {
                card_manacost = Convert.ToInt32(CardTB2.Text.Substring(11, 2));

                if (surrent_mana - card_manacost >= 0)
                {
                    surrent_mana -= card_manacost;
                    ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

                    player_dmg += Convert.ToInt32(CardTB2.Text.Substring(0, 2));
                    I.Opacity = 0;
                    CardTB2.Opacity = 0;
                }
            }

            if ( I.Name.Replace("CardImg", "") == CardTB3.Name.Replace("CardTB", "") ) 
            {
                card_manacost = Convert.ToInt32(CardTB3.Text.Substring(11, 2));

                if (surrent_mana - card_manacost >= 0)
                {
                    surrent_mana -= card_manacost;
                    ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

                    player_dmg += Convert.ToInt32(CardTB3.Text.Substring(0, 2));
                    I.Opacity = 0;
                    CardTB3.Opacity = 0;
                }
            }

            if ( I.Name.Replace("CardImg", "") == CardTB4.Name.Replace("CardTB", "") )
            {
                card_manacost = Convert.ToInt32(CardTB4.Text.Substring(11, 2));

                if (surrent_mana - card_manacost >= 0)
                {
                    
                    surrent_mana -= card_manacost;
                    ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

                    player_dmg += Convert.ToInt32(CardTB4.Text.Substring(0, 2));
                    I.Opacity = 0;
                    CardTB4.Opacity = 0;
                }
            }

            if ( I.Name.Replace("CardImg", "") == CardTB5.Name.Replace("CardTB", "") )
            {
                card_manacost = Convert.ToInt32(CardTB5.Text.Substring(11, 2));

                if (surrent_mana - card_manacost >= 0)
                {
                    surrent_mana -= card_manacost;
                    ManaIndText.Text = "MANA: " + surrent_mana + "/" + max_mana;

                    player_dmg += Convert.ToInt32(CardTB5.Text.Substring(0, 2));
                    I.Opacity = 0;
                    CardTB5.Opacity = 0;
                }
            }

        }


        void player_turn(object sender, RoutedEventArgs e)
        {
            Image I = sender as Image;
            if (I.Name.Replace("EnemyImg", "") == EnemyTB1.Name.Replace("EnemyTB", "")) 
            {
                if (EnemyPB1.Value - player_dmg <= 0)
                {
                    EnemyStatusTB1.Text = 0 + " Damage";
                    EnemyImg1.Opacity = 0;
                    EnemyImg1.Width = 0;
                    EnemyImg1.Height = 0;
                }
                else
                {
                    EnemyPB1.Value -= player_dmg;
                    EnemyTB1.Text = "Enemy3 - HP: " + EnemyPB1.Value + "/" + EnemyPB1.Maximum;
                }
                player_dmg = 0;
            }

            if (I.Name.Replace("EnemyImg", "") == EnemyTB2.Name.Replace("EnemyTB", "")) 
            {
                if (EnemyPB2.Value - player_dmg <= 0)
                {
                    EnemyStatusTB2.Text = 0 + " Damage";
                    EnemyImg2.Opacity = 0;
                    EnemyImg2.Width = 0;
                    EnemyImg2.Height = 0;
                }
                else
                {
                    EnemyPB2.Value -= player_dmg;
                    EnemyTB2.Text = "Enemy3 - HP: " + EnemyPB2.Value + "/" + EnemyPB2.Maximum;
                }
                player_dmg = 0;
            }

            if (I.Name.Replace("EnemyImg", "") == EnemyTB3.Name.Replace("EnemyTB", "")) 
            {
                if (EnemyPB3.Value - player_dmg <= 0)
                {
                    EnemyStatusTB3.Text = 0 + " Damage";
                    EnemyImg3.Opacity = 0;
                    EnemyImg3.Width = 0;
                    EnemyImg3.Height = 0;

                }
                else
                {
                    EnemyPB3.Value -= player_dmg;
                    EnemyTB3.Text = "Enemy3 - HP: " + EnemyPB3.Value + "/" + EnemyPB3.Maximum;
                }
                player_dmg = 0;
            }
        }

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
            player_dmg = 0;
            surrent_mana = max_mana;
            ManaIndText.Text = "MANA: " + surrent_mana + "/"+ max_mana;
            next_cards();

            enemy_turn();

            CardImg1.Opacity = 100;
            CardImg2.Opacity = 100;
            CardImg3.Opacity = 100;
            CardImg4.Opacity = 100;
            CardImg5.Opacity = 100;

            CardTB1.Opacity = 100;
            CardTB2.Opacity = 100;
            CardTB3.Opacity = 100;
            CardTB4.Opacity = 100;
            CardTB5.Opacity = 100;
        }

	}
}
