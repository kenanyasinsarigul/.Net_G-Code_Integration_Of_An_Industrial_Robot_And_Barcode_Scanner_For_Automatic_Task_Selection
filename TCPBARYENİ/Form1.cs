using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace TCPBARYENİ
{
    public partial class Form1 : Form
    {
        public string message1;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }



        private static Socket client;
        private static byte[] data = new byte[1024];
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("connecting...");
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.0.100"), 2112);
            client.BeginConnect(iep, new AsyncCallback(Connected), client);
        }


        void Connected(IAsyncResult iar)
        {
            try
            {
                client.EndConnect(iar);
                textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = "Connected to: " + client.RemoteEndPoint.ToString(); });
                Thread receiver = new Thread(new ThreadStart(ReceiveData));
                receiver.Start();
               
            }
            catch (SocketException)
            {
                textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = ("Error Connecting!"); });
            }
        }

     
        
        void ReceiveData()
        {
           /* this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = true; });*/
            int recv;
            string stringData;
            while (true)
            {
                recv = client.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
               /* if (stringData == "bye")
                    break;*/
                //message1 = (stringData);
                if (textBox3.InvokeRequired)
                {
                    textBox3.Invoke((MethodInvoker)delegate { textBox3.Text = stringData; });


                    if (textBox3.Text.Contains("1272"))
                    {
                        try
                        {
                            textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "ARCTIC"; });
                        }
                        catch
                        {

                        }


                    }
                    else if (textBox3.Text.Contains("1256"))
                    {
                        try
                        {
                            textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "BEKO"; });
                        }
                        catch
                        {

                        }
                    }
                    else if (textBox3.Text.Contains("1473"))
                    {
                        try
                        {
                            textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "GRUNDIG"; });
                        }
                        catch
                        {

                        }
                    }

                    else if (textBox3.Text=="NoRead")
                    {
                        try
                        {
                            textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "NoInformation"; });
                            textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "Stopped by user!!! Press start!!!"; });
                        }
                        catch
                        {

                        }

                    }

                    else
                    {
                        try
                        {
                            textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "It is wrong code!!!"; });

                            Socket socket = client;
                            //string str = textBox2.Text.Trim();
                            string str = ("0");

                            try
                            {
                                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = false; });
                                // sends the text with timeout 10s
                                Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                                textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "Please click the start button!!!"; });
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        catch
                        {

                        }

                    }




                    if (textBox4.Text == "ARCTIC")
                    {


                        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-BRRRBEF\\SQLEXPRESS;Initial Catalog=barcode;Integrated Security=True");
                        baglan.Open();
                        SqlCommand komut = new SqlCommand("insert into barkayit (bar_brand, bar_number) values (@bar_brand, @bar_number)", baglan);
                        komut.Parameters.AddWithValue("@bar_brand", textBox4.Text);
                        komut.Parameters.AddWithValue("@bar_number", textBox3.Text);
                        try
                        {
                            komut.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        
                        baglan.Close();

                        Socket socket = client;
                        //string str = textBox2.Text.Trim();
                        string str = ("0");

                        try
                        { // sends the text with timeout 10s
                            Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                            textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "Waiting..."; });
                        }
                        catch (Exception ex)
                        {

                        }
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Going to point ' 1 '"); });
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = true; });
                        Main();
                        return;
                        




                    }
                    else if (textBox4.Text == "BEKO")
                    {

                        
                        SqlConnection baglan2 = new SqlConnection("Data Source=DESKTOP-BRRRBEF\\SQLEXPRESS;Initial Catalog=barcode;Integrated Security=True");
                        baglan2.Open();
                        SqlCommand komut2 = new SqlCommand("insert into barkayit (bar_brand, bar_number) values (@bar_brand, @bar_number)", baglan2);
                        komut2.Parameters.AddWithValue("@bar_brand", textBox4.Text);
                        komut2.Parameters.AddWithValue("@bar_number", textBox3.Text);
                        try
                        {
                            komut2.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                           
                            baglan2.Close();

                        Socket socket = client;
                        //string str = textBox2.Text.Trim();
                        string str = ("0");

                        try
                        { // sends the text with timeout 10s
                            Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                            textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "waiting..."; });
                        }
                        catch (Exception ex)
                        {

                        }
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Going to point ' 2 '"); });
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = true; });
                        Main();
                        return;
                        
                       
                        




                    }
                        else if (textBox4.Text == "GRUNDIG")
                        {


                            SqlConnection baglan2 = new SqlConnection("Data Source=DESKTOP-BRRRBEF\\SQLEXPRESS;Initial Catalog=barcode;Integrated Security=True");
                            baglan2.Open();
                            SqlCommand komut2 = new SqlCommand("insert into barkayit (bar_brand, bar_number) values (@bar_brand, @bar_number)", baglan2);
                            komut2.Parameters.AddWithValue("@bar_brand", textBox4.Text);
                            komut2.Parameters.AddWithValue("@bar_number", textBox3.Text);
                            try
                            {
                                komut2.ExecuteNonQuery();
                            }
                            catch
                            {

                            }

                            baglan2.Close();

                            Socket socket = client;
                            //string str = textBox2.Text.Trim();
                            string str = ("0");

                            try
                            { // sends the text with timeout 10s
                                Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                                textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "waiting..."; });
                            }
                            catch (Exception ex)
                            {

                            }
                            listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Going to point ' 3 '"); });
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = true; });
                        Main();
                            return;



                        }
                        else
                    {
                       /* textBox4.Invoke((MethodInvoker)delegate { textBox4.Text = "wrong code!"; });*/
                    }


                   

                   

                }
                else
                {
                   // textBox3.Text = stringData;
                } 
          
            }

           
            /*
            stringData = "bye";
            byte[] message = Encoding.ASCII.GetBytes(stringData);
            client.Send(message);
            client.Close();
            textBox1.Text = ("Conncection stopped");
            return;
            */
        }


        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    //MessageBox.Show("send");
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        Thread.Sleep(30);

                    }
                    else
                        throw ex;  // any serious error occurr
                    MessageBox.Show("send error");
                }
            } while (sent < size);
        }


        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably empty, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (received < size);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Socket socket = client;
            //string str = textBox2.Text.Trim();
            string str = ("1");
            try
            { // sends the text with timeout 10s
                Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                textBox2.Text = ("Reading...");
            }
            catch (Exception ex)
            {
                
            }
            


        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { timer1.Enabled = false; });
            Socket socket = client;
            //string str = textBox2.Text.Trim();
            string str = ("0");
            try
            { // sends the text with timeout 10s
                Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = "Stopped..."; });
            }
            catch (Exception ex)
            {
               
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            /*
            Socket socket = client;
            byte[] buffer = new byte[1024];  // length of the text "Hello world!"
            try
            { // receive data with timeout 10s
                //Receive(socket, buffer, 1, 10, 2000);
                Receive(socket, buffer, 0, buffer.Length, 10000);
                string al = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                MessageBox.Show(al);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
            */
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Socket socket = client;
            //string str = textBox2.Text.Trim();
            string str = ("1");
            try
            { // sends the text with timeout 10s
                Send(socket, Encoding.UTF8.GetBytes(str), 0, str.Length, 10000);
                textBox2.Text = ("Reading...");
            }
            catch (Exception ex)
            {

            }
            
        }

       

      private void Main()
        {
           
             // The IP address of the server (the PC on which this program is running)
            string sHostIpAddress = "192.168.0.101";
            // Standard port number
            int nPort = 2111;

            // The following names are used in the PolyScope script for refencing the
            // three working points:
            // Name of an arbitrary work point 1
            const string csMsgPoint1 = "1";
            // Name of an arbitrary work point 2
            const string csMsgPoint2 = "2";
            // Name of an arbitrary work point 3
            const string csMsgPoint3 = "3";
            try
            {
                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Opening IP Address: " + sHostIpAddress); });
                
                IPAddress ipAddress = IPAddress.Parse(sHostIpAddress);        // Create the IP address
                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Starting to listen on port: " + nPort); });
                TcpListener tcpListener = new TcpListener(ipAddress, nPort);  // Create the tcp Listener
                tcpListener.Start();                                          // Start listening


                // Keep on listening forever
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();        // Accept the client
                    listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Accepted new client"); });
                    NetworkStream stream = tcpClient.GetStream();               // Open the network stream
                    while (tcpClient.Client.Connected)
                    {
                        // Create a byte array for the available bytes
                        byte[] arrayBytesRequest = new byte[tcpClient.Available];
                        // Read the bytes from the stream
                        int nRead = stream.Read(arrayBytesRequest, 0, arrayBytesRequest.Length);
                        if (nRead > 0)
                        {
                            // Convert the byte array into a string
                            string sMsgRequest = ASCIIEncoding.ASCII.GetString(arrayBytesRequest);
                            listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Received message request: " + sMsgRequest); });
                            string sMsgAnswer = string.Empty;


                            // Check which workpoint is requested
                            /*if (sMsgRequest.Substring(0, 1).Equals(csMsgPoint1))*/
                            if (textBox4.Text == "ARCTIC")
                            {
                                // Some point in space for work point 1
                                sMsgAnswer = "(1)";                                               
                                
                            }
                           /* else if (sMsgRequest.Substring(0, 1).Equals(csMsgPoint2))*/
                           else if (textBox4.Text=="BEKO")
                            {
                                // Some point in space for work point 2
                                sMsgAnswer = "(2)";                            
                                                             
                            }
                           /* else if (sMsgRequest.Substring(0, 1).Equals(csMsgPoint3))*/
                           else if (textBox4.Text=="GRUNDIG")
                            {
                                // Some point in space for work point 3
                                sMsgAnswer = "(3)";

                            }
                            

                            if (sMsgAnswer.Length > 0)
                            {
                                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Sending message answer: " + sMsgAnswer); });
                                // Convert the point into a byte array
                                byte[] arrayBytesAnswer = ASCIIEncoding.ASCII.GetBytes(sMsgAnswer + '\n');
                                // Send the byte array to the client
                                stream.Write(arrayBytesAnswer, 0, arrayBytesAnswer.Length);
                            }
                            ReceiveData();
                        }
                        else
                        {
                            if (tcpClient.Available == 0)
                            {
                                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Client closed the connection"); });
                                // No bytes read, and no bytes available, the client is closed.
                                stream.Close();
                            }
                            else
                            {
                               /* listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Error..."); });*/
                            }
                        }
                    }
                }
               
            }
            catch (SocketException)
            {
                
            }

           


        }
        

    }


}

