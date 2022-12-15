using DotFuzzy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abueva_FuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;
        MembershipFunctionCollection strengthVacuum, dirt, newStrength;
        LinguisticVariable myStrengthVacuum, myDirt, myNewStrength;
        FuzzyRuleCollection myRules;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void setMembers()
        {
            strengthVacuum = new MembershipFunctionCollection();
            strengthVacuum.Add(new MembershipFunction("Slow", 0.0, 0.0, 10.0, 30.0));
            strengthVacuum.Add(new MembershipFunction("Medium", 25.0, 45.0, 50.0, 65.0));
            strengthVacuum.Add(new MembershipFunction("Fast", 60.0, 65.0, 100.0, 100.0));
            myStrengthVacuum = new LinguisticVariable("STRENGTH", strengthVacuum);

            dirt = new MembershipFunctionCollection();
            dirt.Add(new MembershipFunction("Less", 0.0, 0.0, 10.0, 30.0));
            dirt.Add(new MembershipFunction("Moderate", 25.0, 45.0, 50.0, 65.0));
            dirt.Add(new MembershipFunction("High", 60.0, 65.0, 100.0, 100.0));
            myDirt = new LinguisticVariable("DIRT", dirt);

            newStrength = new MembershipFunctionCollection();
            newStrength.Add(new MembershipFunction("Slow", 0.0, 0.0, 10.0, 30.0));
            newStrength.Add(new MembershipFunction("Medium", 25.0, 45.0, 50.0, 65.0));
            newStrength.Add(new MembershipFunction("Fast", 60.0, 65.0, 100.0, 100.0));
            myNewStrength = new LinguisticVariable("VACUUMING", newStrength);
        }

        public void setRules()
        {
            myRules = new FuzzyRuleCollection();
            myRules.Add(new FuzzyRule("IF (DIRT IS Less) AND (STRENGTH IS Slow)  THEN VACUUMING IS Slow"));
            myRules.Add(new FuzzyRule("IF (DIRT IS Less) AND (STRENGTH IS Medium)  THEN VACUUMING IS Slow"));
            myRules.Add(new FuzzyRule("IF (DIRT IS Less) AND (STRENGTH IS Fast)  THEN VACUUMING IS Medium"));
            myRules.Add(new FuzzyRule("IF (DIRT IS Moderate) AND (STRENGTH IS Slow)  THEN VACUUMING IS Medium"));
            myRules.Add(new FuzzyRule("IF (DIRT IS Moderate) AND (STRENGTH IS Medium)  THEN VACUUMING IS Medium"));
            myRules.Add(new FuzzyRule("IF (DIRT IS Moderate) AND (STRENGTH IS Fast)  THEN VACUUMING IS Fast"));
            myRules.Add(new FuzzyRule("IF (DIRT IS High) AND (STRENGTH IS Slow)  THEN VACUUMING IS Medium"));
            myRules.Add(new FuzzyRule("IF (DIRT IS High) AND (STRENGTH IS Medium)  THEN VACUUMING IS Fast"));
            myRules.Add(new FuzzyRule("IF (DIRT IS High) AND (STRENGTH IS Fast)  THEN VACUUMING IS Fast"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myStrengthVacuum);
            fe.LinguisticVariableCollection.Add(myDirt);
            fe.LinguisticVariableCollection.Add(myNewStrength);
            fe.FuzzyRuleCollection = myRules;
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            strength.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lbl_dirt.Text = trackBar2.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDirt.InputValue = double.Parse(lbl_dirt.Text);
            myDirt.Fuzzify("High");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myStrengthVacuum.InputValue = double.Parse(strength.Text);
            myStrengthVacuum.Fuzzify("Slow");
        }
        
        private void lbl_distance_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setFuzzyEngine();
            fe.Consequent = "VACUUMING";
            lbl_result.Text = "" + fe.Defuzzify();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            myDirt.InputValue = trackBar2.Value;
        }

        public void FuzzifyValues()
        {
            myStrengthVacuum.InputValue = trackBar1.Value;
            myStrengthVacuum.Fuzzify("Slow");
            myDirt.InputValue = trackBar2.Value;
            myDirt.Fuzzify("High");
        }
    }
}
