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
    
    public partial class EmpLeaveHistory
    {
        public int EmpLeaveHistID { get; set; }
        public int StateID { get; set; }
        public string DeptID { get; set; }
        public long OfficeID { get; set; }
        public string EmpCode { get; set; }
        public string FinancialYear { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveRefID { get; set; }
        public System.DateTime FromDate { get; set; }
        public string StartDayHalf { get; set; }
        public System.DateTime ToDate { get; set; }
        public string EndDayHalf { get; set; }
        public string Remarks { get; set; }
        public System.DateTime AppliedOn { get; set; }
        public string AddressDuringLeave { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<System.DateTime> VerifiedOn { get; set; }
        public int LeaveStatusID { get; set; }
        public string IPAddress { get; set; }
        public double TotalDays { get; set; }
        public string ReportingOfficerID { get; set; }
        public string CommentsByReportingOfficer { get; set; }
        public string ltcavail { get; set; }
        public string ltcYear { get; set; }
        public string StationLeave { get; set; }
        public string DaysSuffixOrPrefix { get; set; }
        public byte[] LeaveAttachment { get; set; }
        public string AttachmentExt { get; set; }
        public string LeaveExtension { get; set; }
        public Nullable<int> ExtendedLeaveHistoryID { get; set; }
        public Nullable<System.DateTime> LeaveExtensionDate { get; set; }
        public string CancelAfterApproval { get; set; }
        public Nullable<System.DateTime> CancellationRequestDate { get; set; }
        public string EarlyJoiningRequest { get; set; }
        public Nullable<int> EarlyJoinedLeaveHistID { get; set; }
        public int LeaveYear { get; set; }
        public string IsLeaveExtended { get; set; }
        public string IsForwarded { get; set; }
        public string FromApp { get; set; }
        public string CancelReason_AfterApproval { get; set; }
        public string RptOfficerRemarks_AfterApproval { get; set; }
        public string OrderPublished { get; set; }
        public Nullable<long> LTCID { get; set; }
        public Nullable<int> CombinedLeaveTypeID { get; set; }
        public Nullable<System.DateTime> CombinedFromDate { get; set; }
        public string CombinedStartDayHalf { get; set; }
        public Nullable<System.DateTime> CombinedToDate { get; set; }
        public string CombinedEndDayHalf { get; set; }
        public Nullable<double> CombinedTotalDays { get; set; }
        public string SLCLTypes { get; set; }
        public string LeaveTransBalance { get; set; }
        public string LeaveTransBalance_Numerator { get; set; }
        public string LeaveTransBalance_Denominator { get; set; }
        public string CombinedLeaveTransBalance { get; set; }
        public string CombinedLeaveTransBalance_Numerator { get; set; }
        public string CombinedLeaveTransBalance_Denominator { get; set; }
        public string SelfCancelAfterApproval { get; set; }
        public Nullable<System.DateTime> SelfCancelAfterApprovalOn { get; set; }
    }
}
