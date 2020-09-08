namespace Test
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;

    public class SocketClient
    {
        static void Main()
        {
            //[{"CMD":252,"UID":"l0g1n","QRY":"{\"USERNAME\":\"admin\",\"PASSWORD\":\"elica2019\"}","EXE":252,"HNDL": 0,"VER":"2.42.3.5","MOD":0,"ADMIN":0,"COUNTER":2,"BROADCAST":1,"LANGUAGE":0,"CLIENT":1}]
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");

            tcpclnt.Connect("127.0.0.1", 6000);
            // use the ipaddress as in the server program

            Console.WriteLine("Connected");
            try
            {
                Console.Write("Enter the string to be transmitted : ");

                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[20000000];
                int bytes = 0;
                while (true)
                {
                    long k = stm.Read(bb, 0, 20000000);

                    str = System.Text.Encoding.ASCII.GetString(bb, 0, bytes);
                    Console.WriteLine("Received: {0}", str);
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(bb[i]));
                    }

                    Console.WriteLine();
                    
                }
                tcpclnt.Client.Disconnect(true);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}
