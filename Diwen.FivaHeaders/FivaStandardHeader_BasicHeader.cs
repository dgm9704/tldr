// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

// 
//This source code was auto-generated by MonoXSD
//
namespace Schemas {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    [System.Xml.Serialization.XmlRootAttribute("FivaStandardHeader", Namespace="http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader", IsNullable=false)]
    public partial class FivaStandardHeaderType {
        
        private System.DateTime instanceCreationDateTimeField;
        
        private string reportingPeriodField;
        
        private string reportingEntityField;
        
        private FivaStandardHeaderTypeReportingEntityType reportingEntityTypeField;
        
        private string typeOfReportingInstitutionField;
        
        private string reportingApplicationNameField;
        
        private string reportingApplicationVersionField;
        
        private string contactPersonFirstNameField;
        
        private string contactPersonLastNameField;
        
        private string contactPersonEmailField;
        
        private string contactPersonTelephoneField;
        
        private string commentField;
        
        private string testFlagField;
        
        private BasicHeaderType basicHeaderField;
        
        public FivaStandardHeaderType() {
            this.testFlagField = "false";
        }
        
        /// <remarks/>
        public System.DateTime InstanceCreationDateTime {
            get {
                return this.instanceCreationDateTimeField;
            }
            set {
                this.instanceCreationDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string ReportingPeriod {
            get {
                return this.reportingPeriodField;
            }
            set {
                this.reportingPeriodField = value;
            }
        }
        
        /// <remarks/>
        public string ReportingEntity {
            get {
                return this.reportingEntityField;
            }
            set {
                this.reportingEntityField = value;
            }
        }
        
        /// <remarks/>
        public FivaStandardHeaderTypeReportingEntityType ReportingEntityType {
            get {
                return this.reportingEntityTypeField;
            }
            set {
                this.reportingEntityTypeField = value;
            }
        }
        
        /// <remarks/>
        public string TypeOfReportingInstitution {
            get {
                return this.typeOfReportingInstitutionField;
            }
            set {
                this.typeOfReportingInstitutionField = value;
            }
        }
        
        /// <remarks/>
        public string ReportingApplicationName {
            get {
                return this.reportingApplicationNameField;
            }
            set {
                this.reportingApplicationNameField = value;
            }
        }
        
        /// <remarks/>
        public string ReportingApplicationVersion {
            get {
                return this.reportingApplicationVersionField;
            }
            set {
                this.reportingApplicationVersionField = value;
            }
        }
        
        /// <remarks/>
        public string ContactPersonFirstName {
            get {
                return this.contactPersonFirstNameField;
            }
            set {
                this.contactPersonFirstNameField = value;
            }
        }
        
        /// <remarks/>
        public string ContactPersonLastName {
            get {
                return this.contactPersonLastNameField;
            }
            set {
                this.contactPersonLastNameField = value;
            }
        }
        
        /// <remarks/>
        public string ContactPersonEmail {
            get {
                return this.contactPersonEmailField;
            }
            set {
                this.contactPersonEmailField = value;
            }
        }
        
        /// <remarks/>
        public string ContactPersonTelephone {
            get {
                return this.contactPersonTelephoneField;
            }
            set {
                this.contactPersonTelephoneField = value;
            }
        }
        
        /// <remarks/>
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("false")]
        public string TestFlag {
            get {
                return this.testFlagField;
            }
            set {
                this.testFlagField = value;
            }
        }
        
        /// <remarks/>
        public BasicHeaderType BasicHeader {
            get {
                return this.basicHeaderField;
            }
            set {
                this.basicHeaderField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    public enum FivaStandardHeaderTypeReportingEntityType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TK-tunnus")]
        TKtunnus,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Y-tunnus")]
        Ytunnus,
        
        /// <remarks/>
        LEI,
        
        /// <remarks/>
        MFI,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    [System.Xml.Serialization.XmlRootAttribute("BasicHeader", Namespace="http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader", IsNullable=false)]
    public partial class BasicHeaderType {
        
        private ReportDataContextType reportDataContextField;
        
        private FileType[] fileField;
        
        /// <remarks/>
        public ReportDataContextType ReportDataContext {
            get {
                return this.reportDataContextField;
            }
            set {
                this.reportDataContextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("File")]
        public FileType[] File {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    public partial class ReportDataContextType {
        
        private string reportReferenceIDField;
        
        /// <remarks/>
        public string ReportReferenceID {
            get {
                return this.reportReferenceIDField;
            }
            set {
                this.reportReferenceIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    public partial class FileType {
        
        private string filePathField;
        
        /// <remarks/>
        public string FilePath {
            get {
                return this.filePathField;
            }
            set {
                this.filePathField = value;
            }
        }
    }
}