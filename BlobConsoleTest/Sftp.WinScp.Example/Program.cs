using System;
using WinSCP;

namespace Sftp.WinScp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SessionOptions sessionOptions = new SessionOptions();
            
            sessionOptions.Protocol = Protocol.Sftp;
            sessionOptions.HostName = ftpurl;
            sessionOptions.UserName = ftpusername;
            sessionOptions.Password = ftppassword;
            sessionOptions.SshHostKeyFingerprint = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            Session session = new Session();
            session.Open(sessionOptions);
            
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            
            TransferOperationResult transferResult;
            
            //This is for Getting/Downloading files from SFTP  
            transferResult = session.GetFiles(DirectoryPath, destinationFtpUrl, false, transferOptions);
            //This is for Putting/Uploading file on SFTP  
            transferResult = session.PutFiles(DirectoryPath, destinationFtpUrl, false, transferOptions);
            transferResult.Check();
        }
    }
}
}
