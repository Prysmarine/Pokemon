/*
    Pokemon "Pokedex" 
*/ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace Pokemon
{
    public partial class Pokemon : Form
    {
        private Button buttonRead;
        private Button button2;
        List<Mon> Mons = new List<Mon>();
        List<String> Names = new List<String>();
        
        public Pokemon()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(@"pokemon.csv"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();
                    strArray = str.Split(',');
                    Mon currentMon = new Mon();
                    currentMon.dex = strArray[0];
                    currentMon.name = strArray[1];
                    currentMon.form = strArray[2];
                    currentMon.type1 = strArray[3];
                    currentMon.type2 = strArray[4];
                    currentMon.egg1 = strArray[5];
                    currentMon.egg2 = strArray[6];
                    currentMon.hp = strArray[7];
                    currentMon.atk = strArray[8];
                    currentMon.def = strArray[9];
                    currentMon.satk = strArray[10];
                    currentMon.sdef = strArray[11];
                    currentMon.spd = strArray[12];
                    currentMon.total = strArray[13];
                    currentMon.gen = strArray[14];
                    Mons.Add(currentMon);
                }

            }
            
            //Populates the Names list
            using (StreamReader sr = new StreamReader(@"pokemonlist.csv"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;               
                    str = sr.ReadLine();
                    Names.Add(str);
                }
            }
          
            //Adds each name from the Names list to the combo box as an option
            foreach (String x in Names)
            {
                comboBreed.Items.Add(x);
            }

            //Adds each name + form (if applicable) to the Stat Lookup tab combo box
            foreach (Mon x in Mons)
            {
                if (x.form != "")
                {
                    comboLook.Items.Add(x.form + " " + x.name);
                }
                else
                    comboLook.Items.Add(x.name);
                
            }

            comboNature.SelectedIndex = 25;
            level.Value = 50;
        }

        //When The Type Is Selected
        private void CheckSelected1(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (lblType1.Tag is null)
            {
                lblType1.Image = btn.Image;
                lblType1.Tag = btn.Tag;
            }
            else if (lblType1.Tag != null)
            {
                if(lblType1.Tag == btn.Tag)
                {
                    lblType1.Image = null;
                    lblType1.Tag = null;
                }
                else if(lblType1.Tag != btn.Tag)
                {
                    if (lblType2.Tag != btn.Tag)
                    {
                        lblType2.Image = btn.Image;
                        lblType2.Tag = btn.Tag;
                    }
                    else if(lblType2.Tag == btn.Tag)
                    {
                        lblType2.Image = null;
                        lblType2.Tag = null;
                    }
                }
            }

            if (lblType1.Tag is null && lblType2.Tag != null)
            {
                lblType1.Image = lblType2.Image;
                lblType1.Tag = lblType2.Tag;
                lblType2.Image = null;
                lblType2.Tag = null;
            }


            Output();                    
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
                case "Psychic":
                    Weakness.WeakCalc(2, 2, 1, 1, 1, .5, 1, 1, 2, 1, 1, 1, 1, 1, .5, 1, 1, 1);
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
                case "Psychic":
                    Weakness.WeakCalc(2, 2, 1, 1, 1, .5, 1, 1, 2, 1, 1, 1, 1, 1, .5, 1, 1, 1);
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
        }

        //This is the Brilliant Diamond/Shining Pearl Tool Strip Option
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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //The Search Button On the Breeding Matchups Tab
        private void buttonRead_Click(object sender, EventArgs e)
        {

            listTest.Items.Clear();
            string i = "", j= "";


            foreach(Mon x in Mons)
            {
                if (x.name == comboBreed.SelectedItem.ToString())
                {
                    if (x.form != "Mega")
                        {
                        if (x.egg1 == "No Eggs Discovered")
                        {
                            listTest.Items.Add("Cannot Breed");
                            i = x.egg1;
                        }
                        else
                        {
                            i = x.egg1;
                            j = x.egg2;
                        }
                    }
                    
                }            
            }

            if (i != "No Eggs Discovered")
            {
                foreach (Mon z in Mons)
                {
                    if (z.egg1 != "No Eggs Discovered")
                    {
                        if (z.egg1 == i || z.egg2 == i || z.egg1 == j || z.egg2 == j || z.egg1 == "Ditto")
                        {
                            if (z.form != "")
                            {
                                listTest.Items.Add(z.name + " - " + z.form);
                            }
                            else
                                listTest.Items.Add(z.name);
                        }
                    }
                }
            }
        }

        private void selectedMon(object sender, EventArgs e)
        {
            foreach (Mon x in Mons)
            {
                if (x.form != "")
                {
                    if (x.form + " " + x.name == comboLook.Text)
                    {
                        lblHP.Text = x.hp;
                        lblAtk.Text = x.atk;
                        lblDef.Text = x.def;
                        lblSpeAtk.Text = x.satk;
                        lblSpeDef.Text = x.sdef;
                        lblSpeed.Text = x.spd;
                    }
                }
                else if (x.name == comboLook.Text)
                {
                    lblHP.Text = x.hp;
                    lblAtk.Text = x.atk;
                    lblDef.Text = x.def;
                    lblSpeAtk.Text = x.satk;
                    lblSpeDef.Text = x.sdef;
                    lblSpeed.Text = x.spd;
                }                     
            }
            natureUpdate(sender, e);
        }

        private void natureUpdate(object sender, EventArgs e)
        {
            int plus = 0, minus = 0;
            natureDefault();

            /*
                atk     -  1
                def     -  2
                satk    -  3
                sdef    -  4
                speed   -  5
            */
            switch(comboNature.SelectedIndex)
            {
                case 0: case 6: case 12: case 18: case 24:
                    break;
                case 1: case 2: case 3: case 4:
                    lblAtkNat.Text = "Plus";
                    plus = 1;
                    switch (comboNature.SelectedIndex)
                    {
                        case 1:
                            lblDefNat.Text = "Minus";
                            minus = 2;
                            break;
                        case 2:
                            lblSpeedNat.Text = "Minus";
                            minus = 5;
                            break;
                        case 3:
                            lblSpeAtkNat.Text = "Minus";
                            minus = 3;
                            break;
                        case 4:
                            lblSpeDefNat.Text = "Minus";
                            minus = 4;
                            break;
                        default:
                            lblHPNat.Text = "Error";
                            break;
                    }
                    break;
                case 5: case 7: case 8: case 9:
                    lblDefNat.Text = "Plus";
                    plus = 2;
                    switch (comboNature.SelectedIndex)
                    {
                        case 5:
                            lblAtkNat.Text = "Minus";
                            minus = 1;
                            break;
                        case 7:
                            lblSpeedNat.Text = "Minus";
                            minus = 5;
                            break;
                        case 8:
                            lblSpeAtkNat.Text = "Minus";
                            minus = 3;
                            break;
                        case 9:
                            lblSpeDefNat.Text = "Minus";
                            minus = 4;
                            break;
                        default:
                            lblHPNat.Text = "Error";
                            break;
                    }
                    break;
                case 10: case 11: case 13: case 14:
                    lblSpeedNat.Text = "Plus";
                    plus = 5;
                    switch (comboNature.SelectedIndex)
                    {
                        case 10:
                            lblAtkNat.Text = "Minus";
                            minus = 1; 
                            break;
                        case 11:
                            lblDefNat.Text = "Minus";
                            minus = 2;
                            break;
                        case 13:
                            lblSpeAtkNat.Text = "Minus";
                            minus = 3;
                            break;
                        case 14:
                            lblSpeDefNat.Text = "Minus";
                            minus = 4;
                            break;
                        default:
                            lblHPNat.Text = "Error";
                            break;
                    }
                    break;
                case 15: case 16: case 17: case 19:
                    lblSpeAtkNat.Text = "Plus";
                    plus = 3;
                    switch (comboNature.SelectedIndex)
                    {
                        case 15:
                            lblAtkNat.Text = "Minus";
                            minus = 1;
                            break;
                        case 16:
                            lblDefNat.Text = "Minus";
                            minus = 2;
                            break;
                        case 17:
                            lblSpeedNat.Text = "Minus";
                            minus = 5;
                            break;
                        case 19:
                            lblSpeDefNat.Text = "Minus";
                            minus = 4;
                            break;
                        default:
                            lblHPNat.Text = "Error";
                            break;
                    }
                    break;
                case 20: case 21: case 22: case 23:
                    lblSpeDefNat.Text = "Plus";
                    plus = 4;
                    switch (comboNature.SelectedIndex)
                    {
                        case 20:
                            lblAtkNat.Text = "Minus";
                            minus = 1;
                            break;
                        case 21:
                            lblDefNat.Text = "Minus";
                            minus = 2;
                            break;
                        case 22:
                            lblSpeedNat.Text = "Minus";
                            minus = 5;
                            break;
                        case 23:
                            lblSpeAtkNat.Text = "Minus";
                            minus = 3;
                            break;
                        default:
                            lblHPNat.Text = "Error";
                            break;
                    }
                    break;
                                                 
            }//End of Outer Switch
            /*
            Pass in order
                Base
                    HP, ATK, DEF, SATK, SDEF, SPEED, Nature+, Nature-

                IV
                    HP, ATK, DEF, SATK, SDEF, SPEED

                EV
                    HP, ATK, DEF, SATK, SDEF, SPEED
            */
            bool ready = int.TryParse(lblHP.Text, out _);
            if (ready)
            {
                Nature.statIn(
                    Int32.Parse(lblHP.Text), Int32.Parse(lblAtk.Text), Int32.Parse(lblDef.Text), Int32.Parse(lblSpeAtk.Text), Int32.Parse(lblSpeDef.Text), Int32.Parse(lblSpeed.Text), plus, minus, Convert.ToInt32(level.Value),
                    Convert.ToInt32(ivHP.Value), Convert.ToInt32(ivAtk.Value), Convert.ToInt32(ivDef.Value), Convert.ToInt32(ivSpeAtk.Value), Convert.ToInt32(ivSpeDef.Value), Convert.ToInt32(ivSpeed.Value),
                    Convert.ToInt32(evHP.Value), Convert.ToInt32(evAtk.Value), Convert.ToInt32(evDef.Value), Convert.ToInt32(evSpeAtk.Value), Convert.ToInt32(evSpeDef.Value), Convert.ToInt32(evSpeed.Value)
                    );
            }
            else
                natureDefault();
            
            lblHPFin.Text = Nature.output(0);
            lblAtkFin.Text = Nature.output(1);
            lblDefFin.Text = Nature.output(2);
            lblSpeAtkFin.Text = Nature.output(3);
            lblSpeDefFin.Text = Nature.output(4);
            lblSpeedFin.Text = Nature.output(5);

            int j = Convert.ToInt32(evHP.Value + evAtk.Value + evDef.Value + evSpeAtk.Value + evSpeDef.Value + evSpeed.Value);
            if (j > 508)
            {
                evTotal.ForeColor = Color.Red;
            }
            else
                evTotal.ForeColor = Color.Black;

            evTotal.Text = j.ToString();

            int i = 508 - j;
            evRemain.Text = i.ToString();

            if (i < 0)
            {
                evRemain.ForeColor = Color.Red;
            }
            else
                evRemain.ForeColor = Color.Black;
        }

        private void natureDefault()
        {
            lblHPNat.Text = "-";
            lblAtkNat.Text = "-";
            lblDefNat.Text = "-";
            lblSpeAtkNat.Text = "-";
            lblSpeDefNat.Text = "-";
            lblSpeedNat.Text = "-";
        }
    }
    //End of Class
}
//End of Namespace
