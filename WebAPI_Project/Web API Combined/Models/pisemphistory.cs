//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_Combined.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pisemphistory
    {
        public Nullable<long> transid { get; set; }
        public int StateID { get; set; }
        public string deptid { get; set; }
        public string empcd { get; set; }
        public long uniqid { get; set; }
        public string transtype { get; set; }
        public string orderno { get; set; }
        public System.DateTime orderdt { get; set; }
        public string StateCodeFrom { get; set; }
        public string StateCodeTo { get; set; }
        public string DeptIDFrom { get; set; }
        public string NewdeptID { get; set; }
        public string NewDeptNameFrom { get; set; }
        public string NewDeptNameTo { get; set; }
        public string OfficeID { get; set; }
        public string newofficeid { get; set; }
        public string NewOfficeNameFrom { get; set; }
        public string NewOfficeNameTo { get; set; }
        public string DesignationID { get; set; }
        public string newdesigcd { get; set; }
        public string NewDesignationNameFrom { get; set; }
        public string NewDesignationNameTo { get; set; }
        public Nullable<System.DateTime> NewJoiningDate { get; set; }
        public string areatype { get; set; }
        public string newclass { get; set; }
        public string remarks { get; set; }
        public string IsAdditionalCharge { get; set; }
        public Nullable<int> PayCommissionMasterID { get; set; }
        public Nullable<int> PayScaleMasterID { get; set; }
        public Nullable<int> PayBandMasterID { get; set; }
        public Nullable<int> GradePayMasterID { get; set; }
        public string baspay { get; set; }
        public string FromBasicPay { get; set; }
        public string FromPayCommissionString { get; set; }
        public Nullable<System.DateTime> FinancialBeneficialDate { get; set; }
        public Nullable<System.DateTime> PayScaleDate { get; set; }
        public string IsReal { get; set; }
        public string IsNotional { get; set; }
        public Nullable<int> ServiceCode { get; set; }
        public Nullable<int> ServiceGradingCode { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string depuoffice { get; set; }
        public Nullable<System.DateTime> incredt { get; set; }
        public string payscale { get; set; }
        public string TransDeptID { get; set; }
        public Nullable<int> Branchcd { get; set; }
        public Nullable<int> BranchCodeFrom { get; set; }
        public Nullable<int> Cadre { get; set; }
        public string estabdeptid { get; set; }
        public string estabofficeid { get; set; }
        public Nullable<System.DateTime> dofrelieve { get; set; }
        public Nullable<long> linkeduniqueid { get; set; }
        public byte[] Attachment { get; set; }
        public string AttachmentExt { get; set; }
        public string Updated_By { get; set; }
        public Nullable<System.DateTime> Updation_Date { get; set; }
        public string Verify { get; set; }
        public string Verified_By { get; set; }
        public Nullable<System.DateTime> dofvalid { get; set; }
        public string IpAddress { get; set; }
        public Nullable<long> VerifyGroupId { get; set; }
        public string FromBranchName { get; set; }
        public string TobranchName { get; set; }
        public Nullable<int> ToBranchCode { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string fromSubdesig { get; set; }
        public string toSubdesig { get; set; }
        public string fromSubdesig_OLD { get; set; }
        public string toSubdesig_OLD { get; set; }
        public Nullable<int> fromServiceCd { get; set; }
        public Nullable<int> fromGradingcd { get; set; }
    }
}
