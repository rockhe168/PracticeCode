using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitStart
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        void FilterValidList(List<PurchaseOrder> sourceList)
        {

            foreach (var purchaseOrder in sourceList)
            {
                var tempId = purchaseOrder.Id;
                var tempAmount = purchaseOrder.Amount;
                var currentFindObj = sourceList.Where(p => p.Id == tempId && (p.Amount+tempAmount==0));
                sourceList.Remove(purchaseOrder);
                //sourceList.Remove(currentFindObj);
            }

        }
    }


    class PurchaseOrder
    {
        public int Id { get; set; }

        public int Amount { get; set; }
    }



}
