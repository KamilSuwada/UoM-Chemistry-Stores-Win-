using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoM_Chemistry_Stores
{
    public partial class PersonalDataVC : Form
    {

        public PersonalDataVC()
        {
            InitializeComponent();
        }

        public PersonalData personalD { get; set; }
        public UoMChemistryStores windowVC { get; set; }



        public void initialise()
        {
            if (this.personalD != null)
            {
                this.nameBox.Text = this.personalD.name;
                this.codeBox.Text = this.personalD.code;
                this.ppeBox.Text = this.personalD.ppeCode;
                this.labBox.Text = this.personalD.lab;
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.nameBox.Text == "")
            {
                return;
            }

            if (this.codeBox.Text == "")
            {
                return;
            }

            if (this.labBox.Text == "")
            {
                return;
            }

            if (this.ppeBox.Text == "")
            {
                return;
            }

            windowVC.appLogic.personalData.name = this.nameBox.Text;
            windowVC.appLogic.personalData.lab = this.labBox.Text;
            windowVC.appLogic.personalData.code = this.codeBox.Text;
            windowVC.appLogic.personalData.ppeCode = this.ppeBox.Text;

            windowVC.Show();
            this.Close();
        }
    }
}
