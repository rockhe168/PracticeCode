using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data;

namespace LinqAddDeleteUpdate
{
    public class GuestBookDataContext : DataContext
    {

        public Table<tbGuestBook> tbGuestBook;

        public GuestBookDataContext(string connectionStr) : base(connectionStr) { }

        public GuestBookDataContext(IDbConnection connection) : base(connection) { }


    }
}