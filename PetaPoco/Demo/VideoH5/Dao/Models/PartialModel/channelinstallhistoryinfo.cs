using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***********************************************************************
 *  <copyright file="channelinstallhistoryinfo.cs" company="Ctrip.Vacations">
 * 
 *  Author:  Rock(xhhe@Ctrip.com)
 *  Date:    2016/4/7 20:07:04
 *  Description: 
 * 
 * ***********************************************************************/
namespace Dao.Models.PartialModel
{
    using PetaPoco;

    public partial class channelinstallhistoryinfo
    {
        [ResultColumn]
        public int installcount { get; set; }
    }
}
