using System;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{   
    [DataContract]
    public class RoomChargeForReporting
    {
        public RoomChargeForReporting()
        {
            BranchEmail = string.Empty;
            BranchFax = string.Empty;
            BranchPhone = string.Empty;
            BranchAddress = string.Empty;
            BranchName = string.Empty;
            BranchCompanyId = -1;
            BranchId = -1;
            FolioNo = string.Empty;
            RoomRate = 0;
            RoomType = string.Empty;
            RoomNo = string.Empty;
            GuestName = string.Empty;
            Employee = string.Empty;
            RemainAmount = 0;
            IsPaid = string.Empty;
            PaymentRef = string.Empty;
            InvAmount = 0;
            RegDate = DateTime.Now;
            InvNo = string.Empty;
            Id = 0;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string InvNo { get; set; }

        [DataMember]
        public DateTime RegDate { get; set; }

        [DataMember]
        public decimal InvAmount { get; set; }

        [DataMember]
        public string PaymentRef { get; set; }

        [DataMember]
        public string IsPaid { get; set; }

        [DataMember]
        public decimal RemainAmount { get; set; }

        [DataMember]
        public string Employee { get; set; }

        [DataMember]
        public string GuestName { get; set; }

        [DataMember]
        public string RoomNo { get; set; }

        [DataMember]
        public string RoomType { get; set; }

        [DataMember]
        public decimal RoomRate { get; set; }

        [DataMember]
        public string FolioNo { get; set; }

        [DataMember]
        public int BranchId { get; set; }

        [DataMember]
        public int BranchCompanyId { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string BranchAddress { get; set; }

        [DataMember]
        public string BranchPhone { get; set; }

        [DataMember]
        public string BranchFax { get; set; }

        [DataMember]
        public string BranchEmail { get; set; }

    }
}
