using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class UserSettings
    {
        public bool hasAgreedToTermsAndConditionsV0 { get; set; } = false;
        public int fontSize { get; set; } = 10;
        public bool prefersOrdersAsLists { get; set; } = false;
        public PrefferedView prefferedView { get; set; } = PrefferedView.largeImages;
        public int imageSize { get; set; } = 96;


        public enum PrefferedView
        {
            list,
            smallImages,
            largeImages
        }


        public void setPrefferedView(PrefferedView view)
        {
            this.prefferedView = view;
        }


        public void setImageSize(int size)
        {
            this.imageSize = size;
        }


        public void restoreDefault()
        {
            hasAgreedToTermsAndConditionsV0 = false;
            prefersOrdersAsLists = false;
            fontSize = 10;
            prefferedView = PrefferedView.smallImages;
            imageSize = 96;
        }


        public void agreeToTermsV0()
        {
            this.hasAgreedToTermsAndConditionsV0 = true;
        }


        public void disagreeToTermsV0()
        {
            this.hasAgreedToTermsAndConditionsV0 = false;
        }
    }
}
