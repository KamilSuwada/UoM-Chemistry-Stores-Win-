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
    public partial class TermsAndConditionsVC : Form
    {
        private UoMChemistryStores windowVC { get; set; }

        public TermsAndConditionsVC(UoMChemistryStores windowVC)
        {
            InitializeComponent();
            this.windowVC = windowVC;
            setUpTermsBox();
        }



        private void setUpTermsBox()
        {
            string termsAndConditionsV0 = @"
T&Cs for UoM Chemistry Stores V4 app:


1. General:

    a) This app is unofficial, therefore it is not guaranteed that it will comply with current/future rules on ordering in UoM Chemistry.

    b) App creator (Kamil Suwada) will not be responsible for any issues (damages, mistakes, etc...) related to the operation of the app.


2. Privacy:

    a) The app does not collect any personal data. Files saved within the app are necessary for the app functions.


Happy ordering!

Kamil Suwada";

            this.termsBox.Text = termsAndConditionsV0;
        }


        private void agreeButton_Click(object sender, EventArgs e)
        {
            this.windowVC.appLogic.userSettings.agreeToTermsV0();
            this.Close();
        }

        private void disagreeButton_Click(object sender, EventArgs e)
        {
            this.windowVC.appLogic.userSettings.disagreeToTermsV0();
            this.Close();
        }
    }
}
