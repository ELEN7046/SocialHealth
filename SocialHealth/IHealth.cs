using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SocialHealth
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHealth" in both code and config file together.
    [ServiceContract]
    public interface IHealth
    {
        [OperationContract]
        List<HealthProfile> getHealthProfiles();

        [OperationContract]
        List<HealthProfile> getHealthProfilesByYear(string Year);

        [OperationContract]
        List<HealthProfile> getHealthProfilesByProvince(string Province);
    }

    [DataContract]
    public class HealthProfile
    {
        public Int32 _Year;
        public string _Province;
        public string _District;
        public string _LocalMunicipality;
        public string _Needs;
        public string _HaveDifficulty;
        public string _HavePermanentDifficulty;
        public string _UsesChronicMedication;
        public string _UsesAid;
        public string _NeedHealthService;
        public string _FemaleHealthNeeds;
        public string _value;
        public string _link;
        public string _id;
        public string _label;

        [DataMember]
        public Int32 Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        [DataMember]
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        [DataMember]
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }
        [DataMember]
        public string LocalMunicipality
        {
            get { return _LocalMunicipality; }
            set { _LocalMunicipality = value; }
        }
        [DataMember]
        public string Needs
        {
            get { return _Needs; }
            set { _Needs = value; }
        }
        [DataMember]
        public string HaveDifficulty
        {
            get { return _HaveDifficulty; }
            set { _HaveDifficulty = value; }
        }
        [DataMember]
        public string HavePermanentDifficulty
        {
            get { return _HavePermanentDifficulty; }
            set { _HavePermanentDifficulty = value; }
        }
        [DataMember]
        public string UsesChronicMedication
        {
            get { return _UsesChronicMedication; }
            set { _UsesChronicMedication = value; }
        }
        [DataMember]
        public string UsesAid
        {
            get { return _UsesAid; }
            set { _UsesAid = value; }
        }
        [DataMember]
        public string NeedHealthService
        {
            get { return _NeedHealthService; }
            set { _NeedHealthService = value; }
        }
        [DataMember]
        public string FemaleHealthNeeds
        {
            get { return _FemaleHealthNeeds; }
            set { _FemaleHealthNeeds = value; }
        }

        [DataMember]
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        [DataMember]
        public string link
        {
            get { return _link; }
            set { _link = value; }
        }
        [DataMember]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string label
        {
            get { return _label; }
            set { _label = value; }
        }
    }
}
