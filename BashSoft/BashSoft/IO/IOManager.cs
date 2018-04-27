using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft
{
    public  class IOManager : IDirectoryManager
    {
        public  void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
                string[] paths = Directory.GetDirectories(currentPath);

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {

                    OutputWriter.DisplayException
                        (ExceptionMessages.UnauthorizedAccessExeptionMessage);
                }
               
                if (depth - identation < 0)
                {
                    break;
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);    
            }
            catch (ArgumentException)
            {

                throw  new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {

                    throw new InvalidPathException();
                }
                
            }
            else
            {
                string cuurentPath = SessionData.currentPath;
                cuurentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsoulute(cuurentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsoulute(string absoulutePath)
        {
            if (!Directory.Exists(absoulutePath))
            {
                throw new InvalidPathException();
            }
            SessionData.currentPath = absoulutePath;
        }
    }
}
