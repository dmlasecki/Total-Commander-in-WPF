using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.MainViews;
namespace TotalCommander.Classes
{
    class FocusCommunication
    {
        SideView lastActive;
        SelectedSide selectedSite;
        public string CorrectSide(SideView sideLeft, SideView sideRight)
        {
            if(sideLeft.isActive != false || sideRight.isActive != false)
            {
                if (sideLeft.isActive == true)
                {
                    sideRight.isActive = false;
                    lastActive = sideLeft;
                }
                if (sideRight.isActive == true)
                {

                    sideLeft.isActive = false;
                    lastActive = sideRight;
                }
            }

            else
            {
                if (lastActive == sideLeft) sideLeft.isActive = true;
                else sideRight.isActive = true;
            }

             selectedSite = sideLeft.isActive == true ? SelectedSide.left : SelectedSide.right;

            string side = selectedSite.ToString();
            return side;

        }
    }
}
