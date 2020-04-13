﻿using System;
using System.IO;
using System.Threading;

namespace ProjBobcat.Class.Helper
{
    public static class FileHelper
    {
        private static readonly object Locker = new object();

        /// <summary>
        /// 写入文件。
        /// </summary>
        /// <param name="path">路径。</param>
        /// <param name="content">内容。</param>
        public static void Write(string path, string content)
        {
            lock(Locker)
                File.WriteAllText(path, content);
            /*
            using var fs = new FileStream(path, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(content);
            sw.Close();
            */
        }

        /// <summary>
        /// 将二进制流写入到文件。
        /// </summary>
        /// <param name="stream">流。</param>
        /// <param name="fileName">路径。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>表示成功与否。</returns>
        public static bool SaveBinaryFile(Stream stream, string fileName)
        {
            if (stream == null) throw new ArgumentNullException();

            var value = true;
            // var buffer = new byte[1024];

            try
            {
                /*
                if (File.Exists(fileName))
                    File.Delete(fileName);
                */
                // File.Create本身就会覆盖。
                lock (Locker)
                {
                    using var outStream = File.Create(fileName);

                    stream.CopyTo(outStream, 1024);
                    /*
                    int l;
                    do
                    {
                        l = stream.Read(buffer, 0, buffer.Length);
                        if (l > 0)
                            outStream.Write(buffer, 0, l);
                    } while (l > 0);

                    outStream.Close();
                    */
                }

                stream.Close();
            }
            catch (ArgumentException)
            {
                value = false;
            }
            catch (IOException)
            {
                value = false;
            }
            catch (UnauthorizedAccessException)
            {
                value = false;
            }

            return value;
        }
    }
}