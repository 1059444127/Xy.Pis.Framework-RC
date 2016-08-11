using System;
using System.Collections.Generic;

namespace Xy.Pis.Domain
{
    public partial class VwInHosInfoNormal
    {
        public int ID { get; set; }
        public string HospNo { get; set; }
        public int PatID { get; set; }
        public string InPatNo { get; set; }
        public string CardNo { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int NTime { get; set; }
        public System.DateTime InTime { get; set; }
        public Nullable<System.DateTime> OutTime { get; set; }
        public Nullable<short> LsMarriage { get; set; }
        public string BloodGroup { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Residence { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public bool IsOversea { get; set; }
        public Nullable<System.DateTime> PassTime { get; set; }
        public string IdCardNo { get; set; }
        public string Company { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> WorktypeId { get; set; }
        public int PatTypeId { get; set; }
        public Nullable<int> CertificateId { get; set; }
        public Nullable<short> LsInType { get; set; }
        public Nullable<short> LsInWay { get; set; }
        public Nullable<short> LsInIllness { get; set; }
        public Nullable<int> DocMz { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public int LocIn { get; set; }
        public Nullable<int> LocationId { get; set; }
        public bool IsYbMt { get; set; }
        public string YbRegNo { get; set; }
        public Nullable<decimal> ArrearAmount { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string PhoneHome { get; set; }
        public string AddressHome { get; set; }
        public string PostCodeHome { get; set; }
        public string AreaCodeHome { get; set; }
        public string PhoneWork { get; set; }
        public string AddressWork { get; set; }
        public string PostCodeWork { get; set; }
        public string AreaCodeWork { get; set; }
        public string LinkmanName { get; set; }
        public Nullable<int> RelationId { get; set; }
        public string LinkmanPhone { get; set; }
        public string LinkmanAddress { get; set; }
        public string LinkmanPost { get; set; }
        public string LinkmanArea { get; set; }
        public short LsInStatus { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public string Status { get; set; }
        public System.DateTime OperTime { get; set; }
        public int OperID { get; set; }
        public bool IsEndChg { get; set; }
        public Nullable<int> EndChgOperID { get; set; }
        public Nullable<System.DateTime> EndchgoperTime { get; set; }
        public string AgeString { get; set; }
        public string PyCode { get; set; }
        public Nullable<int> BedId { get; set; }
        public Nullable<int> NursingGradeId { get; set; }
        public string FirstLinkmanName { get; set; }
        public Nullable<int> FirstRelationId { get; set; }
        public string FirstLinkmanIdCard { get; set; }
        public string FirstLinkManWorkUnit { get; set; }
        public string FirstLinkmanUnitAddress { get; set; }
        public string FirstLinkmanFamilyAddress { get; set; }
        public string FirstLinkmanFamilyPhone { get; set; }
        public string FirstLinkmanPhone { get; set; }
        public string SecondLinkmanName { get; set; }
        public Nullable<int> SecondRelationId { get; set; }
        public string SecondLinkmanIdCard { get; set; }
        public string SecondLinkManWorkUnit { get; set; }
        public string SecondLinkmanUnitAddress { get; set; }
        public string SecondLinkmanFamilyAddress { get; set; }
        public string SecondLinkmanFamilyPhone { get; set; }
        public string SecondLinkmanPhone { get; set; }
        public Nullable<int> BedYearTypeId { get; set; }
        public Nullable<short> LsOutManagementType { get; set; }
        public Nullable<int> AddRatioId { get; set; }
        public Nullable<short> LsEconomicSource { get; set; }
        public Nullable<int> MealTypeId { get; set; }
        public Nullable<int> ServiceChargeId { get; set; }
        public Nullable<System.DateTime> AgreementBeginDate { get; set; }
        public Nullable<System.DateTime> AgreementEndDate { get; set; }
        public bool IsCheckInCharge { get; set; }
        public Nullable<decimal> OneTimeFacilityFee { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> ServiceChargeAmount { get; set; }
    }
}