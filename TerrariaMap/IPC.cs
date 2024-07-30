using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace TerrariaMap;

class IPC
{
    public static void Start(string name)
    {
        using NamedPipeServerStream pipeServer = new NamedPipeServerStream(name, PipeDirection.InOut);
        Console.WriteLine("等待客户端连接...");
        pipeServer.WaitForConnection();
        Console.WriteLine("客户端已连接.");
        using (BinaryReader sr = new(pipeServer))
        {
            while (true)
            {
                int count = sr.ReadInt32();
                if (count > 0)
                { 
                    byte[] buffer = sr.ReadBytes(count);
                    Console.WriteLine("接收到来自客户端数居，增在解析地图....");
                    var res = CreateMapFile.Instance.Start(buffer);
                    File.WriteAllBytes(res.Name, res.Buffer);
                    using var ms = new MemoryStream();
                    using BinaryWriter bw = new(ms);
                    bw.Write(res.Name);
                    bw.Write(res.Buffer.Length);
                    bw.Write(res.Buffer);
                    pipeServer.Write(ms.ToArray());
                }
            }
        }
    }
}
