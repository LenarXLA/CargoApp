using CargoRequestUI.Models;
using System;
using System.Windows;
using System.Linq;

namespace CargoRequestUI.Views
{

    public partial class EditCargoRequest : Window
    {
        CargoRequestDto? currentContextCargoRequest;
        public EditCargoRequest(object sender)
        {
            InitializeComponent();
            SetItems(sender);
        }

        private async void SetItems(object sender)
        {
            currentContextCargoRequest = ((FrameworkElement)sender).DataContext as CargoRequestDto;

            if (currentContextCargoRequest != null)
            {
                txtReqNumber.Text = currentContextCargoRequest?.ReqNumber.ToString();
                txtSender.Text = currentContextCargoRequest?.Sender.Name;
                txtSenderAddress.Text = currentContextCargoRequest?.Sender.Address;
                txtRecipient.Text = currentContextCargoRequest?.Recipient.Name;
                txtRecipientAddress.Text = currentContextCargoRequest?.Recipient.Address;
                txtCargoCharact.Text = currentContextCargoRequest?.Cargo.Сharacteristic;
                txtCargoWeight.Text = currentContextCargoRequest?.Cargo.Weight.ToString();
                txtCargoVolume.Text = currentContextCargoRequest?.Cargo.Volume.ToString();
                txtCargoDimensions.Text = currentContextCargoRequest?.Cargo.Dimensions;
                txtDocument.Text = currentContextCargoRequest?.Documents;
            }
            
            cmbxReqStatus.ItemsSource = Enum.GetValues(typeof(RequestStatusType)).Cast<RequestStatusType>();
            cmbxReqStatus.SelectedIndex = (int)(currentContextCargoRequest?.Status.StatusType);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataService dataService = new DataService();

            var request = new CargoRequestDto()
            {
                Id = currentContextCargoRequest.Id,
                ReqNumber = Convert.ToInt32(txtReqNumber.Text),
                Status = new StatusDto() 
                { 
                    Id = currentContextCargoRequest.Status.Id,  
                    StatusType = (RequestStatusType)cmbxReqStatus.SelectedValue,
                    Reason = txtRejected.Text
                },
                Sender = new SenderDto() 
                { 
                    Id = currentContextCargoRequest.Sender.Id, 
                    Name = txtSender.Text, 
                    Address = txtSenderAddress.Text 
                },
                Recipient = new RecipientDto() 
                { 
                    Id = currentContextCargoRequest.Recipient.Id, 
                    Name = txtRecipient.Text, 
                    Address = txtRecipientAddress.Text 
                },
                Cargo = new CargoDto()
                {
                    Id = currentContextCargoRequest.Cargo.Id,
                    Сharacteristic = txtCargoCharact.Text,
                    Weight = Convert.ToDouble(txtCargoWeight.Text),
                    Volume = Convert.ToDouble(txtCargoVolume.Text),
                    Dimensions = txtCargoDimensions.Text
                },
                Documents = txtDocument.Text
            };

            dataService.updateCargoRequests(request.Id, request);
            

            Close();

            MessageBox.Show("Заявка изменена!");

        }

        private void cmbxReqStatus_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((RequestStatusType)cmbxReqStatus.SelectedValue == RequestStatusType.Cancelled)
            {
                boxRejectComment.Visibility = Visibility.Visible;
            }
            else
            {
                boxRejectComment.Visibility = Visibility.Collapsed;
            }
        }
    }
}
