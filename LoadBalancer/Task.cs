using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace LoadBalancer
{
    public class Task
    {
        public Task()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public string Command
        {
            get;
            set;
        }

        public string Arguments
        {
            get;
            set;
        }

        public int ExitCode
        {
            get;
            set;
        }
        public string Result
        {
            get;
            set;
        }
    }

    public static class TaskSender
    {
        public static Task RecieveTask(Socket socket)
        {
            byte[] sizeBuffer = new byte[4];
            socket.Receive(sizeBuffer, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(sizeBuffer, 0);
            byte[] taskBuffer = new byte[size];
            socket.Receive(taskBuffer, 0, size, SocketFlags.None);
            return JsonSerializer.Deserialize<Task>(taskBuffer);
        }

        public static void SendTask(Task task, Socket socket)
        {
            byte[] taskBuffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(task));
            byte[] sizeBuffer = BitConverter.GetBytes(taskBuffer.Length);;
            socket.Send(sizeBuffer);
            socket.Send(taskBuffer);
        }
    }
    
    public class TaskComparer : IComparer<Task>
    {
        public int Compare(Task x, Task y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var timeComparison = x.Time.CompareTo(y.Time);
            if (timeComparison != 0) return timeComparison;
            return x.Id.CompareTo(y.Id);
        }
    }

    public static class ArrayProcessing
    {
        public static byte[] GetPrefix(byte[] buffer, int count)
        {
            byte[] result = new byte[count];
            Array.Copy(buffer, result, count);
            return result;
        }
    }
}
