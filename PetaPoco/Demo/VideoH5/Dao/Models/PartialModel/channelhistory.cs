using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***********************************************************************
 *  <copyright file="channelhistory.cs" company="Ctrip.Vacations">
 * 
 *  Author:  Rock(xhhe@Ctrip.com)
 *  Date:    2016/3/31 19:32:27
 *  Description: 
 * 
 * ***********************************************************************/
namespace videoContext
{
    using PetaPoco;

    public partial class channelhistory
    {
        [ResultColumn]
        public DateTime datestr { get; set; }

        [ResultColumn]
        public long visitcount { get; set; }
    }
}
