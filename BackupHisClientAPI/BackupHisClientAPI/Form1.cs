using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proficy.Historian.ClientAccess.API;

namespace BackupHisClientAPI
{
    public partial class Form1 : Form
    {
        //variable to hold the Historian server connection
        public ServerConnection sc;
        public string outtext;
        public static string ServerName;

        private static string ArchiveOfflinePath;
        private static string folderName;

        public Archive oldestAcrhive;

        private string HistorianServerName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Подключаем к локальному серверу, берем имя ПК
            txtHistorianSRV.Text = System.Environment.MachineName;
            HistorianServerName = txtHistorianSRV.Text;
            ServerName = txtHistorianSRV.Text;


            ArchiveOfflinePath = @"D:\Proficy Historian Data\Archives\Offline";
            folderName = @"D:\Proficy Historian Data\Archives";

            btnDisconnect.Enabled = false;
            outtext = "";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            sc = new ServerConnection(new ConnectionProperties { ServerHostName = txtHistorianSRV.Text });
            sc.Connect();
            if (sc.IsConnected())
            {
                MessageBox.Show("Historian Server Connected");

                labelConn.Text = "Подключено";
                labelConn.ForeColor = Color.Blue;

                //Выставим синий цвет при связи с сервером
                txtHistorianSRV.ForeColor = Color.Blue;

                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;

                RefreshDataStores();
            }
            else
            {
                MessageBox.Show("Historian Server Fails to Connect");
                txtHistorianSRV.ForeColor = Color.Red;

                labelConn.Text = "Не удалось";
                labelConn.ForeColor = Color.Red;
            }
        }

        private void RefreshDataStores()
        {
            List<DataStore> AllDataStore = new List<DataStore>();
            sc.IDataStores.Query("*", out AllDataStore);

            int getDataStoreCount = AllDataStore.Count;

            for (int i = 0; i < getDataStoreCount; i++)
            {
                cmbDataStores.Items.Add(AllDataStore[i].Name);

            }
            //DHSystem у меня третий, поэтому выставляем индекс 2
            //User у меня второй, поэтому выставляю индекс 1
            cmbDataStores.SelectedIndex = 1;

            //textBox1.Text += ("Текущее время: " + DateTime.Now + " \r\n");
        }
        
        private void querybutton_Click(object sender, EventArgs e)
        {
            //Вызовем функцию запроса архивов
            ExtractArhiveList();
        }

        private void ExtractArhiveList()
        {

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Имя архива", typeof(string));
            dt.Columns.Add("Start Time", typeof(DateTime));
            dt.Columns.Add("End Time", typeof(DateTime));

            //Получаем из выбранного элемента ComboBox имя DataStor'a
            string datastorename = cmbDataStores.SelectedItem.ToString();

            ArchiveQueryParams ArchiveQueryParams = new ArchiveQueryParams();
            //извлекаем все подряд
            ArchiveQueryParams.Namemask = "*";

            //List<Archive> ArchiveList = new List<Archive>();
            List<Archive> ArchiveTemp;

            try
            {
                //Делаем запрос к нашему DataStorу
                sc.IArchives.Query(ref ArchiveQueryParams, out ArchiveTemp, datastorename);

                //количество архивов
                int getArchivesCount = ArchiveTemp.Count;

                for (int i = 0; i < getArchivesCount; i++)
                {
                    string ArchiveNames = ArchiveTemp[i].Name;
                    DateTime StartTime = ArchiveTemp[i].StartTime.ToLocalTime();
                    //datesStart.Add(StartTime);
                    DateTime EndTime = ArchiveTemp[i].EndTime.ToLocalTime();
                    dgvArchives.DataSource = dt;
                    dt.Rows.Add(ArchiveNames, StartTime, EndTime);
                    dgvArchives.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                DateTime oldertime = ArchiveTemp.Min(item => item.StartTime);//datesStart.Min();
                textBox1.Text += ("Самая старая дата архива - " + oldertime.ToString() + " \r\n");

                //Выбираем самый новый архив. Если нужен самый старый, то используем .FirstOrDefault();
                oldestAcrhive = ArchiveTemp.OrderBy(item => item.StartTime).LastOrDefault();

                textBox1.Text += (DateTime.Now +" Полное описание. Имя: " + oldestAcrhive.Name 
                  + ". Дата начала: " + oldestAcrhive.StartTime.ToShortDateString()
                  + ". Дата окончания:  " + oldestAcrhive.EndTime.ToShortDateString() + " \r\n");

                //BackupArchive(oldestAcrhive);
                //Вызываем функцию Remove
                RemoveArchive(oldestAcrhive);

            }

            catch
            {
                MessageBox.Show("No Archives Exists");
            }
        }


        private void RemoveArchive(Archive Archiv)
        {
            string ArchiveName = Archiv.Name;
            string DataStoreName = Archiv.DataStoreName;
            sc.IArchives.Remove(ArchiveName, true, DataStoreName);

            textBox1.Text += (DateTime.Now + " Архив ремувнут. Убираем файл." + " \r\n");

            //удаляем файл
            DeleteFile(oldestAcrhive.Name);
        }

        private void DeleteFile(string ArchiveName)
        {
            //Ищем по пути стандартному файл архива iha
            string ArchiveNameFile = folderName + "\\" + ArchiveName + ".iha";
            textBox1.Text += (DateTime.Now + " Путь до файла: " + ArchiveNameFile + " \r\n");

            if (!IsFileInUse(ArchiveNameFile))
            {
                File.Delete(ArchiveNameFile);
            }

            textBox1.Text += (DateTime.Now + "Файл удален. " + " \r\n");
        }

        private void BackupArchive(Archive archive)
        {
            //Имя извлекаем из списка
            string ArchiveName = archive.Name;
            //Путь до архива
            //string ArchiveNameBackup = txtArchivePath.Text + "\\" + ArchiveName + "_Backup.zip";
            string ArchiveNameBackup = folderName + "\\" + ArchiveName + "_Backup.zip";
            textBox1.Text += ("ArchiveNameBackup: " + ArchiveNameBackup + " \r\n");

            string DataStoreName = archive.DataStoreName;
            sc.IArchives.Backup(ArchiveName, ArchiveNameBackup, true, DataStoreName);
            textBox1.Text += (DateTime.Now + " Архив забэкаплен. " + " \r\n");
        }

        //Проверка доступности файла.
        public static bool IsFileInUse(string sFile)
        {
            try
            {
                using (new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return false;
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            sc.Disconnect();

            MessageBox.Show("Historian Server Disconnected");

            labelConn.Text = "Отключено";
            labelConn.ForeColor = Color.Red;//YellowGreen;
            txtHistorianSRV.ForeColor = Color.Red;

            //очищает таблицу
            dgvArchives.DataSource = null;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;

            //чистим лог
            textBox1.Text = "";
            outtext = "";
        }

		//Это на будущее, можете доработать, чтобы перемещать файл на удаленный сетевой диск
        private void CopyFileAndRemove()
        {
            string localPath = @"D:\Proficy Historian Data\Archives\Offline\";
            string FileName = "text.txt";
            string FullName = localPath + FileName;

            string destFileName = @"Z:\" + FileName;

            textBox1.Text += (DateTime.Now + " FullName: " + FullName + " \r\n");
            textBox1.Text += (DateTime.Now + " destFileName: " + destFileName + " \r\n");

            if (!IsFileInUse(FullName))
            {
                File.Copy(FullName, destFileName);
                //Расскоментировать, если нужно убрать после этого файл.
                //File.Delete(FullName);
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            CopyFileAndRemove();
        }
    }
}
