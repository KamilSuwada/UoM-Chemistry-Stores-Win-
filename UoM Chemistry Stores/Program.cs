using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoM_Chemistry_Stores
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            DateTime now = DateTime.Now;
            string expiryDate = "2022-08-01";
            DateTime expiryTime = DateTime.ParseExact(expiryDate, "yyyy-MM-dd", null);


            UoMChemistryStores windowVC = new UoMChemistryStores();
            TermsAndConditionsVC termsVC = new TermsAndConditionsVC(windowVC);


            while (true)
            {
                if (windowVC.appLogic.userSettings.hasAgreedToTermsAndConditionsV0 == true)
                {
                    MessageBox.Show("Thank you for using an unofficial stores app.\n-KS");
                    Application.Run(windowVC);
                    break;
                }
                else
                {
                    Application.Run(termsVC);

                    if (windowVC.appLogic.userSettings.hasAgreedToTermsAndConditionsV0 == false)
                    {
                        break;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }

            //if (false != false) //(now > expiryTime)
            //{
                //MessageBox.Show("App testing has expired. Please refer to Chemistry H&S for more details");
                //Application.Exit();
            //}
            //else
            //{
                //UoMChemistryStores windowVC = new UoMChemistryStores();
                //TermsAndConditionsVC termsVC = new TermsAndConditionsVC(windowVC);


                //while (true)
                //{
                    //if (windowVC.appLogic.userSettings.hasAgreedToTermsAndConditionsV0 == true)
                    //{
                        //MessageBox.Show("Thank you for using an unofficial stores app.\n-KS");
                        //Application.Run(windowVC);
                        //break;
                    //}
                    //else
                    //{
                        //Application.Run(termsVC);

                        //if (windowVC.appLogic.userSettings.hasAgreedToTermsAndConditionsV0 == false)
                        //{
                            //break;
                        //}
                        //else
                        //{
                            //Application.Exit();
                        //}
                    //}
                //}
            //}

            Application.Exit();
        }
    }
}
