
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;


namespace Mpmp
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new UPDServer(19135, "wrewolf");
            k.start();
        }
    }

    class UPDServer
    {
        long server_id;
        string motd = "MCCPP;Demo;";

        public UPDServer(int port, string name)
        {
            Random r = new Random();
            listenPort = port;
            motd += name;
            server_id = r.Next(int.MinValue, int.MaxValue);

        }
        private int listenPort;



        //server
        public void start()
        {
            int recv; //храним размер полученных данных
            byte[] data = new byte[1500]; //данные, которые будут передаваться или приниматься

            Socket mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //В отличие от клиента "слушаем" порт listenPort
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, listenPort);
            mysocket.Bind(ipep); //привязываем точку к нашему сокету
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);

            //запускаем бесконечный цикл, который будет принимать и отправлять данные
            while (true)
            {
                data = new byte[1493];
                //принимаем данные от клиента. recv содержир размер, т.е. количество принятых символов
                recv = mysocket.ReceiveFrom(data, ref Remote);
                string message = Encoding.UTF8.GetString(data, 0, recv);
                //Console.WriteLine(Remote.ToString() + "\t" + data[0] + "\t" + message);
                List<byte> tmp = new List<byte>();
                tmp.Clear();
                Console.Write("\n<\n");
                for (int i = 1; i <= recv; i++)
                {
                    Console.Write((data[i - 1]).ToString("X2") + " ");
                    if ((i % 16 == 0) && i != 0)
                        Console.Write("\n");
                }
                Console.Write("\ntotal:{0}", recv.ToString());
                switch (data[0])
                {
                    case Packages.ID_UNCONNECTED_PING_OPEN_CONNECTIONS: //на ответ от клиента Hello, шлем ответ ОК
                        long pingId = BitConverter.ToInt64(data, 1);
                        tmp.Add(Packages.ID_UNCONNECTED_PING_OPEN_CONNECTIONSs);
                        tmp.AddRange(BitConverter.GetBytes(pingId));
                        tmp.AddRange(BitConverter.GetBytes(server_id));
                        tmp.AddRange(Packages.MAGIC);
                        byte[] l = BitConverter.GetBytes((short)(motd.Length));
                        tmp.Add(l[1]);
                        tmp.Add(l[0]);
                        tmp.AddRange(Encoding.UTF8.GetBytes(motd));
                        Thread.Sleep(60);
                        data = tmp.ToArray();
                        break;
                    case Packages.ID_OPEN_CONNECTION_REQUEST_1:
                        short mtuc = (short)(recv - 17);
                        tmp.Add(Packages.ID_OPEN_CONNECTION_REPLY_1);
                        tmp.AddRange(Packages.MAGIC);
                        tmp.AddRange(BitConverter.GetBytes(server_id));
                        tmp.Add(0x00);
                        tmp.AddRange(BitConverter.GetBytes(mtuc));
                        data = tmp.ToArray();
                        break;
                    case Packages.ID_OPEN_CONNECTION_REQUEST_2:
                        tmp.Add(Packages.ID_OPEN_CONNECTION_REPLY_2);
                        tmp.AddRange(Packages.MAGIC);
                        tmp.AddRange(BitConverter.GetBytes(server_id));
                        ushort port = ushort.Parse(Remote.ToString().Substring(Remote.ToString().IndexOf(":") + 1));
                        tmp.AddRange(BitConverter.GetBytes(port));
                        tmp.Add(0x00);
                        break;
                    case Packages.CUSTOM_PACKET80:
                    case Packages.CUSTOM_PACKET81:
                    //case Packages.CUSTOM_PACKET82:
                    //case Packages.CUSTOM_PACKET83:
                    //case Packages.CUSTOM_PACKET84:
                    case Packages.CUSTOM_PACKET85:
                    case Packages.CUSTOM_PACKET86:
                    case Packages.CUSTOM_PACKET87:
                    case Packages.CUSTOM_PACKET88:
                    case Packages.CUSTOM_PACKET89:
                    case Packages.CUSTOM_PACKET8A:
                    case Packages.CUSTOM_PACKET8B:
                    case Packages.CUSTOM_PACKET8C:
                    case Packages.CUSTOM_PACKET8D:
                    case Packages.CUSTOM_PACKET8E:
                    case Packages.CUSTOM_PACKET8F:
                        byte[] cnt = new byte[] { 0x00, data[1], data[2], data[3] };
                        int count = BitConverter.ToInt32(cnt, 0);
                        byte[] payload = data.Skip(4).ToArray();

                        short lenght;
                        byte[] Count;
                        int Unknown;
                        byte[] paket;

                        switch (payload[0])
                        {
                            case 0x00:
                                lenght = BitConverter.ToInt16(payload, 1);
                                break;
                            case 0x40:
                                lenght = BitConverter.ToInt16(payload, 1);
                                Count = payload.Skip(4).Take(3).ToArray();
                                paket = payload.Skip(7).ToArray();
                                break;
                            case 0x60:
                                lenght = BitConverter.ToInt16(payload, 1);
                                Count = payload.Skip(4).Take(3).ToArray();
                                Unknown = BitConverter.ToInt32(payload, 7);
                                paket = payload.Skip(11).ToArray();
                                break;
                        }
                        break;
                    case Packages.LoginPacket:
                        short namelenght = BitConverter.ToInt16(data, 1);
                        string name = Encoding.UTF8.GetString(data.Skip(3).Take(namelenght).ToArray());
                        Int32 p1 = BitConverter.ToInt16(data, 1 + namelenght);
                        Int32 p2 = BitConverter.ToInt16(data, 1 + namelenght+2);
                        tmp.AddRange(BitConverter.GetBytes(0x83));
                        tmp.AddRange(BitConverter.GetBytes(0x01));
                        break;
                    case Packages.ReadyPacket:
                        tmp.AddRange(BitConverter.GetBytes(0x87));
                        tmp.AddRange(BitConverter.GetBytes(0x00000194));
                        tmp.AddRange(BitConverter.GetBytes(0x00000000));
                        tmp.AddRange(BitConverter.GetBytes(0x00000001));
                        tmp.AddRange(BitConverter.GetBytes(0x00000017));
                        tmp.AddRange(BitConverter.GetBytes(0x43008000));
                        tmp.AddRange(BitConverter.GetBytes(0x42820000));
                        tmp.AddRange(BitConverter.GetBytes(0x43008000));
                        break;
                    case Packages.Disconnect:
                        break;
                    case Packages.NACK:
                        break;
                    case Packages.ACK:
                        break;
                }
                Console.Write("\n>\n");
                data = tmp.ToArray();
                for (int i = 1; i <= tmp.Count; i++)
                {
                    Console.Write((data[i - 1]).ToString("X2") + " ");
                    if ((i % 16 == 0) && i != 0)
                        Console.Write("\n");
                }
                Console.Write("\ntotal:{0}\n", tmp.Count.ToString());
                //Remote содержит адрес, с которого пришло сообщение. Ему его назад и отправляем
                //Console.WriteLine("127.0.0.1:0      \t" + data[0] + "\t" + message);
                mysocket.SendTo(data, data.Length, SocketFlags.None, _getHost(Remote.ToString()));
            }
        }

        //функция _getHost для сервера отличается только портом. Вместо 9050, отправлять всегда будем на 9051
        private EndPoint _getHost(string text)
        {
            //вырезаем из строки только IP адрес формата IPv4
            string host = text.Remove(text.IndexOf(":"), text.Length - text.IndexOf(":"));
            int port = int.Parse(text.Substring(text.IndexOf(":") + 1));
            //создаем объект адреса. Переменная host уже имеет вид [0-255].[0-255].[0-255].[0-255]
            IPAddress hostIPAddress = IPAddress.Parse(host);

            IPEndPoint hostIPEndPoint = new IPEndPoint(hostIPAddress, port);
            EndPoint To = (EndPoint)(hostIPEndPoint);
            return To;
        }
    }
}
