using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Models
{
    public class ShippingInputModel
    {
        #region Ctor
        public ShippingInputModel(string shippingOptionType, string orderId, string pickingSecurityCode
            , string packageDetail, string noteForCourier, string noteForReceiver, AddressInfo pickupAddress, AddressInfo deliveryAddress)
        {
            ShippingOptionType = shippingOptionType;
            OrderId = orderId;
            PickingSecurityCode = pickingSecurityCode;
            PackageDetail = packageDetail;
            NoteForCourier = noteForCourier;
            NoteForReceiver = noteForReceiver;
            PickupAddress = pickupAddress;
            DeliveryAddress = deliveryAddress;
        }
        #endregion
        public string ShippingOptionType { get; set; }
        public string OrderId { get; set; }
        public string PickingSecurityCode { get; set; }
        public string PackageDetail { get; set; }
        public string NoteForCourier { get; set; }
        public string NoteForReceiver { get; set; }
        public AddressInfo PickupAddress { get; set; }
        public AddressInfo DeliveryAddress { get; set; }
    }
    public class AddressInfo
    {
        #region Ctor
        public AddressInfo(string address, string identificationNumber, string name, string primaryPhone,
            string secondaryPhone, string email, double latitude, double longitude)
        {
            Address = address;
            IdentificationNumber = identificationNumber;
            Name = name;
            PrimaryPhone = primaryPhone;
            SecondaryPhone = secondaryPhone;
            Email = email;
            Latitude = latitude;
            Longitude = longitude;
        }
        #endregion
        public string Address { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
