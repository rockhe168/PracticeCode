using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/5 10:13:43
 *  类说明: czcraft.Model
 */
{
    ///<summary>
    ///member表Model
    ///</summary>
    public partial class member
    {
        public System.Int32? Id { get; set; }
        public System.String username { get; set; }
        public System.String password { get; set; }
        public System.String Sex { get; set; }
        public System.String nation { get; set; }
        public System.String mobilephone { get; set; }
        public System.String Telephone { get; set; }
        public System.String Email { get; set; }
        public System.String qq { get; set; }
        public System.String Zipcode { get; set; }
        public System.String Address { get; set; }
        public System.String states { get; set; }
        public System.String VCode { get; set; }
        public System.DateTime? VTime { get; set; }
        public member()
        {
            username = "";
            password = "";
            Sex = "";
            nation = "";
            mobilephone = "";
            Telephone = "";
            Email = "";
            qq = "";
            Zipcode = "";
            states = "";
            Address = "";

        }
    }

}
