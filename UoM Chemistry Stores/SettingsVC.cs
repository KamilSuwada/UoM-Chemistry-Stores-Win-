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
    public partial class SettingsVC : Form
    {

        private int textSize { get; set; }
        private int imageSize { get; set; }
        private UserSettings.PrefferedView prefferedView { get; set; } 
        private bool ordersAsListsBool { get; set; }
        private UoMChemistryStores windowVC {  get; set; }

        public SettingsVC(UoMChemistryStores windowVC)
        {
            InitializeComponent();
            this.windowVC = windowVC;

            textSize = windowVC.appLogic.userSettings.fontSize;
            textSizeLabel.Text = textSize.ToString();

            imageSize = windowVC.appLogic.userSettings.imageSize;
            currentImageSizeLabel.Text = imageSize.ToString();

            ordersAsListsBool = windowVC.appLogic.userSettings.prefersOrdersAsLists;

            prefferedView = windowVC.appLogic.userSettings.prefferedView;

            if (ordersAsListsBool == true)
            {
                ordersAsLists.CheckState = CheckState.Checked;
            }
            else
            {
                ordersAsLists.CheckState = CheckState.Unchecked;
            }

            dropDownBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dropDownBox.Items.Add("Detail List");
            dropDownBox.Items.Add("Image List");
            dropDownBox.Items.Add("Image Collection");

            switch (this.prefferedView)
            {
                case UserSettings.PrefferedView.list:
                    dropDownBox.SelectedIndex = 0;
                    break;

                case UserSettings.PrefferedView.smallImages:
                    dropDownBox.SelectedIndex = 1;
                    break;

                case UserSettings.PrefferedView.largeImages:
                    dropDownBox.SelectedIndex = 2;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {


            if (ordersAsLists.CheckState == CheckState.Checked)
            {
                windowVC.appLogic.setOrderPreferenceAs(true);
            }
            else
            {
                windowVC.appLogic.setOrderPreferenceAs(false);
            }

            windowVC.appLogic.changeFontSizeTo(this.textSize);
            windowVC.appLogic.userSettings.setImageSize(this.imageSize);

            string selected = dropDownBox.SelectedItem.ToString();

            switch (selected)
            {
                case "Detail List":
                    this.prefferedView = UserSettings.PrefferedView.list;
                    break;

                case "Image List":
                    this.prefferedView = UserSettings.PrefferedView.smallImages;
                    break;

                case "Image Collection":
                    this.prefferedView = UserSettings.PrefferedView.largeImages;
                    break;

                default:
                    break;
            }

            windowVC.appLogic.userSettings.setPrefferedView(this.prefferedView);
            windowVC.appLogic.reloadImages();
            windowVC.appLogic.createImageList(windowVC.appLogic.imagesDictionary);
            windowVC.refreshAll();
            this.Close();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            if (this.textSize > 8)
            {
                this.textSize -= 1;
                this.textSizeLabel.Text = this.textSize.ToString();
            }
            else
            {
                MessageBox.Show("Sorry, text size cannot be set to less than 9pt at this time.", "Text Size");
            }
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (this.textSize < 31)
            {
                this.textSize += 1;
                this.textSizeLabel.Text = this.textSize.ToString();
            }
            else
            {
                MessageBox.Show("Sorry, text size cannot be set to more than 30pt at this time.", "Text Size");
            }
        }

        private void ordersAsLists_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void smallerImageButton_Click(object sender, EventArgs e)
        {
            if (this.imageSize > 12)
            {
                this.imageSize -= 12;
                this.currentImageSizeLabel.Text = this.imageSize.ToString();
            }
            else
            {
                MessageBox.Show("Sorry, image size cannot be set to less than 12pt at this time.", "Image Size");
            }
        }

        private void biggerImageButton_Click(object sender, EventArgs e)
        {
            this.imageSize += 12;
            this.currentImageSizeLabel.Text = this.imageSize.ToString();
        }
    }
}
