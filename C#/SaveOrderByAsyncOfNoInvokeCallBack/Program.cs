using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaveOrderByAsyncOfNoInvokeCallBack
{
    class Program
    {

        delegate void DoWorking(Request request, Response response, List<LogicException> exceptionList);

        static void Main(string[] args)
        {
            Request request = new Request()
            {
                Id = 1,
                Name = "Rock",
                Address = "携程"
            };

            Response response = new Response();

            TempOrder tmpOrder = new TempOrder();

            List<LogicException> exceptionList = new List<LogicException>();


            try
            {
                DoWorking canBooking = new DoWorking(tmpOrder.CanBooking);

                IAsyncResult canBookingResult = canBooking.BeginInvoke(request,response,exceptionList,null,null);

                DoWorking saveOrder = new DoWorking(SaveOrder);

                IAsyncResult saveOrderResult = saveOrder.BeginInvoke(request, response, exceptionList, null, null);

                DoWorking paymentInfo = new DoWorking(tmpOrder.GetPaymentInfo);

                IAsyncResult paymentInfoResult = paymentInfo.BeginInvoke(request, response, exceptionList, null, null);


                bool result = true;
                int count = 0;
                while (result && count < 100000)
                {
                    count++;
                    if (canBookingResult.IsCompleted && saveOrderResult.IsCompleted && paymentInfoResult.IsCompleted)
                    {
                        Console.WriteLine("全部完成.....");
                        result = false;
                    }
                    else
                    {
                        Console.WriteLine("还没有全部完成....");
                        result = true;
                    }
                }

                if(exceptionList !=null && exceptionList.Count>0)
                {
                    throw exceptionList.FirstOrDefault();
                }
                //canBookingResult.

                Console.WriteLine(response.ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("处理异常了，，" + ex.Message);
                Console.ReadKey();
                //throw;
            }
        }

        public static void CallBackFunction(IAsyncResult iar)
        {
            Console.WriteLine("                 CallBackFunction");

            // 取出回调前的状态参数

            AsyncResult ar = (AsyncResult)iar;

            try
            {
                DoWorking doWorking = (DoWorking)ar.AsyncDelegate;

                doWorking.EndInvoke(iar);
            }
            catch (Exception ex)
            {
                throw new LogicException("回调异常");
                //cp.Callback(cp.InputData, default(TOut), ex, cp.State);
            }
        }

        public static void SaveOrder(Request request, Response response, List<LogicException> exceptionList)
        {
            try
            {
                response.Name = request.Name;
                Thread.Sleep(500);
                Console.WriteLine("SaveOrder Woking....");
                request.HaveException();
            }
            catch (Exception ex)
            {
                exceptionList.Add(new LogicException(ex.Message));
            }
           
        }


    }

    public class TempOrder
    {
        public void CanBooking(Request request, Response response,List<LogicException> exceptionList)
        {
            Console.WriteLine("CanBooking Woking....");
            response.Id = request.Id;
            Thread.Sleep(200);

        }

        public void GetPaymentInfo(Request request, Response response, List<LogicException> exceptionList)
        {
            Console.WriteLine("GetPaymentInfo Woking....");
            response.Address = request.Address;
            Thread.Sleep(200);
        }
    }

    public class Request
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public void HaveException()
        {
            throw new ArgumentException("反正我是有异常，你看着办....");
        }
    }

    public class Response
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return "Response:-->Id=" + this.Id + "-->Name=" + this.Name + "-->Address=" + this.Address;
        }

    }

    /// <summary>
    /// TODO: 业务异常
    /// </summary>
    public class LogicException : Exception
    {
        public LogicException(string msg)
            : base(msg)
        {

        }

        public object Data { get; set; }
    }
}
