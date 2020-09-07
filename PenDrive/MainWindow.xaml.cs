using PenDrive.model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PenDrive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComboBox comboBoxUSB, comboBoxImage;
        public MainWindow()
        {
            InitializeComponent();
            loadComboBoxUSBDeviceInfo();
            loadComboBoxImageInfo();
        }

        private void buttonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            loadComboBoxUSBDeviceInfo();
        }

        private void buttonConcluir_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, string> selectedUSB = (KeyValuePair<string, string>)this.comboBoxUSBDeviceInfo.SelectedItem;
            KeyValuePair<model.Image, string> selectedImage = (KeyValuePair<model.Image, string>)this.comboBoxImageInfo.SelectedItem;
            model.Image image = new model.Image();

            MessageBox.Show(selectedUSB.Key);
            MessageBox.Show(selectedImage.Key.path);
        }


        public void loadComboBoxUSBDeviceInfo()
        {
            this.comboBoxUSBDeviceInfo.Items.Clear();
            this.comboBoxUSBDeviceInfo.SelectedValuePath = "Key";
            this.comboBoxUSBDeviceInfo.DisplayMemberPath = "Value";

            foreach (USB usb in USBDeviceInfo.getDiskNames())
            {
                this.comboBoxUSBDeviceInfo.Items.Add(new KeyValuePair<string, string>(usb.deviceID, usb.deviceID + " " + usb.caption));
            }

            this.comboBoxUSBDeviceInfo.SelectedIndex = 0;
        }


        public async void loadComboBoxImageInfo()   
        {
            this.comboBoxImageInfo.Items.Clear();
            this.comboBoxImageInfo.SelectedValuePath = "Key";
            this.comboBoxImageInfo.DisplayMemberPath = "Value";
            try
            {
                var result = await ImagenService.getImagens();
                var jsonObj = new JavaScriptSerializer().Deserialize<Images>(result);
                foreach (model.Image obj in jsonObj.images)
                {
                    this.comboBoxImageInfo.Items.Add(new KeyValuePair<model.Image, string>(obj, obj.name));
                }     
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no servidor");
            }

            this.comboBoxImageInfo.SelectedIndex = 0;
        }

    }
}
