using CargoRequestUI.Models;
using System;
using System.Windows;

namespace CargoRequestUI.Views
{
    public partial class CreateCargoRequest : Window
    {
        public CreateCargoRequest()
        {
            InitializeComponent();

            var cargoRequestDto = new CargoRequestDto();
            cargoRequestDto.Recipient = new RecipientDto();
            cargoRequestDto.Sender = new SenderDto();
            cargoRequestDto.Cargo = new CargoDto();
            cargoRequestDto.Status = new StatusDto();

            DataContext = cargoRequestDto;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataService dataService = new DataService();

            var request = new CargoRequestDto()
            {
                ReqNumber = Convert.ToInt32(txtReqNumber.Text),
                Status = new StatusDto() { StatusType = RequestStatusType.New, Reason = "" },
                Sender = new SenderDto() { Name = txtSender.Text, Address = txtSenderAddress.Text },
                Recipient = new RecipientDto() { Name = txtRecipient.Text, Address = txtRecipientAddress.Text },
                Cargo = new CargoDto()
                {
                    Сharacteristic = txtCargoCharact.Text,
                    Weight = Convert.ToDouble(txtCargoWeight.Text),
                    Volume = Convert.ToDouble(txtCargoVolume.Text),
                    Dimensions = txtCargoDimensions.Text
                },
                Documents = txtDocument.Text
            };

            dataService.saveCargoRequests(request);

            Close();

            MessageBox.Show("Заявка принята!");
        }
    }
}
