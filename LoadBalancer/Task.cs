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
            byte[] taskBuffer;
            byte[] sizeBuffer = new byte[4];
            socket.Receive(sizeBuffer, 0, 4, SocketFlags.Peek);
            int size = BitConverter.ToInt32(sizeBuffer, 0);
            taskBuffer = new byte[size + 4];
            int n = socket.Receive(taskBuffer, 0, size + 4, SocketFlags.None);
            if (n < size + 4)
            {
                throw new Exception("EROROROROOROROR! (ХУЙ)");
            }
            Task recievedTask = null;
            try
            {
                recievedTask = JsonSerializer.Deserialize<Task>(Encoding.UTF8.GetString(taskBuffer, 4, size));
            }
            catch (Exception e)
            {
            }

            return recievedTask;
        }

        public static void SendTask(Task task, Socket socket)
        {
            byte[] taskBuffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(task));
            byte[] sizeBuffer = BitConverter.GetBytes(taskBuffer.Length);
            byte[] resultBytes = new byte[taskBuffer.Length + sizeBuffer.Length];
            sizeBuffer.CopyTo(resultBytes, 0);
            taskBuffer.CopyTo(resultBytes, sizeBuffer.Length);
            socket.Send(resultBytes, SocketFlags.None);
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
