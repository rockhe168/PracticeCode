using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***********************************************************************
 *  <copyright file="channelinstallinfo.cs" company="Ctrip.Vacations">
 * 
 *  Author:  Rock(xhhe@Ctrip.com)
 *  Date:    2016/4/8 9:21:16
 *  Description: 
 * 
 * ***********************************************************************/
namespace videoContext
{
    using PetaPoco;

    public partial class channelinstallinfo
    {

        [ResultColumn]
        public int ipcounttemp { get; set; }
        [ResultColumn]
        public int installcounttemp { get; set; }

        [ResultColumn]
        public int pvcounttemp { get; set; }

        [ResultColumn]
        public int paymentsuccesscounttemp { get; set; }

        [ResultColumn]
        public int paymentcounttemp { get; set; }
    }
}
