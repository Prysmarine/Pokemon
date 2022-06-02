/*
    Pokemon "Pokedex" 
    By Prysmatic Productions
        Prysmarine
    Last Updated May 26, 2022
*/ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Pokemon : Form
    {
        private List<Button> _buttonGroup1 = new List<Button>();
        private List<Button> _buttonGroup2 = new List<Button>();
        private Button button1;
        private Button button2;
        public Pokemon()
        {
            InitializeComponent();
            _buttonGroup1.Add(btnBug1);
            _buttonGroup1.Add(btnDark1);
            _buttonGroup1.Add(btnDragon1);
            _buttonGroup1.Add(btnElectric1);
            _buttonGroup1.Add(btnFairy1);
            _buttonGroup1.Add(btnFighting1);
            _buttonGroup1.Add(btnFire1);
            _buttonGroup1.Add(btnFlying1);
            _buttonGroup1.Add(btnGhost1);
            _buttonGroup1.Add(btnGrass1);
            _buttonGroup1.Add(btnGround1);
            _buttonGroup1.Add(btnIce1);
            _buttonGroup1.Add(btnNormal1);
            _buttonGroup1.Add(btnPoison1);
            _buttonGroup1.Add(btnPsychic1);
            _buttonGroup1.Add(btnRock1);
            _buttonGroup1.Add(btnSteel1);
            _buttonGroup1.Add(btnWater1);

            _buttonGroup2.Add(btnBug2);
            _buttonGroup2.Add(btnDark2);
            _buttonGroup2.Add(btnDragon2);
            _buttonGroup2.Add(btnElectric2);
            _buttonGroup2.Add(btnFairy2);
            _buttonGroup2.Add(btnFighting2);
            _buttonGroup2.Add(btnFire2);
            _buttonGroup2.Add(btnFlying2);
            _buttonGroup2.Add(btnGhost2);
            _buttonGroup2.Add(btnGrass2);
            _buttonGroup2.Add(btnGround2);
            _buttonGroup2.Add(btnIce2);
            _buttonGroup2.Add(btnNormal2);
            _buttonGroup2.Add(btnPoison2);
            _buttonGroup2.Add(btnPsychic2);
            _buttonGroup2.Add(btnRock2);
            _buttonGroup2.Add(btnSteel2);
            _buttonGroup2.Add(btnWater2);
        }

        //When The First Type Is Selected
        private void CheckSelected1(object sender, EventArgs e)
        {
            if (button1 != null)
            {
                button1.Enabled = true;
            }

            Button btn = (Button)sender;


                btn.Enabled = false;
                lblType1.Image = btn.Image;
                lblType1.Tag = btn.Tag;

                foreach (Button x in _buttonGroup2)
                {
                    if (x.Tag == btn.Tag)
                    {
                        x.Enabled = false;
                    }
                    else
                    {
                        x.Enabled = true;
                    }
                }
                RedundancyCheck();

            button1 = btn;

            Output();                    
        }

        //When The Second Type Is Selected
        private void CheckSelected2(object sender, EventArgs e)
        {
            if (button2 != null)
            {
                button2.Enabled = true;
            }

            Button btn = (Button)sender;

                btn.Enabled = false;
                lblType2.Image = btn.Image;
                lblType2.Tag = btn.Tag;
                foreach (Button x in _buttonGroup1)
                {
                    if (x.Tag == btn.Tag)
                    {
                        x.Enabled = false;
                    }
                    else
                        x.Enabled = true;
                }
                RedundancyCheck();

            button2 = btn;

            Output();
        }

        /*
            Makes Sure Buttons are Disabled
            So Can't Double Select Typings
        */

        private void RedundancyCheck()
        {
            foreach (Button z in _buttonGroup1)
            {
                if (z.Tag == lblType1.Tag || z.Tag == lblType2.Tag)
                {
                    z.Enabled = false;
                }
                else
                    z.Enabled = true;
            }

            foreach (Button w in _buttonGroup2)
            {
                if (w.Tag == lblType2.Tag || w.Tag == lblType1.Tag)
                {
                    w.Enabled = false;
                }
                else
                    w.Enabled = true;
            }
        }

        //Sets the Text On The Type Circles
        private void Output()
        {           
            switch (lblType1.Tag)
            {
                case "Bug":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, .5, 2, 2, 1, .5, .5, 1, 1, 1, 1, 2, 1, 1);
                    break;
                case "Dark":
                    Weakness.WeakCalc(2, 1, .5, 1, 2, 2, 1, 1, .5, 1, 1, 1, 1, 1, 0, 1, 1, 1);
                    break;
                case "Dragon":
                    Weakness.WeakCalc(1, 1, 2, .5, 2, 1, .5, 1, 1, .5, 1, 2, 1, 1, 1, 1, 1, .5);
                    break;
                case "Electric":
                    Weakness.WeakCalc(1, 1, 1, .5, 1, 1, 1, .5, 1, 1, 2, 1, 1, 1, 1, 1, .5, 1);
                    break;
                case "Fairy":
                    Weakness.WeakCalc(.5, .5, 0, 1, 1, .5, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1);
                    break;
                case "Fighting":
                    Weakness.WeakCalc(.5, .5, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, .5, 1, 1);
                    break;
                case "Fire":
                    Weakness.WeakCalc(.5, 1, 1, 1, .5, 1, .5, 1, 1, .5, 2, .5, 1, 1, 1, 2, .5, 2);
                    break;
                case "Flying":
                    Weakness.WeakCalc(.5, 1, 1, 2, 1, .5, 1, 1, 1, .5, 0, 2, 1, 1, 1, 2, 1, 1);
                    break;
                case "Ghost":
                    Weakness.WeakCalc(.5, 2, 1, 1, 1, 0, 1, 1, 2, 1, 1, 1, 0, .5, 1, 1, 1, 1);
                    break;
                case "Grass":
                    Weakness.WeakCalc(2, 1, 1, .5, 1, 1, 2, 2, 1, .5, .5, 2, 1, 2, 1, 1, 1, .5);
                    break;
                case "Ground":
                    Weakness.WeakCalc(1, 1, 1, 0, 1, 1, 1, 1, 1, 2, 1, 2, 1, .5, 1, .5, 1, 2);
                    break;
                case "Ice":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, .5, 1, 1, 1, 2, 2, 1);
                    break;
                case "Normal":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case "Poison":
                    Weakness.WeakCalc(.5, 1, 1, 1, .5, .5, 1, 1, 1, .5, 2, 1, 1, .5, 2, 1, 1, 1);
                    break;
                case "Rock":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, .5, .5, 1, 0, 2, 1, .5, 1, .5, 1, 2, 2);
                    break;
                case "Steel":
                    Weakness.WeakCalc(.5, 1, .5, 1, .5, 2, 2, .5, 1, .5, 2, .5, .5, 0, .5, .5, .5, 1);
                    break;
                case "Water":
                    Weakness.WeakCalc(1, 1, 1, 2, 1, 1, .5, 1, 1, 2, 1, .5, 1, 1, 1, 1, .5, .5);
                    break;
                default:
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
            }

            switch (lblType2.Tag)
            {
                case "Bug":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, .5, 2, 2, 1, .5, .5, 1, 1, 1, 1, 2, 1, 1);
                    break;
                case "Dark":
                    Weakness.WeakCalc(2, 1, .5, 1, 2, 2, 1, 1, .5, 1, 1, 1, 1, 1, 0, 1, 1, 1);
                    break;
                case "Dragon":
                    Weakness.WeakCalc(1, 1, 2, .5, 2, 1, .5, 1, 1, .5, 1, 2, 1, 1, 1, 1, 1, .5);
                    break;
                case "Electric":
                    Weakness.WeakCalc(1, 1, 1, .5, 1, 1, 1, .5, 1, 1, 2, 1, 1, 1, 1, 1, .5, 1);
                    break;
                case "Fairy":
                    Weakness.WeakCalc(.5, .5, 0, 1, 1, .5, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1);
                    break;
                case "Fighting":
                    Weakness.WeakCalc(.5, .5, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, .5, 1, 1);
                    break;
                case "Fire":
                    Weakness.WeakCalc(.5, 1, 1, 1, .5, 1, .5, 1, 1, .5, 2, .5, 1, 1, 1, 2, .5, 2);
                    break;
                case "Flying":
                    Weakness.WeakCalc(.5, 1, 1, 2, 1, .5, 1, 1, 1, .5, 0, 2, 1, 1, 1, 2, 1, 1);
                    break;
                case "Ghost":
                    Weakness.WeakCalc(.5, 2, 1, 1, 1, 0, 1, 1, 2, 1, 1, 1, 0, .5, 1, 1, 1, 1);
                    break;
                case "Grass":
                    Weakness.WeakCalc(2, 1, 1, .5, 1, 1, 2, 2, 1, .5, .5, 2, 1, 2, 1, 1, 1, .5);
                    break;
                case "Ground":
                    Weakness.WeakCalc(1, 1, 1, 0, 1, 1, 1, 1, 1, 2, 1, 2, 1, .5, 1, .5, 1, 2);
                    break;
                case "Ice":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, .5, 1, 1, 1, 2, 2, 1);
                    break;
                case "Normal":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
                case "Poison":
                    Weakness.WeakCalc(.5, 1, 1, 1, .5, .5, 1, 1, 1, .5, 2, 1, 1, .5, 2, 1, 1, 1);
                    break;
                case "Rock":
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 2, .5, .5, 1, 0, 2, 1, .5, 1, .5, 1, 2, 2);
                    break;
                case "Steel":
                    Weakness.WeakCalc(.5, 1, .5, 1, .5, 2, 2, .5, 1, .5, 2, .5, .5, 0, .5, .5, .5, 1);
                    break;
                case "Water":
                    Weakness.WeakCalc(1, 1, 1, 2, 1, 1, .5, 1, 1, 2, 1, .5, 1, 1, 1, 1, .5, .5);
                    break;
                default:
                    Weakness.WeakCalc(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                    break;
            }

            
            BugWeak.Text = Weakness.output(0);
            DarkWeak.Text = Weakness.output(1);
            DragonWeak.Text = Weakness.output(2);
            ElectricWeak.Text = Weakness.output(3);
            FairyWeak.Text = Weakness.output(4);
            FightingWeak.Text = Weakness.output(5);
            FireWeak.Text = Weakness.output(6);
            FlyingWeak.Text = Weakness.output(7);
            GhostWeak.Text = Weakness.output(8);
            GrassWeak.Text = Weakness.output(9);
            GroundWeak.Text = Weakness.output(10);
            IceWeak.Text = Weakness.output(11);
            NormalWeak.Text = Weakness.output(12);
            PoisonWeak.Text = Weakness.output(13);
            PsychicWeak.Text = Weakness.output(14);
            RockWeak.Text = Weakness.output(15);
            SteelWeak.Text = Weakness.output(16);
            WaterWeak.Text = Weakness.output(17);

            Weakness.Reset();
        }

        //When The Type 1 Label is Clicked
        private void lblType1_Click(object sender, EventArgs e)
        {
            lblType1.Tag = null;
            lblType1.Image = null;
            RedundancyCheck();
            Output();
        }

        //When The Type 2 Label is Clicked
        private void lblType2_Click(object sender, MouseEventArgs e)
        {
            lblType2.Tag = null;
            lblType2.Image = null;
            RedundancyCheck();
            Output();
        }

        private void swordShieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnBug1.Image = Properties.Resources.Bug_swsh;
            this.btnDark1.Image = Properties.Resources.Dark_swsh;
            this.btnDragon1.Image = Properties.Resources.Dragon_swsh;
            this.btnElectric1.Image = Properties.Resources.Electric_swsh;
            this.btnFairy1.Image = Properties.Resources.Fairy_swsh;
            this.btnFighting1.Image = Properties.Resources.Fighting_swsh;
            this.btnFire1.Image = Properties.Resources.Fire_swsh;
            this.btnFlying1.Image = Properties.Resources.Flying_swsh;
            this.btnGhost1.Image = Properties.Resources.Ghost_swsh;
            this.btnGrass1.Image = Properties.Resources.Grass_swsh;
            this.btnGround1.Image = Properties.Resources.Ground_swsh;
            this.btnIce1.Image = Properties.Resources.Ice_swsh;
            this.btnNormal1.Image = Properties.Resources.Normal_swsh;
            this.btnPoison1.Image = Properties.Resources.Poison_swsh;
            this.btnPsychic1.Image = Properties.Resources.Psychic_swsh;
            this.btnRock1.Image = Properties.Resources.Rock_swsh;
            this.btnSteel1.Image = Properties.Resources.Steel_swsh;
            this.btnWater1.Image = Properties.Resources.Water_swsh;

            this.BugWeak.Image = Properties.Resources.Bug64_swsh;
            this.DarkWeak.Image = Properties.Resources.Dark64_swsh;
            this.DragonWeak.Image = Properties.Resources.Dragon64_swsh;
            this.ElectricWeak.Image = Properties.Resources.Electric64_swsh;
            this.FairyWeak.Image = Properties.Resources.Fairy64_swsh;
            this.FightingWeak.Image = Properties.Resources.Fighting64_swsh;
            this.FireWeak.Image = Properties.Resources.Fire64_swsh;
            this.FlyingWeak.Image = Properties.Resources.Flying64_swsh;
            this.GhostWeak.Image = Properties.Resources.Ghost64_swsh;
            this.GrassWeak.Image = Properties.Resources.Grass64_swsh;
            this.GroundWeak.Image = Properties.Resources.Ground64_swsh;
            this.IceWeak.Image = Properties.Resources.Ice64_swsh;
            this.NormalWeak.Image = Properties.Resources.Normal64_swsh;
            this.PoisonWeak.Image = Properties.Resources.Poison64_swsh;
            this.PsychicWeak.Image = Properties.Resources.Psychic64_swsh;
            this.RockWeak.Image = Properties.Resources.Rock64_swsh;
            this.SteelWeak.Image = Properties.Resources.Steel64_swsh;
            this.WaterWeak.Image = Properties.Resources.Water64_swsh;

            btnSync();
        }

        private void legendsArceusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnBug1.Image = Properties.Resources.Bug_bdsp;
            this.btnDark1.Image = Properties.Resources.Dark_bdsp;
            this.btnDragon1.Image = Properties.Resources.Dragon_bdsp;
            this.btnElectric1.Image = Properties.Resources.Electric_bdsp;
            this.btnFairy1.Image = Properties.Resources.Fairy_bdsp;
            this.btnFighting1.Image = Properties.Resources.Fighting_bdsp;
            this.btnFire1.Image = Properties.Resources.Fire_bdsp;
            this.btnFlying1.Image = Properties.Resources.Flying_bdsp;
            this.btnGhost1.Image = Properties.Resources.Ghost_bdsp;
            this.btnGrass1.Image = Properties.Resources.Grass_bdsp;
            this.btnGround1.Image = Properties.Resources.Ground_bdsp;
            this.btnIce1.Image = Properties.Resources.Ice_bdsp;
            this.btnNormal1.Image = Properties.Resources.Normal_bdsp;
            this.btnPoison1.Image = Properties.Resources.Poison_bdsp;
            this.btnPsychic1.Image = Properties.Resources.Psychic_bdsp;
            this.btnRock1.Image = Properties.Resources.Rock_bdsp;
            this.btnSteel1.Image = Properties.Resources.Steel_bdsp;
            this.btnWater1.Image = Properties.Resources.Water_bdsp;

            this.BugWeak.Image = Properties.Resources.Bug64_bdsp;
            this.DarkWeak.Image = Properties.Resources.Dark64_bdsp;
            this.DragonWeak.Image = Properties.Resources.Dragon64_bdsp;
            this.ElectricWeak.Image = Properties.Resources.Electric64_bdsp;
            this.FairyWeak.Image = Properties.Resources.Fairy64_bdsp;
            this.FightingWeak.Image = Properties.Resources.Fighting64_bdsp;
            this.FireWeak.Image = Properties.Resources.Fire64_bdsp;
            this.FlyingWeak.Image = Properties.Resources.Flying64_bdsp;
            this.GhostWeak.Image = Properties.Resources.Ghost64_bdsp;
            this.GrassWeak.Image = Properties.Resources.Grass64_bdsp;
            this.GroundWeak.Image = Properties.Resources.Ground64_bdsp;
            this.IceWeak.Image = Properties.Resources.Ice64_bdsp;
            this.NormalWeak.Image = Properties.Resources.Normal64_bdsp;
            this.PoisonWeak.Image = Properties.Resources.Poison64_bdsp;
            this.PsychicWeak.Image = Properties.Resources.Psychic64_bdsp;
            this.RockWeak.Image = Properties.Resources.Rock64_bdsp;
            this.SteelWeak.Image = Properties.Resources.Steel64_bdsp;
            this.WaterWeak.Image = Properties.Resources.Water64_bdsp;

            btnSync();
        }

        private void btnSync()
        {
            btnBug2.Image = btnBug1.Image;
            btnDark2.Image = btnDark1.Image;
            btnDragon2.Image = btnDragon1.Image;
            btnElectric2.Image = btnElectric1.Image;
            btnFairy2.Image = btnFairy1.Image;
            btnFighting2.Image = btnFighting1.Image;
            btnFire2.Image = btnFire1.Image;
            btnFlying2.Image = btnFlying1.Image;
            btnGhost2.Image = btnGhost1.Image;
            btnGrass2.Image = btnGrass1.Image;
            btnGround2.Image = btnGround1.Image;
            btnIce2.Image = btnIce1.Image;
            btnNormal2.Image = btnNormal1.Image;
            btnPoison2.Image = btnPoison1.Image;
            btnPsychic2.Image = btnPsychic2.Image;
            btnRock2.Image = btnRock1.Image;
            btnSteel2.Image = btnSteel1.Image;
            btnWater2.Image = btnWater1.Image;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    //End of Class
}
//End of Namespace
