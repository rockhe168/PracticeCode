﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***********************************************************************
 *  <copyright file="pvinfo.cs" company="Ctrip.Vacations">
 * 
 *  Author:  Rock(xhhe@Ctrip.com)
 *  Date:    2016/4/7 20:10:15
 *  Description: 
 * 
 * ***********************************************************************/
namespace videoContext
{
    using PetaPoco;

   public partial class pvinfo
    {
        [ResultColumn]
        public int pvcount { get; set; }
    }
}
